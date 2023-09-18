using WKP.Domain.Entities;
using WKP.Domain.Enums_Contants;
using WKP.Domain.Repositories;

namespace WKP.Application.Application.Common
{
    public class Helper
    {
        private IUnitOfWork _unitOfWork;

        public Helper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int[]? ParseSBUIDs(string[] SBU_IDs) 
        {
            try
            {
                var SBU_IDs_int = new int[SBU_IDs.Length];

                var tempSBUs = new List<string>();
                foreach (string s in SBU_IDs)
                {
                    if (s != null && s != "undefined")
                        tempSBUs.Add(s);
                }

                if (tempSBUs.Count > 0)
                {
                    for (int i = 0; i < tempSBUs.Count; i++)
                        SBU_IDs_int[i] = int.Parse(tempSBUs[i]);
                }
                else
                {
                    SBU_IDs_int = null;
                }

                return SBU_IDs_int;
            }
            catch (Exception){ throw; }
        }

        public async Task<MyDesk> DropAppOnStaffDesk(int appID, staff staff, int FromStaffID, int FromStaffSBU, int FromStaffRoleID, int processID, string status)
        {
            try
            {
                MyDesk drop = new MyDesk()
                {
                    ProcessID = processID,
                    AppId = appID,
                    StaffID = staff.StaffID,
                    FromStaffID = FromStaffID,
                    FromSBU = FromStaffSBU,
                    FromRoleId = FromStaffRoleID,
                    HasWork = true,
                    HasPushed = false,
                    CreatedAt = DateTime.Now,
                    ProcessStatus = status,
                    LastJobDate = DateTime.Now,
                };
                var newDesk = await _unitOfWork.DeskRepository.AddAsync(drop);
                await _unitOfWork.SaveChangesAsync();
                return newDesk;
            }
            catch (Exception){ throw; }
        }

        public async Task<List<staff>> GetReviewerStaffs(List<ApplicationProccess> appFlows)
        {
            try
            {
                var staffLists = new List<staff>();
                foreach (var item in appFlows)
                {
                    var staffs = (await _unitOfWork.StaffRepository.GetAsync((s) => s.Staff_SBU == item.TargetedToSBU && s.RoleID == item.TargetedToRole, null, null)).ToList();

                    if (staffs.Count <= 0) break;

                    var isFound = false;
                    var choosenStaff = staffs.Count > 0 ? staffs[0] : new staff();
                    var choosenDesk = new MyDesk() { LastJobDate = DateTime.Now };

                    foreach (var staff in staffs)
                    {
                        var desk = (await _unitOfWork.DeskRepository
                                    .GetAsync(
                                        d => d.StaffID == staff.StaffID && d.HasWork == true, 
                                        (o) => o.OrderByDescending(x => x.LastJobDate))
                                   ).FirstOrDefault();

                        if (desk == null)
                        {
                            staffLists.Add(staff);
                            isFound = true;
                            break;
                        }

                        choosenStaff = desk.LastJobDate < choosenDesk.LastJobDate ? staff : choosenStaff;
                        choosenDesk = desk.LastJobDate < choosenDesk.LastJobDate ? desk : choosenDesk;
                    }

                    if (!isFound)
                    {
                        staffLists.Add(choosenStaff);
                    }
                }
                return staffLists;
            }
            catch (Exception) { throw; }
        }

        public async Task<MyDesk> GetNextStaffDesk(List<int> staffIds, int appId)
        {
            try
            {
                var staffDesks = new List<MyDesk>();

                foreach (var staffId in staffIds)
                {
                    var deskAlreadyExist = await _unitOfWork.DeskRepository
                            .GetAsync((x) => x.StaffID == staffId && x.AppId == appId && x.HasWork == true, null);
                    var deskHasNoWork = await _unitOfWork.DeskRepository
                            .GetAsync(x => x.StaffID == staffId && x.AppId == appId && x.HasWork == false, null);
					var mostRecentJob = (await _unitOfWork.DeskRepository
                            .GetAsync(x => x.StaffID == staffId, (o) => o.OrderByDescending(x => x.LastJobDate), null)).FirstOrDefault();

                    if (deskAlreadyExist is not null)
                        throw new Exception("This application has already been push to this desk.");
                    else if (deskHasNoWork is not null)
                        return deskHasNoWork;
                    else
                    {
						if(mostRecentJob is null)
                            return await CreateNewDesk(appId, staffId);
                        else
							staffDesks.Add(mostRecentJob);
                    }
                }

				var chosenDesk = staffDesks.OrderBy(x => x.LastJobDate).FirstOrDefault();
                return await CreateNewDesk(appId, chosenDesk.StaffID);
            }
            catch (Exception){ throw;}
        }

