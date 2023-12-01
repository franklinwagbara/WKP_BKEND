using AutoMapper;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.Models;
// using Backend_UMR_Work_Program.Models.Enurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using WKP.Domain.Enums_Contants;
// using static Backend_UMR_Work_Program.Models.GeneralModel;

namespace Backend_UMR_Work_Program.Services
{
    public class HelperService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly WKP_DBContext _dbContext;
        IHttpContextAccessor _httpAccessor;
        IOptions<AppSettings> _appsettings;
        public readonly string BankName;
        public readonly string AccountNumber;
        public readonly string BankCode;
        public readonly string elpsBase;
        private readonly string _username;
        private readonly string _password;
        private readonly string _emailFrom;
        private readonly string _Host; 
        private readonly int _Port;

        public HelperService(
            IMapper mapper, 
            IConfiguration configuration, 
            WKP_DBContext dbContext, 
            IHttpContextAccessor httpAccessor,
            IOptions<AppSettings> appsettings
            )
        {
            _mapper = mapper;
            _config = configuration;
            _dbContext = dbContext;
            _httpAccessor = httpAccessor;
            _appsettings = appsettings;

            BankName = $"{_config.GetSection("Payment").GetSection("BankName").Value}";
            AccountNumber = $"{_config.GetSection("Payment").GetSection("Account").Value}";
            BankCode = $"{_config.GetSection("Payment").GetSection("BankCode").Value}";
            elpsBase = $"{_config.GetSection("Payment").GetSection("elpsBaseUrl").Value}";

            _password = _config.GetSection("SmtpSettings").GetSection("Password").Value.ToString();
            _username = _config.GetSection("SmtpSettings").GetSection("Username").Value.ToString();
            _emailFrom = _config.GetSection("SmtpSettings").GetSection("SenderEmail").Value.ToString();
            _Host = _config.GetSection("SmtpSettings").GetSection("Server").Value.ToString();
            _Port = Convert.ToInt16(_config.GetSection("SmtpSettings").GetSection("Port").Value.ToString());
        }

        public string Generate_Reference_Number()
        {
            lock (lockThis)
            {
                Thread.Sleep(1000);
                return DateTime.Now.ToString("MMddyyHHmmss");
            }
        }
        private Object lockThis = new object();

