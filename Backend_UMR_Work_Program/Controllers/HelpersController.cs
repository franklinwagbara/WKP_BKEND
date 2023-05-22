//using Backend_UMR_Work_Program.BusinessLogic.IRepository;
using AutoMapper;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.Helpers;
using Backend_UMR_Work_Program.Models;
using Backend_UMR_Work_Program.Models.Enurations;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
//using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using static Backend_UMR_Work_Program.Models.GeneralModel;

namespace Backend_UMR_Work_Program.Controllers
{
	public class HelpersController : Controller
	{
		public IConfiguration _configuration;
		public WKP_DBContext _context;
		IHttpContextAccessor _httpContextAccessor;
		private readonly IMapper _mapper;
		RestSharpServices restSharpServices = new RestSharpServices();

		public HelpersController(WKP_DBContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IMapper mapper)
		{
			_mapper = mapper;
			_context = context;
			_configuration = configuration;
			_httpContextAccessor = httpContextAccessor;

		}
		private string? WKPUserId => User.FindFirstValue(ClaimTypes.NameIdentifier);
		private string? WKPUserName => User.FindFirstValue(ClaimTypes.Name);
		private string? WKPUserEmail => User.FindFirstValue(ClaimTypes.Email);
		private string? WKUserRole => User.FindFirstValue(ClaimTypes.Role);

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

		public string Decrypt(string cipherText)
		{
			string EncryptionKey = "MAKV2SPBNI99212";
			byte[] cipherBytes = Convert.FromBase64String(cipherText);
			using (Aes encryptor = Aes.Create())
			{
				Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
				encryptor.Key = pdb.GetBytes(32);
				encryptor.IV = pdb.GetBytes(16);
				using (MemoryStream ms = new MemoryStream())
				{
					using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
					{
						cs.Write(cipherBytes, 0, cipherBytes.Length);
						cs.Close();
					}
					cipherText = Encoding.Unicode.GetString(ms.ToArray());
				}
			}
			return cipherText;
		}
		public UploadedDocument UploadDocument(IFormFile document, string folderToSave)
		{
			var document_uniqueFileName = "";
			var document_FileExtension = "";
			var document_newFileName = "";
			var document_documentPath = "";
			var document_fileName = "";
			try
			{
				//For image cover
				if (document != null)
				{
					if (document.Length > 0)
					{

						var up = Path.Combine(Directory.GetCurrentDirectory(), folderToSave);
						string datetime = DateTime.Now.ToString("ddMMyyyy_HHmmss");

						//var docName = ContentDispositionHeaderValue.Parse(document.ContentDisposition).FileName.Trim();
						//FileExtension = Path.GetExtension(docName).ToString().Replace("\n", ''');

						var uploads = Path.Combine(up, folderToSave);
						document_fileName = document.FileName.Split(".")[0].Trim();
						document_uniqueFileName = Convert.ToString(Guid.NewGuid());
						document_FileExtension = document.FileName.Split(".")[1].Trim();
						//newFileName = uniqueFileName + FileExtension;
						document_newFileName = document_fileName +"_"+datetime+ "." + document_FileExtension;

						// store path of folder in database
						document_documentPath = "//Documents/" + folderToSave + "/" + document_newFileName;
						using (var s = new FileStream(Path.Combine(uploads, document_newFileName),
							 FileMode.Create))
						{
							document.CopyTo(s);
						}

					}
					var uploadedDoc = new UploadedDocument()
					{
						fileName = document_fileName,
						filePath = document_documentPath
					};
					return uploadedDoc;
				}
				return null;
			}
			catch (Exception ex)
			{
				return null;

			}
		}
		#region database tables actions