        public async Task<MyDesk> GetNextStaffDesk_EC(List<int> staffIds, int appId)
        {
            try
            {
                var staffDesks = new List<MyDesk>();

                foreach (var staffId in staffIds)
                {
                    var staff = await _unitOfWork.StaffRepository.GetStaffByIdWithSBU(staffId);          
                    var desk = await _unitOfWork.DeskRepository.GetDeskByStaffIdAppIdWithStaff(staffId, appId, true);
                    var deskHasNoWork = await _unitOfWork.DeskRepository.GetDeskByStaffIdAppIdWithStaff(staffId, appId, false);

                    var staffSBU = staff.StrategicBusinessUnit;
                    
                    //Check if the app on another role other than the wpa reviewer's desk
                    if(desk == null && staffSBU.Tier == PROCESS_TIER.TIER2)
                        desk = await _unitOfWork.DeskRepository.GetDeskByStaffTierAppIdWithStaffSBU(PROCESS_TIER.TIER2, appId, true);   

                    var mostRecentJob = (await _unitOfWork.DeskRepository.GetAsync((d) => d.StaffID == staffId && d.HasWork == true, (o) => o.OrderByDescending(x => x.LastJobDate))).ToList().FirstOrDefault();

                    if (desk != null)
                    {
						var res = new MyDesk
						{
							DeskID = -1,
							StaffID = staffId,
							AppId = appId,
						};

						return res; 
                    }
                    else if(deskHasNoWork != null)
                    {
                        return deskHasNoWork;
                    }
                    else
                    {
                        if (mostRecentJob == null)
                            return await CreateNewDesk(appId, staffId);
                        else
                            staffDesks.Add(mostRecentJob);
                    }
                }

                var chosenDesk = staffDesks.OrderBy(x => x.LastJobDate).FirstOrDefault();
                return await CreateNewDesk(appId, chosenDesk.StaffID);
            }
            catch (Exception) { throw; }
        }

        public async Task<MyDesk> UpdateDeskAfterPush(MyDesk desk, string? comment, string? processStatus)
		{
			try
			{
                desk.HasPushed = true;
                desk.HasWork = false;
                desk.UpdatedAt = DateTime.Now;
                desk.Comment = comment;
                desk.ProcessStatus = processStatus;

				await _unitOfWork.DeskRepository.Update(desk);
				await _unitOfWork.SaveChangesAsync();

				return desk;
            }
			catch (Exception)
			{
				throw;
			}
		}

        public async Task<MyDesk> UpdateDeskAfterReject(MyDesk desk, string? comment, string? processStatus)
        {
            try
            {
                desk.HasPushed = false;
                desk.HasWork = false;
                desk.UpdatedAt = DateTime.Now;
                desk.Comment = comment;
                desk.ProcessStatus = processStatus;

                await _unitOfWork.DeskRepository.Update(desk);
                await _unitOfWork.SaveChangesAsync();

                return desk;
            }
            catch (Exception){ throw; }
        }

        public async Task SaveApplicationHistory(int appId, int? staffId, string? status, string comment, string? selectedTables, bool? actionByCompany, int? companyId, string? action, bool? isPublic = false)
        {
            try
            {
                // var app = _dbContext.Applications.Where(x => x.Id == appId).FirstOrDefault();
                var app = await _unitOfWork.ApplicationRepository.GetAsync(appId);

                var appDeskHistory = new ApplicationDeskHistory()
                {
                    AppId = appId,
                    StaffID = staffId,
                    Comment = comment ?? "",
                    SelectedTables = selectedTables,
                    CreatedAt = DateTime.Now,
                    ActionDate = DateTime.Now,
                    ActionByCompany = actionByCompany,
                    CompanyId = companyId,
                    Status = status == null || status == "null" || status == ""? app.Status: status,
                    AppAction = action,
                    isPublic = isPublic,
                };

                await _unitOfWork.AppDeskHistoryRepository.AddAsync(appDeskHistory);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception){ throw; }
        }

        public async Task<ApplicationSBUApproval> UpdateApprovalTable(int appId, string? comment, int? staffId, int SBUID, int? deskId, string? processStatus)
        {
            try
            {
                var foundApproval = await _unitOfWork.AppSBUApprovalRepository.GetAsync((x) => x.AppId == appId && x.StaffID == staffId, null);

				if (foundApproval != null)
				{
					foundApproval.AppId = appId;
					foundApproval.StaffID = staffId;
                    foundApproval.SBUID = SBUID;
					foundApproval.Status = processStatus;
					foundApproval.Comment = comment;
					foundApproval.UpdatedDate = DateTime.Now;
					foundApproval.DeskID = deskId;

                    await _unitOfWork.AppSBUApprovalRepository.Update(foundApproval);
					await _unitOfWork.SaveChangesAsync();
                }
				else
				{
					var newApproval = new ApplicationSBUApproval()
					{
                        AppId = appId,
						StaffID = staffId,
						Status = processStatus,
						Comment = comment,
						UpdatedDate = DateTime.Now,
						DeskID = deskId
					};

                    await _unitOfWork.AppSBUApprovalRepository.AddAsync(newApproval);
                    await _unitOfWork.SaveChangesAsync();
                    return newApproval;
                }


                return foundApproval;
            }
            catch (Exception){ throw; }
        }

        public async Task<string> getTableNames(string[] tableIds)
        {
            try
            {
                string RejectedTables = "";
                if (tableIds.Count() > 0)
                {
                    foreach (var id in tableIds)
                    {
                        int tableID = id != "undefined" ? int.Parse(id) : 0;
                        var SBU_TablesToDisplay = await _unitOfWork.TableDetailRepository
                                                        .GetById(tableID);

                        if (SBU_TablesToDisplay is not null)
                            RejectedTables = RejectedTables != "" ? $"{RejectedTables}|{SBU_TablesToDisplay.TableSchema}" : SBU_TablesToDisplay.TableSchema;

                    }
                }

                return RejectedTables;
            }
            catch (Exception){ throw; }
        }

        private async Task<MyDesk> CreateNewDesk(int appId, int staffId)
        {
            var newDesk1 = new MyDesk
            {
                //save staff desk
                StaffID = staffId,
                AppId = appId,
                HasPushed = false,
                HasWork = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                //Comment="",
                LastJobDate = DateTime.Now,
            };

            await _unitOfWork.DeskRepository.AddAsync(newDesk1);
            await _unitOfWork.SaveChangesAsync();

            return newDesk1;
        }
    }
}