        public async void SaveApplicationHistory(int appId, int? staffId, string? status, string comment, string? selectedTables, bool? actionByCompany, int? companyId, string? action, bool? isPublic = false)
        {
            try
            {
                //var staff = await (from stf in _dbContext.staff where stf.StaffID == staffId select stf).FirstOrDefaultAsync();
                var app = _dbContext.Applications.Where(x => x.Id == appId).FirstOrDefault();

                var appDeskHistory = new ApplicationDeskHistory()
                {
                    AppId = appId,
                    StaffID = staffId,
                    Comment = comment == null ? "" : comment,
                    SelectedTables = selectedTables,
                    CreatedAt = DateTime.Now,
                    ActionDate = DateTime.Now,
                    ActionByCompany = actionByCompany,
                    CompanyId = companyId,
                    Status = status == null || status == "null" || status == ""? app.Status: status,
                    AppAction = action,
                    isPublic = isPublic,
                };

                _dbContext.ApplicationDeskHistories.Add(appDeskHistory);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object buildRemitaPayload(ADMIN_COMPANY_INFORMATION company, Application app, decimal amountNGN, string serviceCharge, string orderId)
        {
            try
            {
                var remita = new
                {
                    serviceTypeId = _config.GetSection("Payment").GetSection("serviceTypeId").Value,
                    categoryName = "WorkProgram",
                    totalAmount = $"{amountNGN}",
                    payerName = company.COMPANY_NAME,
                    payerEmail = company.EMAIL,
                    serviceCharge = serviceCharge,
                    amountDue = $"{amountNGN}",
                    orderId = $"{orderId}",
                    returnSuccessUrl = $"{_httpAccessor.HttpContext.Request.Scheme}://{_httpAccessor.HttpContext.Request.Host}/api/Payment/Remita",
                    returnFailureUrl = $"{_httpAccessor.HttpContext.Request.Scheme}://{_httpAccessor.HttpContext.Request.Host}/api/Payment/Remita",
                    returnBankPaymentUrl = $"{_httpAccessor.HttpContext.Request.Scheme}://{_httpAccessor.HttpContext.Request.Host}/api/Payment/Remita",
                    lineItems = new object[]
                    {
                        new
                        {
                            lineItemsId = "1",
                            beneficiaryName = BankName,
                            beneficiaryAccount = AccountNumber,
                            BankCode,
                            beneficiaryAmount = $"{amountNGN}",
                            deductFeeFrom = "1"
                        }
                    },
                    documentTypes = (string)null,
                    applicationItems = new object[]
                    {
                        new
                        {
                            name = "WorkProgramme",
                            description = $"Payment for {app.ReferenceNo}",
                            group = "Annual WorkProgramme Payment"
                        }
                    }
                };

                return remita;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<staff>> GetReviewerStaff(List<ApplicationProccess> applicationProccesses)
        {
            try
            {
                var staffLists = new List<staff>();
                foreach (var item in applicationProccesses)
                {
                    var staffs = await _dbContext.staff.Where(x => x.Staff_SBU == item.TargetedToSBU && x.RoleID == item.TargetedToRole).ToListAsync();

                    if (staffs.Count <= 0)
                    {
                        break;
                    }

                    var isFound = false;
                    var choosenStaff = staffs.Count > 0 ? staffs[0] : new staff();
                    var choosenDesk = new MyDesk()
                    {
                        LastJobDate = DateTime.Now,
                    };

                    foreach (var staff in staffs)
                    {
                        var desk = await _dbContext.MyDesks.Where<MyDesk>(d => d.StaffID == staff.StaffID && d.HasWork == true).OrderByDescending(d => d.LastJobDate).FirstOrDefaultAsync();

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
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int RecordStaffDesks(int appID, staff staff, int FromStaffID, int FromStaffSBU, int FromStaffRoleID, int processID, string status)
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
                _dbContext.MyDesks.Add(drop);

                if (_dbContext.SaveChanges() > 0)
                {
                    return 1;
                }

                return 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public List<AppMessage> GetMessage(int msg_id, int seid)
        {

            var message = (from m in _dbContext.Messages
                           join a in _dbContext.Applications on m.AppId equals a.Id
                           join cm in _dbContext.ADMIN_COMPANY_INFORMATIONs on a.CompanyID equals cm.Id
                           join ca in _dbContext.ApplicationCategories on a.CategoryID equals ca.Id
                           where m.id == msg_id
                           select new AppMessage
                           {
                               Subject = m.subject,
                               Content = m.content,
                               RefNo = a == null ? "" : a.ReferenceNo,
                               Status = a == null ? "" : a.Status,
                               Seen = m.read,
                               CompanyName = cm == null ? "" : cm.COMPANY_NAME,
                               CategoryName = ca.Name,
                               Field = "Field",
                               Concession = "Concession",
                               DateSubmitted = a.CreatedAt
                           });
            return message.ToList();
        }

        public List<AppMessage> SaveMessage(int appID, int userID, string subject, string content, string type)
        {

            Message messages = new Message()
            {
                companyID = type.Contains("ompany") ? userID : 0,
                staffID = userID,
                AppId = appID,
                subject = subject,
                content = content,
                //sender_id = userElpsID,
                read = 0,
                UserType = type,
                date = DateTime.UtcNow.AddHours(1)
            };
            _dbContext.Messages.Add(messages);
            _dbContext.SaveChanges();

            var msg = GetMessage(messages.id, userID);
            return msg;
        }

        public void LogMessages(string message, string user_id = null)
		{
			var auditTrail = new AuditTrail()
			{
				CreatedAt = DateTime.UtcNow,
				UserID = user_id,
				AuditAction = message
			};

			_dbContext.AuditTrails.Add(auditTrail);
			_dbContext.SaveChanges();

		}

        public string CompanyMessageTemplate(List<AppMessage> AppMessages)
		{
			var msg = AppMessages?.FirstOrDefault();
			string body = "<div>";

			body += "<div style='width: 800px; background-color: #ece8d4; padding: 5px 0 5px 0;'><img style='width: 98%; height: 120px; display: block; margin: 0 auto;' src='~/images/NUPRC Logo.JPG' alt='Logo'/></div>";
			body += "<div class='text-left' style='background-color: #ece8d4; width: 800px; min-height: 200px;'>";
			body += "<div style='padding: 10px 30px 30px 30px;'>";
			body += "<h5 style='text-align: center; font-weight: 300; padding-bottom: 10px; border-bottom: 1px solid #ddd;'>" + msg.Subject + "</h5>";
			body += "<p>Dear Sir/Madam,</p>";
			body += "<p style='line-height: 30px; text-align: justify;'>" + msg.Content + "</p>";
			body += "<p style='line-height: 30px; text-align: justify;'> Kindly find application details below.</p>";
			body += "<table style = 'width: 100%;'><tbody>";
			body += "<tr><td style='width: 200px;'><strong>Company Name:</strong></td><td> " + msg.CompanyName + " </td></tr>";
			body += "<tr><td style='width: 200px;'><strong>Year:</strong></td><td> " + msg.Year + " </td></tr>";
			body += "<tr><td style='width: 200px;'><strong>Concession:</strong></td><td> " + msg.Concession + " </td></tr>";
			body += "<tr><td style='width: 200px;'><strong>Field:</strong></td><td> " + msg.Field + " </td></tr>";
			body += "</tbody></table><br/>";

			body += "<p> </p>";
			body += "&copy; " + DateTime.Now.Year + "<p>  Powered by NUPRC Work Program Team. </p>";
			body += "<div style='padding:10px 0 10px; 10px; background-color:#888; color:#f9f9f9; width:800px;'> &copy; " + DateTime.UtcNow.AddHours(1).Year + " Nigerian Upstream Petroleum Regulatory Commission &minus; NUPRC Nigeria</div></div></div>";

			return body;
		}

        public string SendEmailMessage(string email_to, string email_to_name, List<AppMessage> AppMessages, byte[] attach)
        {
            var result = "";
            var msgBody = CompanyMessageTemplate(AppMessages);

            MailMessage _mail = new MailMessage();
            SmtpClient client = new SmtpClient(_Host, _Port);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential(_username, _password);
            _mail.From = new MailAddress(_emailFrom);
            _mail.To.Add(new MailAddress(email_to, email_to_name));
            _mail.Subject = AppMessages.FirstOrDefault().Subject.ToString();
            _mail.IsBodyHtml = true;
            _mail.Body = msgBody;
            if (attach != null)
            {
                string name = "App Letter";
                Attachment at = new Attachment(new MemoryStream(attach), name);
                _mail.Attachments.Add(at);
            }
            //_mail.CC=
            try
            {
                client.Send(_mail);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        public string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public async Task<Application> AddNewApplication(int companyId, string companyEmail, int year, int concessionId, int? fieldId, string? status, string? paymentStatus, int? currentDeskID, bool? submitted)
        {
            try
            {
                Application application = new Application();
                application.ReferenceNo = Generate_Reference_Number();
                application.YearOfWKP = year;
                application.ConcessionID = concessionId;
                application.FieldID = fieldId ?? null;
                application.CompanyID = companyId;
                application.CurrentUserEmail = companyEmail;
                application.CategoryID = _dbContext.ApplicationCategories.Where(x => x.Name == APP_CATEGORIES.New).FirstOrDefault().Id;
                application.Status = status ?? MAIN_APPLICATION_STATUS.NotSubmitted;
                application.PaymentStatus = paymentStatus ?? PAYMENT_STATUS.PaymentPending;
                application.CurrentDesk = currentDeskID ?? null; //to change
                application.Submitted = submitted ?? false;
                application.CreatedAt = DateTime.Now;
                application.SubmittedAt = submitted == true ? DateTime.Now : null;

                await _dbContext.Applications.AddAsync(application);
                await _dbContext.SaveChangesAsync();

                return application;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<ApplicationProccess>> GetApplicationProccessBySBUAndRole(string processAction, int triggeredByRole = 0, int triggeredBySBU = 0)
		{
			try
			{
				return await _dbContext.ApplicationProccesses.Where(x => x.TriggeredByRole==triggeredByRole && x.TriggeredBySBU==triggeredBySBU && x.ProcessAction==processAction && x.DeleteStatus !=true).ToListAsync();
			}
			catch (Exception e)
			{
				throw e;
			}
		}

        
        public async Task<List<int>> GetStaffByTargetRoleAndSBU(int targetedToRole, int targetedToSBU)
		{
			try
			{
				return await _dbContext.staff.Where(x => x.RoleID==targetedToRole && x.Staff_SBU==targetedToSBU && x.DeleteStatus !=true).Select(x => x.StaffID).ToListAsync();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public async Task<MyDesk> GetNextStaffDesk(List<int> staffIds, int appId)
        {
            try
            {
                var staffDesks = new List<MyDesk>();

                foreach (var staffId in staffIds)
                {
                    var deskAlreadyExist = await _dbContext.MyDesks.Where(x => x.StaffID == staffId && x.AppId == appId && x.HasWork == true).FirstOrDefaultAsync();
                    var deskHasNoWork = await _dbContext.MyDesks.Where(x => x.StaffID == staffId && x.AppId == appId && x.HasWork == false).FirstOrDefaultAsync();
					//var mostRecentJob = await _dbContext.MyDesks.Where(x => x.StaffID == staffId && x.HasWork == true).OrderByDescending(x => x.LastJobDate).FirstOrDefaultAsync();
					var mostRecentJob = await _dbContext.MyDesks.Where(x => x.StaffID == staffId).OrderByDescending(x => x.LastJobDate).FirstOrDefaultAsync();

                    if (deskAlreadyExist != null)
                    {
                        throw new Exception("This application has already been push to this desk.");
                    }
                    else if (deskHasNoWork != null)
                    {
                        return deskHasNoWork;
                    }
                    else
                    {
						if(mostRecentJob == null)
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

                            await _dbContext.MyDesks.AddAsync(newDesk1);
                            await _dbContext.SaveChangesAsync();

                            return newDesk1;
                        }
						else
						{
							staffDesks.Add(mostRecentJob);
						}
                    }
                }

				var chosenDesk = staffDesks.OrderBy(x => x.LastJobDate).FirstOrDefault();
                
				var newDesk = new MyDesk
                {
                    //save staff desk
                    StaffID = chosenDesk.StaffID,
                    AppId = appId,
                    HasPushed = false,
                    HasWork = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    //Comment="",
                    LastJobDate = DateTime.Now,
                };

                _dbContext.MyDesks.Add(newDesk);
                
				await _dbContext.SaveChangesAsync();

                return newDesk;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<MyDesk> GetNextStaffDesk_EC(List<int> staffIds, int appId)
        {
            try
            {
                var staffDesks = new List<MyDesk>();

                foreach (var staffId in staffIds)
                {
                    var staff = await _dbContext.staff.Include(x => x.StrategicBusinessUnit).Where(x => x.StaffID == staffId).FirstOrDefaultAsync();                 
                    var desk = await _dbContext.MyDesks.Include(x => x.Staff).Where(x => x.StaffID == staffId && x.AppId == appId && x.HasWork==true).FirstOrDefaultAsync();
                    var deskHasNoWork = await _dbContext.MyDesks.Where(x => x.StaffID == staffId && x.AppId == appId && x.HasWork == false).FirstOrDefaultAsync();

                    var staffSBU = staff.StrategicBusinessUnit;
                    
                    //Check if the app on another role other than the wpa reviewer's desk
                    if(desk == null && staffSBU.Tier == PROCESS_TIER.TIER2)
                        desk = await _dbContext.MyDesks.Include(x => x.Staff).ThenInclude(s => s.StrategicBusinessUnit).
                            Where(x => x.AppId == appId && x.Staff.StrategicBusinessUnit.Tier == PROCESS_TIER.TIER2 && x.HasWork == true).FirstOrDefaultAsync();

                    var mostRecentJob = await _dbContext.MyDesks.Where(x => x.StaffID == staffId && x.HasWork == true).OrderByDescending(x => x.LastJobDate).FirstOrDefaultAsync();

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
                        {
                            var tempDesk = new MyDesk
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

                            await _dbContext.MyDesks.AddAsync(tempDesk);

                            await _dbContext.SaveChangesAsync();

                            return tempDesk;
                        }
                        else
                        {
                            staffDesks.Add(mostRecentJob);
                        }
                    }
                }

                var chosenDesk = staffDesks.OrderBy(x => x.LastJobDate).FirstOrDefault();

                var newDesk = new MyDesk
                {
                    //save staff desk
                    StaffID = chosenDesk.StaffID,
                    AppId = appId,
                    HasPushed = false,
                    HasWork = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    //Comment="",
                    LastJobDate = DateTime.Now,
                };

                await _dbContext.MyDesks.AddAsync(newDesk);

                await _dbContext.SaveChangesAsync();

                return newDesk;
            }
            catch (Exception ex)
            {

                throw ex;
            }
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

				_dbContext.MyDesks.Update(desk);
				await _dbContext.SaveChangesAsync();

				return desk;
            }
			catch (Exception ex)
			{

				throw ex;
			}
		}

        public async Task<ApplicationSBUApproval> UpdateApprovalTable(int appId, string? comment, int? staffId, int SBUID, int? deskId, string? processStatus)
        {
            try
            {
        		var foundApproval = _dbContext.ApplicationSBUApprovals.Where(x => x.AppId == appId && x.StaffID == staffId).FirstOrDefault();

				if (foundApproval != null)
				{
					foundApproval.AppId = appId;
					foundApproval.StaffID = staffId;
                    foundApproval.SBUID = SBUID;
					foundApproval.Status = processStatus;
					foundApproval.Comment = comment;
					foundApproval.UpdatedDate = DateTime.Now;
					foundApproval.DeskID = deskId;

					_dbContext.ApplicationSBUApprovals.Update(foundApproval);
                    _dbContext.SaveChanges();
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

                    _dbContext.ApplicationSBUApprovals.Add(newApproval);
                    _dbContext.SaveChanges();

                    return newApproval;
                }


                return foundApproval;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<string> GetListOfIncomingDeskStatuses()
            => new List<string> {
                DESK_PROCESS_STATUS.FinalAuthorityApproved,
                DESK_PROCESS_STATUS.SubmittedByCompany,
                DESK_PROCESS_STATUS.SubmittedByStaff
            };

        public bool IsIncomingDeskStatus(string status) => GetListOfIncomingDeskStatuses().Contains(status);

        //public string GetActionCommentByRole(string role)
        //{
        //    var 
        //    if(role == GeneralModel.ROLE.Reviewer) 
        //}

        public async Task<AccountDesk> GetNextAccountDesk()
        {
            var accountantRole = await _dbContext.Roles.Where(x => x.RoleName == ROLEID.Accountant).FirstOrDefaultAsync();

            //Get all the account staffs
            var accountStaffs = await _dbContext.staff.Where(x => x.RoleID == accountantRole.id).ToListAsync();
            // var desks = await _dbContext.AccountDesks.OrderBy(x => x.LastJobDate).ToListAsync();

            var deskGroups = _dbContext.AccountDesks
                            .GroupBy(x => x.StaffID)
                            .Select(group => new
                            {
                                StaffID = group.Key,
                                AccountDesks = group.OrderBy(x => x.LastJobDate).ToList()
                            })
                            .AsEnumerable()
                            .OrderBy(group => group.AccountDesks.LastOrDefault()?.LastJobDate)
                            .ToList();

            var newDesk = new AccountDesk
            {
                CreatedAt = DateTime.Now,
            };

            if(deskGroups.Count < accountStaffs.Count)
            {
                foreach(var staff in accountStaffs)
                {
                    if(!deskGroups.Any(x => x.StaffID == staff.StaffID))
                    {
                        newDesk.StaffID = staff.StaffID;
                        return newDesk;
                    }
                }

                throw new Exception("Unable to process payment evidence request: Could not find an accounts desk.");
            }
            else
            {
                if(deskGroups.Count == 0)
                {
                    newDesk.StaffID = accountStaffs.FirstOrDefault().StaffID;
                    return newDesk;
                }
                else
                {
                    newDesk.StaffID = deskGroups.FirstOrDefault().StaffID;
                    return newDesk;
                }
            }
        }

        public async Task<int> DeleteDeskByDeskId(int deskId)
        {
            try
            {
                var getDesk = _dbContext.MyDesks.Where(x => x.DeskID == deskId).FirstOrDefault();
                if (getDesk != null)
                {

                    _dbContext.MyDesks.Remove(getDesk);
                    var save = await _dbContext.SaveChangesAsync();

                    if (save > 0)
                    {
                        return 1;
                    }

                }
                return 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int[] ParseSBUIDs(string[] SBU_IDs) {
            try
            {
                var SBU_IDs_int = new int[SBU_IDs.Length];

                var tempSBUs = new List<string>();
                foreach (string s in SBU_IDs)
                {
                    if (s != null && s != "undefined")
                    {
                        tempSBUs.Add(s);
                    }
                }

                if (tempSBUs.Count > 0)
                {
                    for (int i = 0; i < tempSBUs.Count; i++)
                    {
                        SBU_IDs_int[i] = int.Parse(tempSBUs[i]);
                    }
                }
                else
                {
                    SBU_IDs_int = null;
                }

                return SBU_IDs_int;
            }
            catch (Exception e)
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

                _dbContext.MyDesks.Update(desk);

                return desk;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public double TryParseDouble(string value)
        {
            double newVal;

            if (double.TryParse(value, out newVal))
                return newVal;
            else return 0.0;
        }
    }
}