		[HttpPost]
		public WebApiResponse CONCESSION_SITUATION(CONCESSION_SITUATION_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var ConcessionData = new CONCESSION_SITUATION();
			action = action == null ? GeneralModel.Insert : action;

			try
			{
				#region Saving Concession Situations
				var getConcessionData = (from c in _context.CONCESSION_SITUATIONs where c.COMPANY_ID == WKPUserId && c.Year == WorkProgramme_Year select c).FirstOrDefault();
				ConcessionData = getConcessionData != null ? getConcessionData : ConcessionData;
				ConcessionData = _mapper.Map<CONCESSION_SITUATION>(wkp);

				ConcessionData.Companyemail = WKPUserEmail;
				ConcessionData.CompanyName = WKPUserName;
				ConcessionData.COMPANY_ID = WKPUserId;
				ConcessionData.Date_Updated = DateTime.Now;
				ConcessionData.Updated_by = WKPUserId;
				ConcessionData.Year = WorkProgramme_Year;
				if (getConcessionData == null)
				{
					ConcessionData.Created_by = WKPUserId;
					ConcessionData.Date_Created = DateTime.Now;
					_context.CONCESSION_SITUATIONs.AddAsync(ConcessionData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.CONCESSION_SITUATIONs.Remove(ConcessionData);
				}
				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse GEOPHYSICAL_ACTIVITIES_ACQUISITION(GEOPHYSICAL_ACTIVITIES_ACQUISITION_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var GeophysicalActivitesData = new GEOPHYSICAL_ACTIVITIES_ACQUISITION();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Geophysical Activites

				var getGeophysicalActivitesData = (from c in _context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				GeophysicalActivitesData = getGeophysicalActivitesData != null ? getGeophysicalActivitesData : GeophysicalActivitesData;
				GeophysicalActivitesData = _mapper.Map<GEOPHYSICAL_ACTIVITIES_ACQUISITION>(wkp);

				GeophysicalActivitesData.Companyemail = WKPUserEmail;
				GeophysicalActivitesData.CompanyName = WKPUserName;
				GeophysicalActivitesData.COMPANY_ID = WKPUserId;
				GeophysicalActivitesData.Date_Updated = DateTime.Now;
				GeophysicalActivitesData.Updated_by = WKPUserId;
				GeophysicalActivitesData.Year_of_WP = WorkProgramme_Year;
				if (getGeophysicalActivitesData == null)
				{
					GeophysicalActivitesData.Date_Created = DateTime.Now;
					GeophysicalActivitesData.Created_by = WKPUserId;
					_context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs.AddAsync(GeophysicalActivitesData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.GEOPHYSICAL_ACTIVITIES_ACQUISITIONs.Remove(GeophysicalActivitesData);
				}

				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse GEOPHYSICAL_ACTIVITIES_PROCESSING(GEOPHYSICAL_ACTIVITIES_PROCESSING_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var GeoActivitesProcessingData = new GEOPHYSICAL_ACTIVITIES_PROCESSING();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Geophysical Activites Processing

				var getGeoActivitesProcessingData = (from c in _context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				GeoActivitesProcessingData = getGeoActivitesProcessingData != null ? getGeoActivitesProcessingData : GeoActivitesProcessingData;
				GeoActivitesProcessingData = _mapper.Map<GEOPHYSICAL_ACTIVITIES_PROCESSING>(wkp);

				GeoActivitesProcessingData.Companyemail = WKPUserEmail;
				GeoActivitesProcessingData.CompanyName = WKPUserName;
				GeoActivitesProcessingData.COMPANY_ID = WKPUserId;
				GeoActivitesProcessingData.Date_Updated = DateTime.Now;
				GeoActivitesProcessingData.Updated_by = WKPUserId;
				GeoActivitesProcessingData.Year_of_WP = WorkProgramme_Year;
				if (getGeoActivitesProcessingData == null)
				{
					GeoActivitesProcessingData.Created_by = WKPUserId;
					GeoActivitesProcessingData.Date_Created = DateTime.Now;
					_context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs.AddAsync(GeoActivitesProcessingData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.GEOPHYSICAL_ACTIVITIES_PROCESSINGs.Remove(GeoActivitesProcessingData);
				}

				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse DRILLING_OPERATIONS_CATEGORIES_OF_WELL(DRILLING_OPERATIONS_CATEGORIES_OF_WELL_Model wkp, string WorkProgramme_Year, List<IFormFile> files, string action = null)
		{

			int save = 0;
			var DrillingOperationsData = new DRILLING_OPERATIONS_CATEGORIES_OF_WELL();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Drilling Operations

				var getDrillingOperationsData = (from c in _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				DrillingOperationsData = getDrillingOperationsData != null ? getDrillingOperationsData : DrillingOperationsData;
				DrillingOperationsData = _mapper.Map<DRILLING_OPERATIONS_CATEGORIES_OF_WELL>(wkp);

				#region file section
				UploadedDocument FieldDiscoveryUploadFile_File = null;
				UploadedDocument HydrocarbonCountUploadFile_File = null;

				if (files[0] != null)
				{
					string docName = "Field Discovery";
					FieldDiscoveryUploadFile_File = UploadDocument(files[0], "FieldDiscoveryDocuments");
					if (FieldDiscoveryUploadFile_File == null)
						return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to uploading " + docName + " document.", StatusCode = ResponseCodes.Success };

				}
				if (files[1] != null)
				{
					string docName = "Hydrocarbon Count";
					HydrocarbonCountUploadFile_File = UploadDocument(files[1], "HydrocarbonCountDocuments");
					if (HydrocarbonCountUploadFile_File == null)
						return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to uploading " + docName + " document.", StatusCode = ResponseCodes.Success };

				}
				#endregion

				DrillingOperationsData.FieldDiscoveryUploadFilePath = files[0] != null ? FieldDiscoveryUploadFile_File.filePath : null;
				DrillingOperationsData.HydrocarbonCountUploadFilePath = files[1] != null ? HydrocarbonCountUploadFile_File.filePath : null;

				DrillingOperationsData.Companyemail = WKPUserEmail;
				DrillingOperationsData.CompanyName = WKPUserName;
				DrillingOperationsData.COMPANY_ID = WKPUserId;
				DrillingOperationsData.Date_Updated = DateTime.Now;
				DrillingOperationsData.Updated_by = WKPUserId;
				DrillingOperationsData.Year_of_WP = WorkProgramme_Year;
				if (DrillingOperationsData == null)
				{
					DrillingOperationsData.Date_Created = DateTime.Now;
					DrillingOperationsData.Created_by = WKPUserId;
					_context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.AddAsync(DrillingOperationsData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Remove(DrillingOperationsData);
				}

				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse DRILLING_EACH_WELL_COST(DRILLING_EACH_WELL_COST_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var DrillingData = new DRILLING_OPERATIONS_CATEGORIES_OF_WELL();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Drilling Operations

				var getDrillingData = (from c in _context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				DrillingData = getDrillingData != null ? getDrillingData : DrillingData;
				DrillingData = _mapper.Map<DRILLING_OPERATIONS_CATEGORIES_OF_WELL>(wkp);

				DrillingData.Companyemail = WKPUserEmail;
				DrillingData.CompanyName = WKPUserName;
				DrillingData.COMPANY_ID = WKPUserId;
				DrillingData.Date_Updated = DateTime.Now;
				DrillingData.Updated_by = WKPUserId;
				DrillingData.Year_of_WP = WorkProgramme_Year;
				if (DrillingData == null)
				{
					DrillingData.Date_Created = DateTime.Now;
					DrillingData.Created_by = WKPUserId;
					_context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.AddAsync(DrillingData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.DRILLING_OPERATIONS_CATEGORIES_OF_WELLs.Remove(DrillingData);
				}

				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse DRILLING_EACH_WELL_COST_PROPOSED(DRILLING_EACH_WELL_COST_PROPOSED_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var DrillingData = new DRILLING_EACH_WELL_COST_PROPOSED();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Drilling Operations

				var getDrillingData = (from c in _context.DRILLING_EACH_WELL_COST_PROPOSEDs where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				DrillingData = getDrillingData != null ? getDrillingData : DrillingData;
				DrillingData = _mapper.Map<DRILLING_EACH_WELL_COST_PROPOSED>(wkp);

				DrillingData.Companyemail = WKPUserEmail;
				DrillingData.CompanyName = WKPUserName;
				DrillingData.COMPANY_ID = WKPUserId;
				DrillingData.Date_Updated = DateTime.Now;
				DrillingData.Updated_by = WKPUserId;
				DrillingData.Year_of_WP = WorkProgramme_Year;
				if (DrillingData == null)
				{
					DrillingData.Date_Created = DateTime.Now;
					DrillingData.Created_by = WKPUserId;
					_context.DRILLING_EACH_WELL_COST_PROPOSEDs.AddAsync(DrillingData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.DRILLING_EACH_WELL_COST_PROPOSEDs.Remove(DrillingData);
				}

				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse INITIAL_WELL_COMPLETION_JOB1(INITIAL_WELL_COMPLETION_JOB1_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var Well_Completion_JobData = new INITIAL_WELL_COMPLETION_JOB1();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Well_Completion_JobData
				var getWell_Completion_JobData = (from c in _context.INITIAL_WELL_COMPLETION_JOBs1 where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				Well_Completion_JobData = getWell_Completion_JobData != null ? getWell_Completion_JobData : Well_Completion_JobData;
				Well_Completion_JobData = _mapper.Map<INITIAL_WELL_COMPLETION_JOB1>(wkp);

				Well_Completion_JobData.Companyemail = WKPUserEmail;
				Well_Completion_JobData.CompanyName = WKPUserName;
				Well_Completion_JobData.COMPANY_ID = WKPUserId;
				Well_Completion_JobData.Date_Updated = DateTime.Now;
				Well_Completion_JobData.Updated_by = WKPUserId;
				Well_Completion_JobData.Year_of_WP = WorkProgramme_Year;
				if (getWell_Completion_JobData == null)
				{
					Well_Completion_JobData.Created_by = WKPUserId;
					Well_Completion_JobData.Date_Created = DateTime.Now;
					_context.INITIAL_WELL_COMPLETION_JOBs1.AddAsync(Well_Completion_JobData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.INITIAL_WELL_COMPLETION_JOBs1.Remove(Well_Completion_JobData);
				}

				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse WORKOVERS_RECOMPLETION_JOB1(WORKOVERS_RECOMPLETION_JOB1_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var Workover_JobData = new WORKOVERS_RECOMPLETION_JOB1();
			action = action == null ? GeneralModel.Insert : action;

			try
			{
				#region Saving Workover_JobData
				var getWorkover_JobData = (from c in _context.WORKOVERS_RECOMPLETION_JOBs1 where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				Workover_JobData = getWorkover_JobData != null ? getWorkover_JobData : Workover_JobData;
				Workover_JobData = _mapper.Map<WORKOVERS_RECOMPLETION_JOB1>(wkp);

				Workover_JobData.Companyemail = WKPUserEmail;
				Workover_JobData.CompanyName = WKPUserName;
				Workover_JobData.COMPANY_ID = WKPUserId;
				Workover_JobData.Date_Updated = DateTime.Now;
				Workover_JobData.Updated_by = WKPUserId;
				Workover_JobData.Year_of_WP = WorkProgramme_Year;
				if (getWorkover_JobData == null)
				{
					Workover_JobData.Created_by = WKPUserId;
					Workover_JobData.Date_Created = DateTime.Now;
					_context.WORKOVERS_RECOMPLETION_JOBs1.Add(Workover_JobData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.WORKOVERS_RECOMPLETION_JOBs1.Remove(Workover_JobData);
				}
				save += _context.SaveChanges();
				#endregion


				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVE(FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERf_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var FDP_ExcessReserveData = new FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERf();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Well_Completion_JobData
				var getFDP_ExcessReserveData = (from c in _context.FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVEs where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				FDP_ExcessReserveData = getFDP_ExcessReserveData != null ? getFDP_ExcessReserveData : FDP_ExcessReserveData;
				FDP_ExcessReserveData = _mapper.Map<FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERf>(wkp);

				FDP_ExcessReserveData.Companyemail = WKPUserEmail;
				FDP_ExcessReserveData.CompanyName = WKPUserName;
				FDP_ExcessReserveData.COMPANY_ID = WKPUserId;
				FDP_ExcessReserveData.Date_Updated = DateTime.Now;
				FDP_ExcessReserveData.Updated_by = WKPUserId;
				FDP_ExcessReserveData.Year_of_WP = WorkProgramme_Year;
				if (getFDP_ExcessReserveData == null)
				{
					FDP_ExcessReserveData.Created_by = WKPUserId;
					FDP_ExcessReserveData.Date_Created = DateTime.Now;
					_context.FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVEs.AddAsync(FDP_ExcessReserveData);
				}

				else if (action == GeneralModel.Delete)
				{
					_context.FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVEs.Remove(FDP_ExcessReserveData);
				}

				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDP(FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDP_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var FDP_ToSubmitData = new FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDP();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving FDP_ToSubmitData
				var getFDP_ToSubmitData = (from c in _context.FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDPs where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				FDP_ToSubmitData = getFDP_ToSubmitData != null ? getFDP_ToSubmitData : FDP_ToSubmitData;
				FDP_ToSubmitData = _mapper.Map<FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDP>(wkp);

				FDP_ToSubmitData.Companyemail = WKPUserEmail;
				FDP_ToSubmitData.CompanyName = WKPUserName;
				FDP_ToSubmitData.COMPANY_ID = WKPUserId;
				FDP_ToSubmitData.Date_Updated = DateTime.Now;
				FDP_ToSubmitData.Updated_by = WKPUserId;
				FDP_ToSubmitData.Year_of_WP = WorkProgramme_Year;
				if (getFDP_ToSubmitData == null)
				{
					FDP_ToSubmitData.Created_by = WKPUserId;
					FDP_ToSubmitData.Date_Created = DateTime.Now;
					_context.FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDPs.AddAsync(FDP_ToSubmitData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDPs.Remove(FDP_ToSubmitData);
				}


				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse FIELD_DEVELOPMENT_FIELDS_AND_STATUS(FIELD_DEVELOPMENT_FIELDS_AND_STATUS_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var FDP_StatusData = new FIELD_DEVELOPMENT_FIELDS_AND_STATUS();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving FDP_StatusData
				var getFDP_StatusData = (from c in _context.FIELD_DEVELOPMENT_FIELDS_AND_STATUSes where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				FDP_StatusData = getFDP_StatusData != null ? getFDP_StatusData : FDP_StatusData;
				FDP_StatusData = _mapper.Map<FIELD_DEVELOPMENT_FIELDS_AND_STATUS>(wkp);

				FDP_StatusData.Companyemail = WKPUserEmail;
				FDP_StatusData.CompanyName = WKPUserName;
				FDP_StatusData.COMPANY_ID = WKPUserId;
				FDP_StatusData.Date_Updated = DateTime.Now;
				FDP_StatusData.Updated_by = WKPUserId;
				FDP_StatusData.Year_of_WP = WorkProgramme_Year;
				if (getFDP_StatusData == null)
				{
					FDP_StatusData.Created_by = WKPUserId;
					FDP_StatusData.Date_Created = DateTime.Now;
					_context.FIELD_DEVELOPMENT_FIELDS_AND_STATUSes.AddAsync(FDP_StatusData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.FIELD_DEVELOPMENT_FIELDS_AND_STATUSes.Remove(FDP_StatusData);
				}
				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse RESERVES_UPDATES_LIFE_INDEX(RESERVES_UPDATES_LIFE_INDEX_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var Reserve_UpdateData = new RESERVES_UPDATES_LIFE_INDEX();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Reserve_UpdateData
				var getReserve_UpdateData = (from c in _context.RESERVES_UPDATES_LIFE_INDices where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				Reserve_UpdateData = getReserve_UpdateData != null ? getReserve_UpdateData : Reserve_UpdateData;
				Reserve_UpdateData = _mapper.Map<RESERVES_UPDATES_LIFE_INDEX>(wkp);

				Reserve_UpdateData.Companyemail = WKPUserEmail;
				Reserve_UpdateData.CompanyName = WKPUserName;
				Reserve_UpdateData.COMPANY_ID = WKPUserId;
				Reserve_UpdateData.Date_Updated = DateTime.Now;
				Reserve_UpdateData.Updated_by = WKPUserId;
				Reserve_UpdateData.Year_of_WP = WorkProgramme_Year;
				if (getReserve_UpdateData == null)
				{
					Reserve_UpdateData.Created_by = WKPUserId;
					Reserve_UpdateData.Date_Created = DateTime.Now;
					_context.RESERVES_UPDATES_LIFE_INDices.AddAsync(Reserve_UpdateData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.RESERVES_UPDATES_LIFE_INDices.Remove(Reserve_UpdateData);
				}

				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse FIELD_DEVELOPMENT_PLAN(FIELD_DEVELOPMENT_PLAN_Model wkp, string WorkProgramme_Year, List<IFormFile> files, string action = null)
		{

			int save = 0;
			var FDP_Data = new FIELD_DEVELOPMENT_PLAN();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving FDP_Data
				var getFDP_Data = (from c in _context.FIELD_DEVELOPMENT_PLANs where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				FDP_Data = getFDP_Data != null ? getFDP_Data : FDP_Data;
				FDP_Data = _mapper.Map<FIELD_DEVELOPMENT_PLAN>(wkp);

				#region file section
				UploadedDocument approved_FDP_Document = null;

				if (files[0] != null)
				{
					string docName = "Approved FDP";
					approved_FDP_Document = UploadDocument(files[0], "FDPDocuments");
					if (approved_FDP_Document == null)
						return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to uploading " + docName + " document.", StatusCode = ResponseCodes.Success };

				}
				#endregion

				FDP_Data.Uploaded_approved_FDP_Document = files[0] != null ? approved_FDP_Document.filePath : null;
				FDP_Data.FDPDocumentFilename = files[0] != null ? approved_FDP_Document.fileName : null;
				FDP_Data.Companyemail = WKPUserEmail;
				FDP_Data.CompanyName = WKPUserName;
				FDP_Data.COMPANY_ID = WKPUserId;
				FDP_Data.Date_Updated = DateTime.Now;
				FDP_Data.Updated_by = WKPUserId;
				FDP_Data.Year_of_WP = WorkProgramme_Year;
				if (getFDP_Data == null)
				{
					FDP_Data.Created_by = WKPUserId;
					FDP_Data.Date_Created = DateTime.Now;
					_context.FIELD_DEVELOPMENT_PLANs.AddAsync(FDP_Data);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.FIELD_DEVELOPMENT_PLANs.Remove(FDP_Data);
				}
				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse OIL_CONDENSATE_PRODUCTION_ACTIVITy(OIL_CONDENSATE_PRODUCTION_ACTIVITy_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var Oil_ProductionData = new OIL_CONDENSATE_PRODUCTION_ACTIVITy();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Oil_ProductionData
				var getOil_ProductionData = (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				Oil_ProductionData = getOil_ProductionData != null ? getOil_ProductionData : Oil_ProductionData;
				Oil_ProductionData = _mapper.Map<OIL_CONDENSATE_PRODUCTION_ACTIVITy>(wkp);

				Oil_ProductionData.Companyemail = WKPUserEmail;
				Oil_ProductionData.CompanyName = WKPUserName;
				Oil_ProductionData.COMPANY_ID = WKPUserId;
				Oil_ProductionData.Date_Updated = DateTime.Now;
				Oil_ProductionData.Updated_by = WKPUserId;
				Oil_ProductionData.Year_of_WP = DateTime.Now.Year.ToString();
				if (getOil_ProductionData == null)
				{
					Oil_ProductionData.Created_by = WKPUserId;
					Oil_ProductionData.Date_Created = DateTime.Now;
					_context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs.AddAsync(Oil_ProductionData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.OIL_CONDENSATE_PRODUCTION_ACTIVITIEs.Remove(Oil_ProductionData);
				}

				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATION(OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATION_Model wkp, string WorkProgramme_Year, List<IFormFile> files, string action = null)
		{

			int save = 0;
			var Oil_UnitizationData = new OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATION();
			action = action == null ? GeneralModel.Insert : action;

			try
			{


				#region Saving Oil_UnitizationData
				var getOil_UnitizationData = (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATIONs where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				Oil_UnitizationData = getOil_UnitizationData != null ? getOil_UnitizationData : Oil_UnitizationData;
				Oil_UnitizationData = _mapper.Map<OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATION>(wkp);
				#region file section
				UploadedDocument PUAUploadFile = null;
				UploadedDocument UUOAUploadFile = null;

				if (files[0] != null)
				{
					string docName = "PUA";
					PUAUploadFile = UploadDocument(files[0], "PUADocuments");
					if (PUAUploadFile == null)
						return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to uploading " + docName + " document.", StatusCode = ResponseCodes.Success };

				}
				if (files[1] != null)
				{
					string docName = "UUOA";
					UUOAUploadFile = UploadDocument(files[1], "UUOADocuments");
					if (UUOAUploadFile == null)
						return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to uploading " + docName + " document.", StatusCode = ResponseCodes.Success };

				}
				#endregion

				Oil_UnitizationData.PUAUploadFilePath = files[0] != null ? PUAUploadFile.filePath : null;
				Oil_UnitizationData.PUAUploadFilename = files[0] != null ? PUAUploadFile.fileName : null;
				Oil_UnitizationData.UUOAUploadFilePath = files[1] != null ? UUOAUploadFile.filePath : null;
				Oil_UnitizationData.UUOAUploadFilename = files[1] != null ? UUOAUploadFile.fileName : null;
				Oil_UnitizationData.Companyemail = WKPUserEmail;
				Oil_UnitizationData.CompanyName = WKPUserName;
				Oil_UnitizationData.COMPANY_ID = WKPUserId;
				Oil_UnitizationData.Date_Updated = DateTime.Now;
				Oil_UnitizationData.Updated_by = WKPUserId;
				Oil_UnitizationData.Year_of_WP = WorkProgramme_Year;
				if (getOil_UnitizationData == null)
				{
					Oil_UnitizationData.Created_by = WKPUserId;
					Oil_UnitizationData.Date_Created = DateTime.Now;
					_context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATIONs.AddAsync(Oil_UnitizationData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATIONs.Remove(Oil_UnitizationData);
				}
				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse GAS_PRODUCTION_ACTIVITy(GAS_PRODUCTION_ACTIVITy_Model wkp, string WorkProgramme_Year, List<IFormFile> files, string action = null)
		{

			int save = 0;
			var Gas_ProductionData = new GAS_PRODUCTION_ACTIVITy();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Gas_ProductionData
				var getGas_ProductionData = (from c in _context.GAS_PRODUCTION_ACTIVITIEs where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				Gas_ProductionData = getGas_ProductionData != null ? getGas_ProductionData : Gas_ProductionData;
				Gas_ProductionData = _mapper.Map<GAS_PRODUCTION_ACTIVITy>(wkp);

				#region file section
				UploadedDocument Upload_NDR_payment_receipt_File = null;

				if (files[0] != null)
				{
					string docName = "NDR Payment Receipt";
					Upload_NDR_payment_receipt_File = UploadDocument(files[0], "NDRPaymentReceipt");
					if (Upload_NDR_payment_receipt_File == null)
						return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to uploading " + docName + " document.", StatusCode = ResponseCodes.Success };

				}
				#endregion


				Gas_ProductionData.Upload_NDR_payment_receipt = files[0] != null ? Upload_NDR_payment_receipt_File.filePath : null;
				Gas_ProductionData.NDRFilename = files[0] != null ? Upload_NDR_payment_receipt_File.fileName : null;
				Gas_ProductionData.Companyemail = WKPUserEmail;
				Gas_ProductionData.CompanyName = WKPUserName;
				Gas_ProductionData.COMPANY_ID = WKPUserId;
				Gas_ProductionData.Date_Updated = DateTime.Now;
				Gas_ProductionData.Updated_by = WKPUserId;
				Gas_ProductionData.Year_of_WP = WorkProgramme_Year;
				if (getGas_ProductionData == null)
				{
					Gas_ProductionData.Created_by = WKPUserId;
					Gas_ProductionData.Date_Created = DateTime.Now;
					_context.GAS_PRODUCTION_ACTIVITIEs.AddAsync(Gas_ProductionData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.GAS_PRODUCTION_ACTIVITIEs.Remove(Gas_ProductionData);
				}
				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse NDR(NDR_Model wkp, string WorkProgramme_Year, List<IFormFile> files, string action = null)
		{

			int save = 0;
			var NDRData = new NDR();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				var getGas_ProductionData = (from c in _context.GAS_PRODUCTION_ACTIVITIEs where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();
				#region Saving NDRData
				var getNDRData = (from c in _context.NDRs where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				NDRData = getNDRData != null ? getNDRData : NDRData;
				NDRData = _mapper.Map<NDR>(wkp);
				if (getGas_ProductionData != null)
				{
					NDRData.Upload_NDR_payment_receipt = getGas_ProductionData != null ? getGas_ProductionData.Upload_NDR_payment_receipt : null;
					NDRData.NDRFilename = getGas_ProductionData != null ? getGas_ProductionData.NDRFilename : null;

				}
				NDRData.Companyemail = WKPUserEmail;
				NDRData.CompanyName = WKPUserName;
				NDRData.COMPANY_ID = WKPUserId;
				NDRData.Date_Updated = DateTime.Now;
				NDRData.Updated_by = WKPUserId;
				NDRData.Year_of_WP = WorkProgramme_Year;
				if (getNDRData == null)
				{
					NDRData.Created_by = WKPUserId;
					NDRData.Date_Created = DateTime.Now;
					_context.NDRs.AddAsync(NDRData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.NDRs.Remove(NDRData);
				}

				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE(RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var Oil_Condensate_ReserveStatusData = new RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Oil_Condensate_ReserveStatusData
				var getOil_Condensate_ReserveStatusData = (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				Oil_Condensate_ReserveStatusData = getOil_Condensate_ReserveStatusData != null ? getOil_Condensate_ReserveStatusData : Oil_Condensate_ReserveStatusData;
				Oil_Condensate_ReserveStatusData = _mapper.Map<RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE>(wkp);

				Oil_Condensate_ReserveStatusData.Companyemail = WKPUserEmail;
				Oil_Condensate_ReserveStatusData.CompanyName = WKPUserName;
				Oil_Condensate_ReserveStatusData.COMPANY_ID = WKPUserId;
				Oil_Condensate_ReserveStatusData.Date_Updated = DateTime.Now;
				Oil_Condensate_ReserveStatusData.Updated_by = WKPUserId;
				Oil_Condensate_ReserveStatusData.Year_of_WP = WorkProgramme_Year;
				if (getOil_Condensate_ReserveStatusData == null)
				{
					Oil_Condensate_ReserveStatusData.Created_by = WKPUserId;
					Oil_Condensate_ReserveStatusData.Date_Created = DateTime.Now;
					_context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs.AddAsync(Oil_Condensate_ReserveStatusData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVEs.Remove(Oil_Condensate_ReserveStatusData);
				}
				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projection(RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projection_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var Oil_Condensate_ReserveProjectionData = new RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projection();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Oil_Condensate_ReserveProjectionData
				var getOil_Condensate_ReserveProjectionData = (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projections where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				Oil_Condensate_ReserveProjectionData = getOil_Condensate_ReserveProjectionData != null ? getOil_Condensate_ReserveProjectionData : Oil_Condensate_ReserveProjectionData;
				Oil_Condensate_ReserveProjectionData = _mapper.Map<RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projection>(wkp);

				Oil_Condensate_ReserveProjectionData.Companyemail = WKPUserEmail;
				Oil_Condensate_ReserveProjectionData.CompanyName = WKPUserName;
				Oil_Condensate_ReserveProjectionData.COMPANY_ID = WKPUserId;
				Oil_Condensate_ReserveProjectionData.Date_Updated = DateTime.Now;
				Oil_Condensate_ReserveProjectionData.Updated_by = WKPUserId;
				Oil_Condensate_ReserveProjectionData.Year_of_WP = WorkProgramme_Year;
				if (getOil_Condensate_ReserveProjectionData == null)
				{
					Oil_Condensate_ReserveProjectionData.Created_by = WKPUserId;
					Oil_Condensate_ReserveProjectionData.Date_Created = DateTime.Now;
					_context.RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projections.AddAsync(Oil_Condensate_ReserveProjectionData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projections.Remove(Oil_Condensate_ReserveProjectionData);
				}
				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTION(OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTION_Model wkp, string WorkProgramme_Year, List<IFormFile> files, string action = null)
		{

			int save = 0;
			var Oil_Condensate_ProjectionData = new OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTION();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Oil_Condensate_ProjectionData
				var getOil_Condensate_ProjectionData = (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				Oil_Condensate_ProjectionData = getOil_Condensate_ProjectionData != null ? getOil_Condensate_ProjectionData : Oil_Condensate_ProjectionData;
				Oil_Condensate_ProjectionData = _mapper.Map<OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTION>(wkp);

				#region file section
				UploadedDocument ProductionOilCondensateAGNAGFile_File = null;

				if (files[0] != null)
				{
					string docName = "ProductionOilCondensateAGNAG";
					ProductionOilCondensateAGNAGFile_File = UploadDocument(files[0], "ProductionOilCondensateAGNAGDocument");
					if (ProductionOilCondensateAGNAGFile_File == null)
						return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to uploading " + docName + " document.", StatusCode = ResponseCodes.Success };

				}
				#endregion

				Oil_Condensate_ProjectionData.ProductionOilCondensateAGNAGUFilename = files[0] != null ? ProductionOilCondensateAGNAGFile_File.fileName : null;
				Oil_Condensate_ProjectionData.ProductionOilCondensateAGNAGUploadFilePath = files[0] != null ? ProductionOilCondensateAGNAGFile_File.filePath : null;
				Oil_Condensate_ProjectionData.Companyemail = WKPUserEmail;
				Oil_Condensate_ProjectionData.CompanyName = WKPUserName;
				Oil_Condensate_ProjectionData.COMPANY_ID = WKPUserId;
				Oil_Condensate_ProjectionData.Date_Updated = DateTime.Now;
				Oil_Condensate_ProjectionData.Updated_by = WKPUserId;
				Oil_Condensate_ProjectionData.Year_of_WP = DateTime.Now.Year.ToString();
				if (getOil_Condensate_ProjectionData == null)
				{
					Oil_Condensate_ProjectionData.Created_by = WKPUserId;
					Oil_Condensate_ProjectionData.Date_Created = DateTime.Now;
					_context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs.AddAsync(Oil_Condensate_ProjectionData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTIONs.Remove(Oil_Condensate_ProjectionData);
				}
				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTION(RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTION_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var Oil_Condensate_AnnualData = new RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTION();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Oil_Condensate_AnnualData
				var getOil_Condensate_AnnualData = (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTIONs where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				Oil_Condensate_AnnualData = getOil_Condensate_AnnualData != null ? getOil_Condensate_AnnualData : Oil_Condensate_AnnualData;
				Oil_Condensate_AnnualData = _mapper.Map<RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTION>(wkp);

				Oil_Condensate_AnnualData.Companyemail = WKPUserEmail;
				Oil_Condensate_AnnualData.CompanyName = WKPUserName;
				Oil_Condensate_AnnualData.COMPANY_ID = WKPUserId;
				Oil_Condensate_AnnualData.Date_Updated = DateTime.Now;
				Oil_Condensate_AnnualData.Updated_by = WKPUserId;
				Oil_Condensate_AnnualData.Year_of_WP = DateTime.Now.Year.ToString();
				if (getOil_Condensate_AnnualData == null)
				{
					Oil_Condensate_AnnualData.Created_by = WKPUserId;
					Oil_Condensate_AnnualData.Date_Created = DateTime.Now;
					_context.RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTIONs.AddAsync(Oil_Condensate_AnnualData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTIONs.Remove(Oil_Condensate_AnnualData);
				}
				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINE(RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINE_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var Oil_Condensate_DeclineData = new RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINE();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Oil_Condensate_DeclineData
				var getOil_Condensate_DeclineData = (from c in _context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINEs where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				Oil_Condensate_DeclineData = getOil_Condensate_DeclineData != null ? getOil_Condensate_DeclineData : Oil_Condensate_DeclineData;
				Oil_Condensate_DeclineData = _mapper.Map<RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINE>(wkp);

				Oil_Condensate_DeclineData.Companyemail = WKPUserEmail;
				Oil_Condensate_DeclineData.CompanyName = WKPUserName;
				Oil_Condensate_DeclineData.COMPANY_ID = WKPUserId;
				Oil_Condensate_DeclineData.Date_Updated = DateTime.Now;
				Oil_Condensate_DeclineData.Updated_by = WKPUserId;
				Oil_Condensate_DeclineData.Year_of_WP = DateTime.Now.Year.ToString();
				if (getOil_Condensate_DeclineData == null)
				{
					Oil_Condensate_DeclineData.Created_by = WKPUserId;
					Oil_Condensate_DeclineData.Date_Created = DateTime.Now;
					_context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINEs.AddAsync(Oil_Condensate_DeclineData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINEs.Remove(Oil_Condensate_DeclineData);
				}
				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activity(OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activity_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var Oil_Condensate_ProductionData = new OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activity();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Oil_Condensate_ProductionData
				var getOil_Condensate_ProductionData = (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				Oil_Condensate_ProductionData = getOil_Condensate_ProductionData != null ? getOil_Condensate_ProductionData : Oil_Condensate_ProductionData;
				Oil_Condensate_ProductionData = _mapper.Map<OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activity>(wkp);

				Oil_Condensate_ProductionData.Companyemail = WKPUserEmail;
				Oil_Condensate_ProductionData.CompanyName = WKPUserName;
				Oil_Condensate_ProductionData.COMPANY_ID = WKPUserId;
				Oil_Condensate_ProductionData.Date_Updated = DateTime.Now;
				Oil_Condensate_ProductionData.Updated_by = WKPUserId;
				Oil_Condensate_ProductionData.Year_of_WP = DateTime.Now.Year.ToString();
				if (getOil_Condensate_ProductionData == null)
				{
					Oil_Condensate_ProductionData.Created_by = WKPUserId;
					Oil_Condensate_ProductionData.Date_Created = DateTime.Now;
					_context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities.AddAsync(Oil_Condensate_ProductionData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities.Remove(Oil_Condensate_ProductionData);
				}
				save += _context.SaveChanges();
				#endregion
				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse RESERVES_REPLACEMENT_RATIO(RESERVES_REPLACEMENT_RATIO_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var Reserve_ReplacementData = new RESERVES_REPLACEMENT_RATIO();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Reserve_ReplacementData

				var getReserve_ReplacementData = (from c in _context.RESERVES_REPLACEMENT_RATIOs where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				Reserve_ReplacementData = getReserve_ReplacementData != null ? getReserve_ReplacementData : Reserve_ReplacementData;
				Reserve_ReplacementData = _mapper.Map<RESERVES_REPLACEMENT_RATIO>(wkp);

				Reserve_ReplacementData.Companyemail = WKPUserEmail;
				Reserve_ReplacementData.CompanyName = WKPUserName;
				Reserve_ReplacementData.COMPANY_ID = WKPUserId;
				Reserve_ReplacementData.Date_Updated = DateTime.Now;
				Reserve_ReplacementData.Updated_by = WKPUserId;
				Reserve_ReplacementData.Year_of_WP = DateTime.Now.Year.ToString();
				if (getReserve_ReplacementData == null)
				{
					Reserve_ReplacementData.Created_by = WKPUserId;
					Reserve_ReplacementData.Date_Created = DateTime.Now;
					_context.RESERVES_REPLACEMENT_RATIOs.AddAsync(Reserve_ReplacementData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.RESERVES_REPLACEMENT_RATIOs.Remove(Reserve_ReplacementData);
				}
				save += _context.SaveChanges();
				#endregion
				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSED(OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSED_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var Oil_MonthlyData = new OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSED();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Oil_MonthlyData
				var getOil_MonthlyData = (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSEDs where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				Oil_MonthlyData = getOil_MonthlyData != null ? getOil_MonthlyData : Oil_MonthlyData;
				Oil_MonthlyData = _mapper.Map<OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSED>(wkp);

				Oil_MonthlyData.Companyemail = WKPUserEmail;
				Oil_MonthlyData.CompanyName = WKPUserName;
				Oil_MonthlyData.COMPANY_ID = WKPUserId;
				Oil_MonthlyData.Date_Updated = DateTime.Now;
				Oil_MonthlyData.Updated_by = WKPUserId;
				Oil_MonthlyData.Year_of_WP = DateTime.Now.Year.ToString();
				if (getOil_MonthlyData == null)
				{
					Oil_MonthlyData.Created_by = WKPUserId;
					Oil_MonthlyData.Date_Created = DateTime.Now;
					_context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSEDs.Add(Oil_MonthlyData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSEDs.Remove(Oil_MonthlyData);
				}
				save += _context.SaveChanges();
				#endregion
				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLY(GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLY_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var Gas_ActivitiesData = new GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLY();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Gas_ActivitiesData
				var getGas_ActivitiesData = (from c in _context.GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLies where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				Gas_ActivitiesData = getGas_ActivitiesData != null ? getGas_ActivitiesData : Gas_ActivitiesData;
				Gas_ActivitiesData = _mapper.Map<GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLY>(wkp);

				Gas_ActivitiesData.Companyemail = WKPUserEmail;
				Gas_ActivitiesData.CompanyName = WKPUserName;
				Gas_ActivitiesData.COMPANY_ID = WKPUserId;
				Gas_ActivitiesData.Date_Updated = DateTime.Now;
				Gas_ActivitiesData.Updated_by = WKPUserId;
				Gas_ActivitiesData.Year_of_WP = DateTime.Now.Year.ToString();
				if (getGas_ActivitiesData == null)
				{
					Gas_ActivitiesData.Created_by = WKPUserId;
					Gas_ActivitiesData.Date_Created = DateTime.Now;
					_context.GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLies.AddAsync(Gas_ActivitiesData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLies.Remove(Gas_ActivitiesData);
				}
				save += _context.SaveChanges();
				#endregion
				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse BUDGET_ACTUAL_EXPENDITURE(BUDGET_ACTUAL_EXPENDITURE_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var BudgetActualExData = new BUDGET_ACTUAL_EXPENDITURE();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Gas_ActivitiesData
				var getBudgetActualExData = (from c in _context.BUDGET_ACTUAL_EXPENDITUREs where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				BudgetActualExData = getBudgetActualExData != null ? getBudgetActualExData : BudgetActualExData;
				BudgetActualExData = _mapper.Map<BUDGET_ACTUAL_EXPENDITURE>(wkp);

				BudgetActualExData.Companyemail = WKPUserEmail;
				BudgetActualExData.CompanyName = WKPUserName;
				BudgetActualExData.COMPANY_ID = WKPUserId;
				BudgetActualExData.Date_Updated = DateTime.Now;
				BudgetActualExData.Updated_by = WKPUserId;
				BudgetActualExData.Year_of_WP = DateTime.Now.Year.ToString();
				if (getBudgetActualExData == null)
				{
					BudgetActualExData.Created_by = WKPUserId;
					BudgetActualExData.Date_Created = DateTime.Now;
					_context.BUDGET_ACTUAL_EXPENDITUREs.AddAsync(BudgetActualExData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.BUDGET_ACTUAL_EXPENDITUREs.Remove(BudgetActualExData);
				}
				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENT(BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENT_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var BudgetProposalData = new BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENT();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Budget Proposal

				var getBudgetProposalData = (from c in _context.BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				BudgetProposalData = getBudgetProposalData != null ? getBudgetProposalData : BudgetProposalData;
				BudgetProposalData = _mapper.Map<BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENT>(wkp);

				BudgetProposalData.Companyemail = WKPUserEmail;
				BudgetProposalData.CompanyName = WKPUserName;
				BudgetProposalData.COMPANY_ID = WKPUserId;
				BudgetProposalData.Date_Updated = DateTime.Now;
				BudgetProposalData.Updated_by = WKPUserId;
				BudgetProposalData.Year_of_WP = DateTime.Now.Year.ToString();
				if (getBudgetProposalData == null)
				{
					BudgetProposalData.Created_by = WKPUserId;
					BudgetProposalData.Date_Created = DateTime.Now;

					_context.BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs.AddAsync(BudgetProposalData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENTs.Remove(BudgetProposalData);
				}
				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITy(BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITy_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var BudgetPerformanceExpData = new BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITy();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Budget Performance Exploratory

				var getBudgetPerformanceExpData = (from c in _context.BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				BudgetPerformanceExpData = getBudgetPerformanceExpData != null ? getBudgetPerformanceExpData : BudgetPerformanceExpData;
				BudgetPerformanceExpData = _mapper.Map<BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITy>(wkp);

				BudgetPerformanceExpData.Companyemail = WKPUserEmail;
				BudgetPerformanceExpData.CompanyName = WKPUserName;
				BudgetPerformanceExpData.COMPANY_ID = WKPUserId;
				BudgetPerformanceExpData.Date_Updated = DateTime.Now;
				BudgetPerformanceExpData.Updated_by = WKPUserId;
				BudgetPerformanceExpData.Year_of_WP = DateTime.Now.Year.ToString();
				if (getBudgetPerformanceExpData == null)
				{
					BudgetPerformanceExpData.Created_by = WKPUserId;
					BudgetPerformanceExpData.Date_Created = DateTime.Now;
					_context.BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs.AddAsync(BudgetPerformanceExpData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIEs.Remove(BudgetPerformanceExpData);
				}

				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITy(BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITy_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var BudgetPerformanceDevData = new BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITy();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Budget Performance Development

				var getBudgetPerformanceDevData = (from c in _context.BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIEs where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				BudgetPerformanceDevData = getBudgetPerformanceDevData != null ? getBudgetPerformanceDevData : BudgetPerformanceDevData;
				BudgetPerformanceDevData = _mapper.Map<BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITy>(wkp);

				BudgetPerformanceDevData.Companyemail = WKPUserEmail;
				BudgetPerformanceDevData.CompanyName = WKPUserName;
				BudgetPerformanceDevData.COMPANY_ID = WKPUserId;
				BudgetPerformanceDevData.Date_Updated = DateTime.Now;
				BudgetPerformanceDevData.Updated_by = WKPUserId;
				BudgetPerformanceDevData.Year_of_WP = DateTime.Now.Year.ToString();
				if (getBudgetPerformanceDevData == null)
				{
					BudgetPerformanceDevData.Created_by = WKPUserId;
					BudgetPerformanceDevData.Date_Created = DateTime.Now;
					_context.BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIEs.Add(BudgetPerformanceDevData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIEs.Remove(BudgetPerformanceDevData);
				}
				save += _context.SaveChanges();
				#endregion


				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse BUDGET_PERFORMANCE_PRODUCTION_COST(BUDGET_PERFORMANCE_PRODUCTION_COST_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var BudgetPerformanceProdData = new BUDGET_PERFORMANCE_PRODUCTION_COST();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Budget Performance Production

				var getBudgetPerformanceProdData = (from c in _context.BUDGET_PERFORMANCE_PRODUCTION_COSTs where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				BudgetPerformanceProdData = getBudgetPerformanceProdData != null ? getBudgetPerformanceProdData : BudgetPerformanceProdData;
				BudgetPerformanceProdData = _mapper.Map<BUDGET_PERFORMANCE_PRODUCTION_COST>(wkp);

				BudgetPerformanceProdData.Companyemail = WKPUserEmail;
				BudgetPerformanceProdData.CompanyName = WKPUserName;
				BudgetPerformanceProdData.COMPANY_ID = WKPUserId;
				BudgetPerformanceProdData.Date_Updated = DateTime.Now;
				BudgetPerformanceProdData.Updated_by = WKPUserId;
				BudgetPerformanceProdData.Year_of_WP = DateTime.Now.Year.ToString();
				if (getBudgetPerformanceProdData == null)
				{
					BudgetPerformanceProdData.Created_by = WKPUserId;
					BudgetPerformanceProdData.Date_Created = DateTime.Now;
					_context.BUDGET_PERFORMANCE_PRODUCTION_COSTs.AddAsync(BudgetPerformanceProdData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.BUDGET_PERFORMANCE_PRODUCTION_COSTs.Remove(BudgetPerformanceProdData);
				}

				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECT(BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECT_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var BudgetPerformanceFacData = new BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECT();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Budget Performance Facility

				var getBudgetPerformanceFacData = (from c in _context.BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECTs where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				BudgetPerformanceFacData = getBudgetPerformanceFacData != null ? getBudgetPerformanceFacData : BudgetPerformanceFacData;
				BudgetPerformanceFacData = _mapper.Map<BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECT>(wkp);

				BudgetPerformanceFacData.Companyemail = WKPUserEmail;
				BudgetPerformanceFacData.CompanyName = WKPUserName;
				BudgetPerformanceFacData.COMPANY_ID = WKPUserId;
				BudgetPerformanceFacData.Date_Updated = DateTime.Now;
				BudgetPerformanceFacData.Updated_by = WKPUserId;
				BudgetPerformanceFacData.Year_of_WP = DateTime.Now.Year.ToString();
				if (getBudgetPerformanceFacData == null)
				{
					BudgetPerformanceFacData.Created_by = WKPUserId;
					BudgetPerformanceFacData.Date_Created = DateTime.Now;
					_context.BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECTs.AddAsync(BudgetPerformanceFacData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECTs.Remove(BudgetPerformanceFacData);
				}

				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITURE(OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITURE_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var OilGasFacData = new OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITURE();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Oil & Gas Facility

				var getOilGasFacData = (from c in _context.OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITUREs where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				OilGasFacData = getOilGasFacData != null ? getOilGasFacData : OilGasFacData;
				OilGasFacData = _mapper.Map<OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITURE>(wkp);

				OilGasFacData.Companyemail = WKPUserEmail;
				OilGasFacData.CompanyName = WKPUserName;
				OilGasFacData.COMPANY_ID = WKPUserId;
				OilGasFacData.Date_Updated = DateTime.Now;
				OilGasFacData.Updated_by = WKPUserId;
				OilGasFacData.Year_of_WP = DateTime.Now.Year.ToString();
				if (getOilGasFacData == null)
				{
					OilGasFacData.Created_by = WKPUserId;
					OilGasFacData.Date_Created = DateTime.Now;
					_context.OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITUREs.AddAsync(OilGasFacData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITUREs.Remove(OilGasFacData);
				}

				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessment(OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessment_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var OilGasProdData = new OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessment();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Oil & Gas Production

				var getOilGasProdData = (from c in _context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				OilGasProdData = getOilGasProdData != null ? getOilGasProdData : OilGasProdData;
				OilGasProdData = _mapper.Map<OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessment>(wkp);

				OilGasProdData.Companyemail = WKPUserEmail;
				OilGasProdData.CompanyName = WKPUserName;
				OilGasProdData.COMPANY_ID = WKPUserId;
				OilGasProdData.Date_Updated = DateTime.Now;
				OilGasProdData.Updated_by = WKPUserId;
				OilGasProdData.Year_of_WP = DateTime.Now.Year.ToString();
				if (getOilGasProdData == null)
				{
					OilGasProdData.Created_by = WKPUserId;
					OilGasProdData.Date_Created = DateTime.Now;
					_context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments.AddAsync(OilGasProdData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessments.Remove(OilGasProdData);
				}

				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECT(OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECT_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var OilGasFacProjectData = new OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECT();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Oil Gas Facility Project

				var getOilGasFacProjectData = (from c in _context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				OilGasFacProjectData = getOilGasFacProjectData != null ? getOilGasFacProjectData : OilGasFacProjectData;
				OilGasFacProjectData = _mapper.Map<OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECT>(wkp);

				OilGasFacProjectData.Companyemail = WKPUserEmail;
				OilGasFacProjectData.CompanyName = WKPUserName;
				OilGasFacProjectData.COMPANY_ID = WKPUserId;
				OilGasFacProjectData.Date_Updated = DateTime.Now;
				OilGasFacProjectData.Updated_by = WKPUserId;
				OilGasFacProjectData.Year_of_WP = DateTime.Now.Year.ToString();
				if (getOilGasFacProjectData == null)
				{
					OilGasFacProjectData.Created_by = WKPUserId;
					OilGasFacProjectData.Date_Created = DateTime.Now;
					_context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs.AddAsync(OilGasFacProjectData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTs.Remove(OilGasFacProjectData);
				}
				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse FACILITIES_PROJECT_PERFORMANCE(FACILITIES_PROJECT_PERFORMANCE_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var FacProjectData = new FACILITIES_PROJECT_PERFORMANCE();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Facility Project

				var getFacProjectData = (from c in _context.FACILITIES_PROJECT_PERFORMANCEs where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				FacProjectData = getFacProjectData != null ? getFacProjectData : FacProjectData;
				FacProjectData = _mapper.Map<FACILITIES_PROJECT_PERFORMANCE>(wkp);

				FacProjectData.Companyemail = WKPUserEmail;
				FacProjectData.CompanyName = WKPUserName;
				FacProjectData.COMPANY_ID = WKPUserId;
				FacProjectData.Date_Updated = DateTime.Now;
				FacProjectData.Updated_by = WKPUserId;
				FacProjectData.Year_of_WP = DateTime.Now.Year.ToString();
				if (getFacProjectData == null)
				{
					FacProjectData.Created_by = WKPUserId;
					FacProjectData.Date_Created = DateTime.Now;
					_context.FACILITIES_PROJECT_PERFORMANCEs.AddAsync(FacProjectData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.FACILITIES_PROJECT_PERFORMANCEs.Remove(FacProjectData);
				}
				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse BUDGET_CAPEX_OPEX(BUDGET_CAPEX_OPEX_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var BudgetCapexOpexData = new BUDGET_CAPEX_OPEX();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Budget Capex Opex

				var getBudgetCapexOpexData = (from c in _context.BUDGET_CAPEX_OPices where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				BudgetCapexOpexData = getBudgetCapexOpexData != null ? getBudgetCapexOpexData : BudgetCapexOpexData;
				BudgetCapexOpexData = _mapper.Map<BUDGET_CAPEX_OPEX>(wkp);

				BudgetCapexOpexData.Companyemail = WKPUserEmail;
				BudgetCapexOpexData.CompanyName = WKPUserName;
				BudgetCapexOpexData.COMPANY_ID = WKPUserId;
				BudgetCapexOpexData.Date_Updated = DateTime.Now;
				BudgetCapexOpexData.Updated_by = WKPUserId;
				BudgetCapexOpexData.Year_of_WP = DateTime.Now.Year.ToString();
				if (getBudgetCapexOpexData == null)
				{
					BudgetCapexOpexData.Created_by = WKPUserId;
					BudgetCapexOpexData.Date_Created = DateTime.Now;
					_context.BUDGET_CAPEX_OPices.AddAsync(BudgetCapexOpexData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.BUDGET_CAPEX_OPices.Remove(BudgetCapexOpexData);
				}
				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse NIGERIA_CONTENT_Training(NIGERIA_CONTENT_Training_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var NigeriaTrainingData = new NIGERIA_CONTENT_Training();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Nigeria Training
				var getNigeriaTrainingData = (from c in _context.NIGERIA_CONTENT_Trainings where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				NigeriaTrainingData = getNigeriaTrainingData != null ? getNigeriaTrainingData : NigeriaTrainingData;
				NigeriaTrainingData = _mapper.Map<NIGERIA_CONTENT_Training>(wkp);

				NigeriaTrainingData.Companyemail = WKPUserEmail;
				NigeriaTrainingData.CompanyName = WKPUserName;
				NigeriaTrainingData.COMPANY_ID = WKPUserId;
				NigeriaTrainingData.Date_Updated = DateTime.Now;
				NigeriaTrainingData.Updated_by = WKPUserId;
				NigeriaTrainingData.Year_of_WP = DateTime.Now.Year.ToString();
				if (getNigeriaTrainingData == null)
				{
					NigeriaTrainingData.Created_by = WKPUserId;
					NigeriaTrainingData.Date_Created = DateTime.Now;
					_context.NIGERIA_CONTENT_Trainings.AddAsync(NigeriaTrainingData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.NIGERIA_CONTENT_Trainings.Remove(NigeriaTrainingData);
				}

				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse NIGERIA_CONTENT_Upload_Succession_Plan(NIGERIA_CONTENT_Upload_Succession_Plan_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var NigeriaUploadData = new NIGERIA_CONTENT_Upload_Succession_Plan();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Nigeria Upload

				var getNigeriaUploadData = (from c in _context.NIGERIA_CONTENT_Upload_Succession_Plans where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				NigeriaUploadData = getNigeriaUploadData != null ? getNigeriaUploadData : NigeriaUploadData;
				NigeriaUploadData = _mapper.Map<NIGERIA_CONTENT_Upload_Succession_Plan>(wkp);

				NigeriaUploadData.Companyemail = WKPUserEmail;
				NigeriaUploadData.CompanyName = WKPUserName;
				NigeriaUploadData.COMPANY_ID = WKPUserId;
				NigeriaUploadData.Date_Updated = DateTime.Now;
				NigeriaUploadData.Updated_by = WKPUserId;
				NigeriaUploadData.Year_of_WP = DateTime.Now.Year.ToString();
				if (getNigeriaUploadData == null)
				{
					NigeriaUploadData.Created_by = WKPUserId;
					NigeriaUploadData.Date_Created = DateTime.Now;
					_context.NIGERIA_CONTENT_Upload_Succession_Plans.AddAsync(NigeriaUploadData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.NIGERIA_CONTENT_Upload_Succession_Plans.Remove(NigeriaUploadData);
				}
				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse NIGERIA_CONTENT_QUESTION(NIGERIA_CONTENT_QUESTION_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var NigeriaQuestionData = new NIGERIA_CONTENT_QUESTION();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Nigeria Question

				var getNigeriaQuestionData = (from c in _context.NIGERIA_CONTENT_QUESTIONs where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				NigeriaQuestionData = getNigeriaQuestionData != null ? getNigeriaQuestionData : NigeriaQuestionData;
				NigeriaQuestionData = _mapper.Map<NIGERIA_CONTENT_QUESTION>(wkp);

				NigeriaQuestionData.Companyemail = WKPUserEmail;
				NigeriaQuestionData.CompanyName = WKPUserName;
				NigeriaQuestionData.COMPANY_ID = WKPUserId;
				NigeriaQuestionData.Date_Updated = DateTime.Now;
				NigeriaQuestionData.Updated_by = WKPUserId;
				NigeriaQuestionData.Year_of_WP = DateTime.Now.Year.ToString();
				if (getNigeriaQuestionData == null)
				{
					NigeriaQuestionData.Created_by = WKPUserId;
					NigeriaQuestionData.Date_Created = DateTime.Now;
					_context.NIGERIA_CONTENT_QUESTIONs.AddAsync(NigeriaQuestionData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.NIGERIA_CONTENT_QUESTIONs.Remove(NigeriaQuestionData);
				}
				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse LEGAL_LITIGATION(LEGAL_LITIGATION_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var LegalLitigationData = new LEGAL_LITIGATION();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Legal Litigation

				var getLegalLitigationData = (from c in _context.LEGAL_LITIGATIONs where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				LegalLitigationData = getLegalLitigationData != null ? getLegalLitigationData : LegalLitigationData;
				LegalLitigationData = _mapper.Map<LEGAL_LITIGATION>(wkp);

				LegalLitigationData.Companyemail = WKPUserEmail;
				LegalLitigationData.CompanyName = WKPUserName;
				LegalLitigationData.COMPANY_ID = WKPUserId;
				LegalLitigationData.Date_Updated = DateTime.Now;
				LegalLitigationData.Updated_by = WKPUserId;
				LegalLitigationData.Year_of_WP = DateTime.Now.Year.ToString();
				if (getLegalLitigationData == null)
				{
					LegalLitigationData.Created_by = WKPUserId;
					LegalLitigationData.Date_Created = DateTime.Now;
					_context.LEGAL_LITIGATIONs.AddAsync(LegalLitigationData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.LEGAL_LITIGATIONs.Remove(LegalLitigationData);
				}
				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse LEGAL_ARBITRATION(LEGAL_ARBITRATION_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var LegalArbitrationData = new LEGAL_ARBITRATION();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Legal Arbitration

				var getLegalArbitrationData = (from c in _context.LEGAL_ARBITRATIONs where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				LegalArbitrationData = getLegalArbitrationData != null ? getLegalArbitrationData : LegalArbitrationData;
				LegalArbitrationData = _mapper.Map<LEGAL_ARBITRATION>(wkp);

				LegalArbitrationData.Companyemail = WKPUserEmail;
				LegalArbitrationData.CompanyName = WKPUserName;
				LegalArbitrationData.COMPANY_ID = WKPUserId;
				LegalArbitrationData.Date_Updated = DateTime.Now;
				LegalArbitrationData.Updated_by = WKPUserId;
				LegalArbitrationData.Year_of_WP = DateTime.Now.Year.ToString();
				if (getLegalArbitrationData == null)
				{
					LegalArbitrationData.Created_by = WKPUserId;
					LegalArbitrationData.Date_Created = DateTime.Now;
					_context.LEGAL_ARBITRATIONs.AddAsync(LegalArbitrationData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.LEGAL_ARBITRATIONs.Remove(LegalArbitrationData);
				}

				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}
		[HttpPost]
		public WebApiResponse STRATEGIC_PLANS_ON_COMPANY_BASI(STRATEGIC_PLANS_ON_COMPANY_BASI_Model wkp, string WorkProgramme_Year, string action = null)
		{

			int save = 0;
			var StrategicPlansData = new STRATEGIC_PLANS_ON_COMPANY_BASI();
			action = action == null ? GeneralModel.Insert : action;

			try
			{

				#region Saving Strategic Plans

				var getStrategicPlansData = (from c in _context.STRATEGIC_PLANS_ON_COMPANY_BAses where c.COMPANY_ID == WKPUserId && c.Year_of_WP == WorkProgramme_Year select c).FirstOrDefault();

				StrategicPlansData = getStrategicPlansData != null ? getStrategicPlansData : StrategicPlansData;
				StrategicPlansData = _mapper.Map<STRATEGIC_PLANS_ON_COMPANY_BASI>(wkp);

				StrategicPlansData.Companyemail = WKPUserEmail;
				StrategicPlansData.CompanyName = WKPUserName;
				StrategicPlansData.COMPANY_ID = WKPUserId;
				StrategicPlansData.Date_Updated = DateTime.Now;
				StrategicPlansData.Updated_by = WKPUserId;
				StrategicPlansData.Year_of_WP = DateTime.Now.Year.ToString();
				if (getStrategicPlansData == null)
				{
					StrategicPlansData.Created_by = WKPUserId;
					StrategicPlansData.Date_Created = DateTime.Now;
					_context.STRATEGIC_PLANS_ON_COMPANY_BAses.AddAsync(StrategicPlansData);
				}
				else if (action == GeneralModel.Delete)
				{
					_context.STRATEGIC_PLANS_ON_COMPANY_BAses.Remove(StrategicPlansData);
				}

				save += _context.SaveChanges();
				#endregion

				if (save > 0)
				{
					string successMsg = "Form has been " + action + " successfully.";
					return new WebApiResponse { ResponseCode = AppResponseCodes.Success, Message = successMsg, Data = wkp, StatusCode = ResponseCodes.Success };
				}
				else
				{
					return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : An error occured while trying to submit this form.", StatusCode = ResponseCodes.Badrequest };

				}

			}
			catch (Exception e)
			{
				return new WebApiResponse { ResponseCode = AppResponseCodes.Failed, Message = "Failure : " + e.Message, StatusCode = ResponseCodes.InternalError };

			}
		}

		#endregion

		#region PermitGenerator
		public string CreatePermit(Application app)
		{
			try
			{
				var application = _context.Applications.Where(a => a.Id == app.Id).FirstOrDefault();

				#region Create The Permit
				var getCategory = _context.ApplicationCategories.Where(p => p.Id == app.CategoryID).FirstOrDefault();
				var Company = _context.ADMIN_COMPANY_INFORMATIONs.Where(p => p.Id == app.CompanyID).FirstOrDefault();
				string pm = "";
				var elps_Approval = new PermitAPIModel();
				string letterTemplate = "";
				PermitApproval approval = new PermitApproval();
				approval.PermitNo = GeneratePermitNo(app.Id, app.CategoryID, app.YearOfWKP);
				approval.AppID = app.Id;
				approval.CompanyID = app.CompanyID;
				approval.DateIssued = DateTime.Now;
				approval.DateExpired = approval.DateIssued;
				_context.PermitApprovals.Add(approval);
				_context.SaveChanges();

				//Push Permit to ELPS
				elps_Approval.CategoryName = getCategory.Name;
				elps_Approval.Company_Id = Company.ELPS_ID.GetValueOrDefault();
				elps_Approval.Date_Expire = approval.DateExpired;
				elps_Approval.Date_Issued = approval.DateIssued;
				elps_Approval.OrderId = application.ReferenceNo;
				elps_Approval.Permit_No = approval.PermitNo;
				elps_Approval.Id = approval.Id;
				int elpsPermitId = 0;

				if (!PostPermit(elps_Approval, elpsPermitId))
				{
					throw new ArgumentException("Error Pushing Approval to ELPS!");
				}
				#endregion
				pm = approval.PermitNo;

				#region Send Mail
				var date = DateTime.Now;
				var dt = date.Day.ToString() + date.Month.ToString() + date.Year.ToString();
				var sn = string.Format("NUPRC/WKP/{0}/{1}", dt, application.CompanyID);
				var body = "";
				var up = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
				string file = up + @"\\Templates\" + letterTemplate;
				using (var sr = new StreamReader(file))
				{

					body = sr.ReadToEnd();
				}

				string subject = $"APPROVAL FOR WORK PROGRAM SUBMISSION FOR YEAR: {application.YearOfWKP}";
				var msgBody = string.Format(body, subject, Company.NAME, approval.PermitNo, approval.DateIssued.ToShortDateString(), approval.DateExpired.ToShortDateString(), DateTime.Now.Year);
				var emailMsg = SaveMessage(app.Id, app.CompanyID, subject, msgBody, "Company");
				var sendEmail = SendEmailMessage(Company.EMAIL, Company.NAME, emailMsg, null);
				#endregion

				return pm;
			}
			catch (Exception x)
			{
				LogMessages(x.ToString());
				return x.ToString();
			}
		}

		private string GeneratePermitNo(int appId, int catId, int appYear)
		{
			string no = "NUPRC/WKP/";
			string touse = string.Empty;

			Random rnd = new Random();

generate:
			int digits = rnd.Next(10001, 99999);

			switch (catId)
			{
				case 1:
					no += "NEW/";
					break;
				case 2:
					no += "MODIFICATION/";
					break;
				default:
					break;
			}
			var getCategory = _context.ApplicationCategories.Where(p => p.Id == catId).FirstOrDefault();

			if (getCategory.Name == GeneralModel.New)
				no += appYear.ToString().Substring(2, 2) + "/N{0}";
			else
				no += appYear.ToString().Substring(2, 2) + "/M{0}";

			touse = string.Format(no, digits.ToString("00000"));

			var check = _context.PermitApprovals.Where(p => p.PermitNo.ToLower() == touse.ToLower()).FirstOrDefault();
			//Check if the NO is not existing
			if (check == null)
			{
				return touse;
			}
			else
				goto generate;
		}
		public bool PostPermit(PermitAPIModel model, int elpsid)
		{
			var values = new JObject();
			values.Add("permit_No", model.Permit_No);
			values.Add("orderId", model.OrderId);
			values.Add("company_Id", model.Company_Id.ToString());
			values.Add("DateIssued", model.Date_Issued.ToString("yyyy-MM-ddTHH:mm:ss.fff"));
			values.Add("DateExpired", model.Date_Issued.AddYears(100).ToString("yyyy-MM-ddTHH:mm:ss.fff"));
			values.Add("categoryName", model.CategoryName);
			values.Add("is_Renewed", (model.Is_Renewed == "true") ? "Yes" : "No");
			values.Add("licenseId", model.Id.ToString());
			values.Add("id", 0);

			List<JObject> newDocs = new List<JObject>();

			var paramData = restSharpServices.parameterData("CompId", model.Company_Id.ToString());
			var savePermit = restSharpServices.Response("api/Permits/{CompId}/{email}/{apiHash}", paramData, "POST", values);

			if (savePermit.IsCompleted)
			{
				JObject eplsPermit = JsonConvert.DeserializeObject<JObject>(savePermit.Result.Content);

				var permit = _context.PermitApprovals.Where(x => x.Id == model.Id);

				if (permit.Count() > 0)
				{
					permit.FirstOrDefault().ElpsID = (int)eplsPermit.SelectToken("id");
					_context.SaveChanges();
					return true;
				}
				else
				{

					var application = _context.Applications.Where(a => a.ReferenceNo == model.OrderId).FirstOrDefault();
					if (application != null)
					{
						var field = _context.CONCESSION_SITUATIONs.Where(a => a.Id == application.FieldID).FirstOrDefault();
						CreatePermit(application);

						var permitApproval = _context.PermitApprovals.Where(x => x.AppID == application.Id);

						if (permitApproval.Count() > 0)
						{
							permitApproval.FirstOrDefault().ElpsID = (int)eplsPermit.SelectToken("id");
							_context.SaveChanges();
							return true;
						}

					}
					return true;

				}
			}
			else
			{
				return false;
			}
		}
		#endregion
		//Generating Application Reference Number
		public string Generate_Reference_Number()
		{
			lock (lockThis)
			{
				Thread.Sleep(1000);
				return "WKP" + DateTime.Now.ToString("MMddyyHHmmss");
			}
		}
		private Object lockThis = new object();
		//ApplicationProccess
		//public int RecordStaffDesk(int appID, DataModels.staff staf, string comapnyEmail)
		//{
		//	try
		//	{
		//		//if (appProcess != null)
		//		//{
		//		MyDesk drop = new MyDesk()

		//		{

		//			//ProcessID = appProcess.ProccessID,

		//			//Sort = (int)appProcess.Sort,

		//			AppId = appID,

		//			StaffID = staf.StaffID,

		//			FromStaffID = comapnyEmail,

		//			FromSBU = staf.Staff_SBU,
		//			FromRole=staf.RoleID,
		//			HasWork = false,

		//			HasPushed = false,

		//			CreatedAt = DateTime.Now

		//		};
		//		_context.MyDesks.Add(drop);

		//		if (_context.SaveChanges() > 0)
		//		{
		//			return 1;
		//		}
		//		//}
		//		return 0;
		//	}
		//	catch (Exception e)
		//	{
		//		return 0;
		//	}
		//}

		public int RecordStaffDesks(int appID, staff staff, int FromStaffID, int FromStaffSBU, int FromStaffRoleID, int processID)
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
					FromRoleId= FromStaffRoleID,
					HasWork = true,
					HasPushed = false,
					CreatedAt = DateTime.Now,
					ProcessStatus = STAFF_DESK_STATUS.SUBMISSION,
					LastJobDate = DateTime.Now,
				};
				_context.MyDesks.Add(drop);

				if (_context.SaveChanges() > 0)
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

		public async Task<List<ApplicationProcessModel>> GetApplicationProccess(string appType, int sortID = 0, int SBU_ID = 0)
		{
			try
			{
				var getStaff = new List<ApplicationProcessModel>();

				var applicationProcess = (from ap in _context.ApplicationProccesses
										  join cat in _context.ApplicationCategories on ap.CategoryID equals cat.Id
										  where cat.Name == appType && ap.Sort == sortID+1 && ap.DeleteStatus != true && cat.DeleteStatus != true
										  select ap).ToList();

				if (applicationProcess.Count() > 0)
				{
					if (sortID == 0) //new submission
					{
						var getSBUs = applicationProcess.Select(x => x.SBU_ID).Distinct();

						getStaff = (from sbu in getSBUs
									join stf in _context.staff on sbu equals stf.Staff_SBU
									join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
									join role in _context.Roles on stf.RoleID equals role.id
									where role.id == applicationProcess.FirstOrDefault().RoleID
									select new ApplicationProcessModel
									{
										SBU_Id = stf.Staff_SBU,
										StaffId = stf.StaffID,
										RoleId = (int)applicationProcess.FirstOrDefault().RoleID,
										RoleName = role.RoleName,
										Sort = (int)applicationProcess.FirstOrDefault().Sort,
										ProcessId = applicationProcess.FirstOrDefault().ProccessID,
										DeskCount = _context.MyDesks.Where(x => x.StaffID == stf.StaffID && x.HasWork != true).Count(),
									}).OrderBy(x => x.DeskCount).ToList();
					}
					else
					{
						getStaff = (from stf in _context.staff
									join admin in _context.ADMIN_COMPANY_INFORMATIONs on stf.AdminCompanyInfo_ID equals admin.Id
									join role in _context.Roles on stf.RoleID equals role.id
									where stf.Staff_SBU == SBU_ID && role.id == applicationProcess.FirstOrDefault().RoleID
									select new ApplicationProcessModel
									{
										SBU_Id = stf.Staff_SBU,
										StaffId = stf.StaffID,
										RoleId = (int)applicationProcess.FirstOrDefault().RoleID,
										RoleName = role.Description,
										Sort = (int)applicationProcess.FirstOrDefault().Sort,
										ProcessId = applicationProcess.FirstOrDefault().ProccessID,
										DeskCount = _context.MyDesks.Where(x => x.StaffID == stf.StaffID && x.HasWork != true).Count(),
									}).OrderBy(x => x.DeskCount).ToList();
					}
					if (getStaff.Count() > 0)
					{
						var minimum_DeskStaff = getStaff.GroupBy(x => x.SBU_Id).Select(x => x.FirstOrDefault()).ToList();

						return minimum_DeskStaff;
					}
				}

				return null;
			}
			catch (Exception e)
			{
				return null;
			}
		}

		public async Task<staff> GetStaffByStaffId(int staffId)
		{
			try
			{
				var getStaff = await _context.staff.FirstOrDefaultAsync(x => x.StaffID==staffId);
				if (getStaff ==null)
				{
					return null;
				}
				return getStaff;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}


		public async Task<MyDesk> GetStaffMyDesks(List<int> staffIds, int appId)
		{
			try
			{
				var staffDesks = new List<MyDesk>();

				foreach (var staffId in staffIds)
				{
					var desk = _context.MyDesks.Where(x => x.StaffID==staffId && x.AppId == appId && x.HasWork == false).FirstOrDefault();
					var desk_conflict = _context.MyDesks.Where(x => x.StaffID==staffId && x.AppId == appId && x.HasWork == true).FirstOrDefault();

					if(desk_conflict != null)
					{
						throw new Exception("This application has already been push to this desk.");
                    }
                    else if (desk != null)
					{
						staffDesks.Add(desk);
					}
					else
					{
						var newDesk = new MyDesk
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

						_context.MyDesks.Add(newDesk);

						var savedDesk = await _context.SaveChangesAsync();

						staffDesks.Add(newDesk);
					}

				}
				return staffDesks.OrderByDescending(x => x.LastJobDate).FirstOrDefault();
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
                    var desk = _context.MyDesks.Where(x => x.StaffID == staffId && x.AppId == appId).FirstOrDefault();
					var mostRecentJob = _context.MyDesks.Where(x => x.StaffID == staffId && x.HasWork == true).OrderByDescending(x => x.LastJobDate).FirstOrDefault();
                    //var desk_conflict = _context.MyDesks.Where(x => x.StaffID == staffId && x.AppId == appId && x.HasWork == true).FirstOrDefault();

                    if (desk != null)
                    {
                        throw new Exception("This application has already been push to this desk.");
                    }
                    else
                    {
						if(mostRecentJob == null)
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

                            _context.MyDesks.Add(tempDesk);

                            await _context.SaveChangesAsync();

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

                _context.MyDesks.Add(newDesk);
                
				await _context.SaveChangesAsync();

                return newDesk;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int> GetDeskIdByStaffIdAndAppId(int staffId, int appId)
		{
			try
			{
				var getDesk = await _context.MyDesks.Where(x => x.StaffID==staffId && x.AppId==appId).Select(x => x.DeskID).FirstOrDefaultAsync();
				if (getDesk >0)
				{
					return getDesk;
				}
				return 0;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public async Task<int> DeleteDeskIdByDeskId(int deskId)
		{
			try
			{
				var getDesk = _context.MyDesks.Where(x => x.DeskID==deskId).FirstOrDefault();
				if (getDesk !=null)
				{

					_context.MyDesks.Remove(getDesk);
					var save = await _context.SaveChangesAsync();

					if (save>0)
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

		public async Task<MyDesk> UpdateDeskAfterPush(MyDesk desk, string? comment, string? processStatus)
		{
			try
			{
                desk.HasPushed = true;
                desk.HasWork = false;
                desk.UpdatedAt = DateTime.Now;
                desk.Comment = comment;
                desk.ProcessStatus = processStatus;

				_context.MyDesks.Update(desk);

				return desk;
            }
			catch (Exception ex)
			{

				throw ex;
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

                _context.MyDesks.Update(desk);

                return desk;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<MyDesk> UpdateDeskAfterMove(MyDesk desk, string? comment, string? processStatus)
        {
            try
            {
                desk.HasPushed = false;
                desk.HasWork = false;
                desk.UpdatedAt = DateTime.Now;
                desk.Comment = comment;
                desk.ProcessStatus = processStatus;

                _context.MyDesks.Update(desk);

                return desk;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<int>> GetStaffByTargetRoleAndSBU(int targetedToRole, int targetedToSBU)
		{
			try
			{
				var getstaffs = await _context.staff.Where(x => x.RoleID==targetedToRole && x.Staff_SBU==targetedToSBU && x.DeleteStatus !=true).Select(x => x.StaffID).ToListAsync();

				return getstaffs;
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

				var applicationProcess = await _context.ApplicationProccesses.Where(x => x.TriggeredByRole==triggeredByRole && x.TriggeredBySBU==triggeredBySBU && x.ProcessAction==processAction && x.DeleteStatus !=true).ToListAsync();

				return applicationProcess;

			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public async Task<bool> hasApplicationBeenSubmittedBefore(int yearID, COMPANY_FIELD field, ADMIN_CONCESSIONS_INFORMATION concession)
		{
			var app = new Application();

			try
			{
				if (field != null)
				{
					app = await _context.Applications.Where<Application>(a => a.YearOfWKP == yearID && a.ConcessionID == concession.Consession_Id && a.FieldID == field.Field_ID).FirstOrDefaultAsync();
				}
				else
				{
					app = await _context.Applications.Where<Application>(a => a.YearOfWKP == yearID && a.ConcessionID == concession.Consession_Id).FirstOrDefaultAsync();
				}

				if (app != null) return true;
				else return false;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public async Task<List<staff>> GetReviewerStafff(List<ApplicationProccess> applicationProccesses)
		{
			try
			{
				var staffLists = new List<staff>();
				foreach (var item in applicationProccesses)
				{
                    var staffs = await _context.staff.Where(x => x.Staff_SBU == item.TargetedToSBU && x.RoleID == item.TargetedToRole).ToListAsync();

					if(staffs.Count <= 0)
					{
						break;
					}

					var isFound = false;
					var choosenStaff = staffs.Count > 0? staffs[0]: new staff();
					var choosenDesk = new MyDesk()
					{
						LastJobDate = DateTime.Now,
					};

					foreach(var staff in staffs)
					{
                        //var desk = (from stf in _context.staff
                        //            join dsk in _context.MyDesks on stf.StaffID equals dsk.StaffID
                        //            where stf.Staff_SBU == item.TargetedToSBU && stf.RoleID == item.TargetedToRole
                        //            select dsk).OrderBy(d => d.LastJobDate).FirstOrDefault();

						var desk = await _context.MyDesks.Where<MyDesk>(d => d.StaffID == staff.StaffID && d.HasWork == true).OrderByDescending(d => d.LastJobDate).FirstOrDefaultAsync();

						if(desk == null)
						{
							staffLists.Add(staff);
							isFound = true;
							break;
						}

						choosenStaff = desk.LastJobDate < choosenDesk.LastJobDate ? staff : choosenStaff;
						choosenDesk = desk.LastJobDate < choosenDesk.LastJobDate? desk: choosenDesk;
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
		public async Task<List<ApplicationProccess>> GetApplicationProccessByAction(string processAction)
		{
			try
			{
				//var getStaff = new List<ApplicationProcessModel>();

				//Get Processes by action
				var applicationProcesses = await _context.ApplicationProccesses.Where(x => x.ProcessAction==processAction).ToListAsync();

				//if (applicationProcesses.Count>0)
				//{
				//	return applicationProcesses;
				//}

				return applicationProcesses;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<ProcessFlowModel> GetAllSUBsFromProcessFlow(int ProcessFlowId)
		{
			try
			{
				var SBUs = new List<int?>();

				var triggeredBySBUIds = await _context.ApplicationProccesses.Where(x => x.ProccessID==ProcessFlowId).Select(x => x.TriggeredBySBU).Distinct().ToListAsync();

				var triggeredByRoleIds = await _context.ApplicationProccesses.Where(x => x.ProccessID==ProcessFlowId).Select(x => x.TriggeredByRole).Distinct().ToListAsync();

				var targetedBySBUIds = await _context.ApplicationProccesses.Where(x => x.ProccessID==ProcessFlowId).Select(x => x.TargetedToSBU).Distinct().ToListAsync();

				var targetedByRoleIds = await _context.ApplicationProccesses.Where(x => x.ProccessID==ProcessFlowId).Select(x => x.TargetedToRole).Distinct().ToListAsync();

				var processFlowModel = new ProcessFlowModel
				{
					TargetedBySUBId=targetedBySBUIds,
					TargetedByRoleId=targetedByRoleIds,
					TriggeredByRoleId=triggeredByRoleIds,
					TriggeredBySUBId=triggeredBySBUIds
				};

				return processFlowModel;

			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
		public async Task<List<int?>> GetAllRolesFromProcessFlow(int proccessFlowId)
		{
			try
			{
				var targetedRoles = await _context.ApplicationProccesses.Where(x => x.ProccessID==proccessFlowId).Select(x => x.TargetedToRole).Distinct().ToListAsync();

				return targetedRoles;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
		public async Task<List<staff>> GetStaffPerSBU(int SBUId)
		{
			try
			{
				var staff = await _context.staff.Where(x => x.Staff_SBU==SBUId).ToListAsync();

				return staff;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
		public async Task<List<int?>> GetAppWorkFlow(int appId, string action)
		{
			try
			{
				var SBUs = new List<int?>();

				SBUs= await _context.ApplicationProccesses.Where(x => x.ProccessID==appId && x.ProcessAction.ToLower().Trim()==action.ToLower().Trim()).Select(x => x.SBU_ID).Distinct().ToListAsync();



				return SBUs;

			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		//public async Task<List<int>> GetRoleBySBUId(int SBUId)
		//{
		//	try
		//	{

		//	}
		//	catch (Exception ex)
		//	{

		//		throw ex;
		//	}
		//}


		public void SaveHistory(int appid, int staffid, string status, string comment)
		{
			var getStaff = (from u in _context.staff where u.StaffID == staffid select u).FirstOrDefault();

			var appDeskHistory = new ApplicationDeskHistory()
			{
				//StaffEmail = getStaff.StaffEmail,
				AppId = appid,
				StaffID = staffid,
				Comment = comment == null ? "": comment,
				Status = status,
				CreatedAt = DateTime.Now,
				ActionDate = DateTime.Now,
			};

			_context.ApplicationDeskHistories.Add(appDeskHistory);
			_context.SaveChanges();
		}
		public void SaveHistory(int appid, int staffid, int triggeredFromRole, int targetedToRole, string status, string comment)
		{
			var getStaff = (from u in _context.staff where u.StaffID == staffid select u).FirstOrDefault();

			var appDeskHistory = new ApplicationDeskHistory()
			{
				//StaffEmail = getStaff.StaffEmail,
				AppId = appid,
				StaffID = staffid,
				Comment = comment,
				Status = status,
				CreatedAt = DateTime.Now,
				ActionDate = DateTime.Now,
			};

			_context.ApplicationDeskHistories.Add(appDeskHistory);
			_context.SaveChanges();
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
			_context.Messages.Add(messages);
			_context.SaveChanges();

			var msg = GetMessage(messages.id, userID);
			return msg;
		}
		public List<AppMessage> GetMessage(int msg_id, int seid)
		{

			var message = (from m in _context.Messages
						   join a in _context.Applications on m.AppId equals a.Id
						   join cm in _context.ADMIN_COMPANY_INFORMATIONs on a.CompanyID equals cm.Id
						   join ca in _context.ApplicationCategories on a.CategoryID equals ca.Id
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
		public string SendEmailMessage(string email_to, string email_to_name, List<AppMessage> AppMessages, byte[] attach)
		{
			var result = "";
			var password = _configuration.GetSection("SmtpSettings").GetSection("Password").Value.ToString();
			var username = _configuration.GetSection("SmtpSettings").GetSection("Username").Value.ToString();
			var emailFrom = _configuration.GetSection("SmtpSettings").GetSection("SenderEmail").Value.ToString();
			var Host = _configuration.GetSection("SmtpSettings").GetSection("Server").Value.ToString();
			var Port = Convert.ToInt16(_configuration.GetSection("SmtpSettings").GetSection("Port").Value.ToString());

			var msgBody = CompanyMessageTemplate(AppMessages);

			MailMessage _mail = new MailMessage();
			SmtpClient client = new SmtpClient(Host, Port);
			client.DeliveryMethod = SmtpDeliveryMethod.Network;

			client.UseDefaultCredentials = false;
			client.EnableSsl = true;
			client.Credentials = new System.Net.NetworkCredential(username, password);
			_mail.From = new MailAddress(emailFrom);
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
		public void LogMessages(string message, string user_id = null)
		{
			var auditTrail = new AuditTrail()
			{
				CreatedAt = DateTime.UtcNow,
				UserID = user_id,
				AuditAction = message
			};

			_context.AuditTrails.Add(auditTrail);
			_context.SaveChanges();

		}

		//public List<object> FilterData(int SBU_ID)
		//{


		//}

	}
}
