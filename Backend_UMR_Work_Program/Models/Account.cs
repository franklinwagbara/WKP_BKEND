using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using static Backend_UMR_Work_Program.Models.ViewModel;

namespace Backend_UMR_Work_Program.Models
{
	public class Account
	{
		private string? Email, Password;
		private string? CompanyEmail, CompanyName, Name, CompanyId, ContractType;
		private string? id, COMPANYNAME, chairperson, scribe, presentation_date, presentation_time, meeting_room, days_to_go, system_date;
		private string? myOldCompanyCode, myNewCompanyCode, myEmail, myPopText, myIsValid;

		private readonly AppSettings _appSettings;
		//private IConfiguration _configuration;
		private Connection mycon;
		public WKP_DBContext _context;

		public Account(IOptions<AppSettings> appSettings, Connection connection, WKP_DBContext context)
		{
			_appSettings = appSettings.Value;
			mycon = connection;
			_context = context;
		}

		private string Encrypt(string clearText)
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



		public async Task<UserToken> isAutheticate(string? email, string? password)
		{
			try
			{
				this.Email = email.ToLower();
				this.Password = password;
				if (await CheckEmail(email))
				{
					var getUser = await (from a in _context.ADMIN_COMPANY_INFORMATIONs where a.EMAIL.ToLower().Trim().Equals(email.ToLower().Trim()) && a.STATUS_.ToLower() == "activated" && !a.EMAIL.Contains(".gov.ng") select a).FirstOrDefaultAsync();
					if (getUser != null)
					{
						getUser.LAST_LOGIN_DATE = DateTime.Now;
						_context.Entry(getUser).State = EntityState.Modified;
						await _context.SaveChangesAsync();
						var concessionInfo = await (from c in _context.ADMIN_CONCESSIONS_INFORMATIONs where c.COMPANY_EMAIL == email.Trim() select c).FirstOrDefaultAsync();
						var contractType = concessionInfo?.Contract_Type ?? "";
						var companyName = "Company";
						#region add staff to staff table for application process flow
						if (companyName == GeneralModel.Admin)
						{
							var getStaff = (from stf in _context.staff
											where (stf.AdminCompanyInfo_ID == getUser.Id || stf.StaffEmail == getUser.EMAIL) && stf.DeleteStatus != true
											select stf).FirstOrDefault();
							if (getStaff != null)
							{
								getStaff.AdminCompanyInfo_ID = getStaff.AdminCompanyInfo_ID;
								int saved = await _context.SaveChangesAsync();
							}
							else
							{
								staff staff = new staff()
								{
									StaffElpsID = "123456",
									Staff_SBU = 0,
									RoleID = 0,
									LocationID = 0,
									UpdatedBy = 0,
									AdminCompanyInfo_ID= getUser.Id,
									StaffEmail = getUser.EMAIL.Trim(),
									FirstName = getUser.COMPANY_NAME.ToUpper(),
									LastName = getUser.COMPANY_NAME.ToUpper(),
									CreatedAt = DateTime.Now,
									ActiveStatus = true,
									DeleteStatus = false,
								};

								_context.staff.Add(staff);
								int saved = await _context.SaveChangesAsync();
							}
						}
						#endregion
						var tokenHandler = new JwtSecurityTokenHandler();
						var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
						var tokenDescriptor = new SecurityTokenDescriptor
						{
							Subject = new ClaimsIdentity(new Claim[]
							{
								new Claim(ClaimTypes.Name, getUser.COMPANY_NAME ?? ""),
								new Claim(ClaimTypes.Email, getUser.EMAIL ?? ""),
								new Claim(ClaimTypes.NameIdentifier, getUser.COMPANY_ID ?? ""),
								new Claim(ClaimTypes.GivenName, getUser?.NAME ?? ""),
								new Claim(ClaimTypes.Role, companyName),
								new Claim(ClaimTypes.PrimarySid, getUser.Id.ToString() ?? ""),
							}),
							Expires = DateTime.UtcNow.AddDays(7),
							SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
						};

						//Added by Musa for Testing
						//GeneralModel.CompanyId=getUser.COMPANY_ID;

						var token = tokenHandler.CreateToken(tokenDescriptor);
						UserToken tok = new UserToken { CompanyId = getUser.COMPANY_ID, CompanyName = getUser.COMPANY_NAME, CompanyEmail = getUser.EMAIL, CompanyNumber = getUser.CompanyNumber, Name = getUser.NAME, ContractType = contractType, token = tokenHandler.WriteToken(token), code = 1 };
						return tok;
					}
					return new UserToken { code = 2 };
				}
				return new UserToken { code = 3 };


			}
			catch (Exception ex)
			{
				return new UserToken { code = 0 };
			}
		}

		public async Task<UserToken> AutheticateById(int id)
		{
			try
			{
				if (id>0)
				{
					var getUser = await (from a in _context.ADMIN_COMPANY_INFORMATIONs where a.Id == id && a.STATUS_.ToLower() == "activated" select a).FirstOrDefaultAsync();

					if (getUser != null)
					{

						var companyName = getUser?.COMPANY_NAME == "Admin" ? "Admin" : "Company";

						var tokenHandler = new JwtSecurityTokenHandler();
						var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
						var tokenDescriptor = new SecurityTokenDescriptor
						{
							Subject = new ClaimsIdentity(new Claim[]
							{
								new Claim(ClaimTypes.Name, getUser.COMPANY_NAME ?? ""),
								new Claim(ClaimTypes.Email, getUser.EMAIL ?? ""),
								new Claim(ClaimTypes.NameIdentifier, getUser.COMPANY_ID ?? ""),
								new Claim(ClaimTypes.GivenName, getUser?.NAME ?? ""),
								new Claim(ClaimTypes.Role, companyName),
								new Claim(ClaimTypes.PrimarySid, getUser.Id.ToString() ?? ""),
							}),
							Expires = DateTime.UtcNow.AddDays(7),
							SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
						};

						//Added by Musa for Testing
						//GeneralModel.CompanyId=getUser.COMPANY_ID;

						var token = tokenHandler.CreateToken(tokenDescriptor);
						UserToken tok = new UserToken { CompanyId = getUser.COMPANY_ID, CompanyName = getUser.COMPANY_NAME, CompanyEmail = getUser.EMAIL, CompanyNumber = getUser.Id, Name = getUser.NAME, token = tokenHandler.WriteToken(token), code = 1 };
						return tok;
					}
					else
					{
						var getStaff = await (from a in _context.staff where a.StaffID == id select a).FirstOrDefaultAsync();

						if (getStaff != null)
						{
							var tokenHandler = new JwtSecurityTokenHandler();
							var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
							var tokenDescriptor = new SecurityTokenDescriptor
							{
								Subject = new ClaimsIdentity(new Claim[]
								{
								new Claim(ClaimTypes.Name, getStaff.FirstName+ " " + getStaff.LastName ?? ""),
								new Claim(ClaimTypes.Email, getStaff.StaffEmail ?? ""),
								new Claim(ClaimTypes.PrimarySid, getStaff.StaffID.ToString() ?? ""),
								}),
								Expires = DateTime.UtcNow.AddDays(7),
								SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
							};

							//Added by Musa for Testing
							//GeneralModel.CompanyId=getUser.COMPANY_ID;

							var token = tokenHandler.CreateToken(tokenDescriptor);
							UserToken tok = new UserToken { CompanyId = getUser.COMPANY_ID, CompanyName = getUser.COMPANY_NAME, CompanyEmail = getUser.EMAIL, CompanyNumber = getUser.CompanyNumber, Name = getUser.NAME, /*ContractType = contractType,*/ token = tokenHandler.WriteToken(token), code = 1 };
							return tok;
						}
						return new UserToken { code = 2 };
					}
				}
				return new UserToken { code=3 };
			}
			catch (Exception ex)
			{
				return new UserToken { code = 0 };
			}
		}


		public async Task<bool> CheckEmail(string email)
		{
			var getUser = await (from a in _context.ADMIN_COMPANY_INFORMATIONs where a.EMAIL == email.Trim() select a).FirstOrDefaultAsync();

			if (getUser == null)
			{
				return false;
			}
			return true;
		}

		public object GetData()
		{
			var code = "1295";
			var data = _context.ADMIN_DATETIME_PRESENTATIONs.FromSqlRaw("Select * from ADMIN_DATETIME_PRESENTATION where COMPANY_ID = '" + code + "'").FirstOrDefault();
			//var data = (from c in _context.ADMIN_DATETIME_PRESENTATIONs where c.COMPANY_ID == code select c).FirstOrDefault();
			// using (SqlConnection con = new SqlConnection(this.mycon.Myconnection))
			// {
			//     SqlCommand cmd = new SqlCommand();
			//     cmd = new SqlCommand("Select * from ADMIN_DATETIME_PRESENTATION where COMPANY_ID = '" + code + "'", con);

			//     cmd.CommandType = CommandType.Text;
			//     cmd.Connection = con;
			//     con.Open();

			//     SqlDataAdapter da = new SqlDataAdapter();
			//     da.SelectCommand = cmd;
			//     DataSet ds = new DataSet();
			//     da.Fill(ds, "ADMIN_COMPANY_INFORMATION");

			//     DataTable dt = ds.Tables[0];
			//     int rowCount = dt.Rows.Count;
			//     //SqlDataAdapter da = new SqlDataAdapter("Select * from ADMIN_DATETIME_PRESENTATION where COMPANY_ID = '" + code + "'", con);
			//     //   SqlDataAdapter da = new SqlDataAdapter("Select * from ADMIN_DATETIME_PRESENTATION where id = 117 ", con);
			//     //DataTable result = new DataTable();

			//     //da.Fill(result);
			//     return dt;
			// }
			return data;

		}


		public async Task<object> VerifyCompanyCode(string companycode)
		{

			var getCode = await (from c in _context.ADMIN_COMPANY_CODEs where c.CompanyCode == companycode.Trim() && c.IsActive == "YES" select c).FirstOrDefaultAsync();
			if (getCode == null)
			{
				return new { isValid = false, errorText = "Verification Code does not exist in our database..Please contact NUPRC Admin" };
			}
			else
			{
				if (string.IsNullOrEmpty(getCode.GUID))
				{
					return new { isValid = true, isGuid = false };
				}
				return new { isValid = true, isGuid = true, companyName = getCode.CompanyName, companyCode = getCode.CompanyCode };
			}
		}

		public async Task<object> CheckNewPinCode(string oldCompanycode, string email, string newCompanyCode)
		{
			myNewCompanyCode = newCompanyCode;
			myOldCompanyCode = oldCompanycode;
			myEmail = email;
			var getCode = await (from c in _context.ADMIN_COMPANY_CODEs where c.CompanyCode == newCompanyCode.Trim() select c).FirstOrDefaultAsync();
			if (getCode == null)
			{
				var isVerified = await VerifyCompanyCode_GenerateUniqueCode(oldCompanycode, email, newCompanyCode);
				if (isVerified)
				{
					return new { isValid = true, popText = myPopText, companyCode = myNewCompanyCode, companyName = CompanyName };
				}
				else
				{
					return new { isValid = false, popText = myPopText };
				}

			}
			else
			{
				myPopText = "Please try another new company code";
				return new { isValid = false, popText = myPopText };
			}
		}

		private async Task<bool> VerifyCompanyCode_GenerateUniqueCode(string oldCompanycode, string email, string newCompanyCode)
		{
			var getCode = await (from c in _context.ADMIN_COMPANY_CODEs where c.CompanyCode == oldCompanycode.Trim() && c.IsActive == "YES" select c).FirstOrDefaultAsync();
			//SqlCommand spcmd = new SqlCommand(" Select * from ADMIN_COMPANY_CODE  WHERE  CompanyCode =  '" + TextBox1.Text.Trim() + "' AND IsActive = 'YES' ", con);

			if (getCode != null)
			{
				await Update_GUID(oldCompanycode, email, newCompanyCode);

				await Update_ADMIN_CONCESSIONS_INFORMATION(oldCompanycode, newCompanyCode);

				await Send_New_Company_Code(newCompanyCode);

				myPopText = " Your New Company Code have been sent to the email address you provided";
				return true;
				//Server.Transfer("companyresource.aspx");
			}
			else
			{
				myPopText = "Company Code does not exist ... Please contact NUPRC Admin";
				return false;
			}
		}

		private async Task<int> Update_GUID(string oldCompanycode, string email, string newCompanyCode)
		{
			string GUID = Guid.NewGuid().ToString();
			var getCode = await (from c in _context.ADMIN_COMPANY_CODEs where c.CompanyCode == oldCompanycode.Trim() select c).FirstOrDefaultAsync();
			getCode.Email = email.Trim();
			getCode.GUID = GUID;
			getCode.Date_Updated = DateTime.Now;
			getCode.CompanyCode = newCompanyCode;
			_context.Entry(getCode).State = EntityState.Modified;
			return await _context.SaveChangesAsync();
			//cmd.CommandText = "Update ADMIN_COMPANY_CODE  SET  GUID = '" + GUID + "' ,  Email  = '" + TextBox2.Text.Trim() + "' , CompanyCode  = '" + TextBox3.Text.Trim() + "' , Date_Updated = '" + system_date + "'    WHERE  CompanyCode  = '" + TextBox1.Text.Trim() + "' ";
		}

		private async Task<int> Update_ADMIN_CONCESSIONS_INFORMATION(string oldCompanycode, string newCompanyCode)
		{
			string GUID = Guid.NewGuid().ToString();
			var getCode = await (from c in _context.ADMIN_CONCESSIONS_INFORMATIONs where c.Company_ID == oldCompanycode.Trim() select c).FirstOrDefaultAsync();
			getCode.Date_Updated = DateTime.Now;
			getCode.Company_ID = newCompanyCode.Trim();
			_context.Entry(getCode).State = EntityState.Modified;
			return await _context.SaveChangesAsync();
		}

		private async Task<int> Send_New_Company_Code(string newCompanyCode)
		{

			var getCode = await (from c in _context.ADMIN_COMPANY_CODEs where c.CompanyCode == newCompanyCode.Trim() && c.IsActive == "YES" select c).FirstOrDefaultAsync();
			//SqlCommand spcmd = new SqlCommand(" Select * from ADMIN_COMPANY_CODE  WHERE  CompanyCode =  '" + TextBox3.Text.Trim() + "' AND IsActive = 'YES' ", con);

			if (getCode != null)
			{
				myNewCompanyCode = getCode.CompanyCode;
				CompanyName = getCode.CompanyName;

				if (getCode?.Email != "")
				{
					New_Code_Email_Notification();
				}
			}
			else
			{
				myPopText = "Verification Code does not exist .. Please contact NUPRC Admin";
			}
			return 1;
		}

		private void New_Code_Email_Notification()
		{
			// Start 

			string subject = "Work Program New Company Code";

			string nes_body = "See New Company Code Below to profile resouce(s)";

			//string company_operator_name = Session["CN"].ToString();
			//string company_rep_name = TextBox1.Text;
			//string Email = TextBox4.Text;
			//string Password = TextBox5.Text;
			string Applink = "Click <a href= https://workprogram.nuprc.gov.ng > HERE</a> to login to Work Program Application";

			string URLComment = "";



			string to = myEmail; // "anthony.nwosu@brandonetech.com"; //To address    
			string from = "no-reply@nuprc.gov.ng"; //From address    
			MailMessage message = new MailMessage(from, to);

			string mailbody = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


				"<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

				+ "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

				+ "<b>" + " Workprogam Notification - New company code " + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

				+ "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#00a65a>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"


				  + "<p>" + "</p>"  //  This will give a paragraph

				+ "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"

				 + "Dear " + myEmail + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "

				   + "<p>" + "  " + nes_body + "</p>"

				   + "<p>" + "<b>" + " New Company Code : " + "</b> " + myNewCompanyCode + "</p>"

					   + "<p>" + " " + Applink + "</p>"

					  + URLComment + "<p>" + " Please contact NUPRC Work Program Team for any help. " + "</p>" + "</span>" + "</p>" + "<p>"

					  + URLComment + "<p>" + " Thank you " + "</p>" + "</span>"

					  + "</p>" + "<p>" + "</b></span>" + "</p>"

				 //  + "<p><span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">" + " " + "<br>" + " " + "<br>"

				 + "<p><span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">" + " " + "<br>"


				+ "Note: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=3 align=left valign=top  bgcolor=#00a65a>"

				+ "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=11  bgcolor=#FFFFFF>"


				+ "<span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

				+ "&copy;" + " 2021 Powered by NUPRC Work Program Team"

				+ "</span>"


				+ "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";

			message.Subject = subject;
			message.Body = mailbody;
			message.BodyEncoding = Encoding.UTF8;
			message.IsBodyHtml = true;
			SmtpClient client = new SmtpClient("email-smtp.us-east-2.amazonaws.com", 587); //Gmail smtp    
			System.Net.NetworkCredential basicCredential1 = new
			System.Net.NetworkCredential("AKIAQCM2OPFBSV5LH3U7", "BJIdfFWQCb/fdKYej/Mw6EfHK3QJ9XPJ9k6UwHLcjjsu");
			client.EnableSsl = true;
			client.UseDefaultCredentials = false;
			client.Credentials = basicCredential1;
			client.DeliveryMethod = SmtpDeliveryMethod.Network;
			try
			{
				client.Send(message);
			}

			catch (Exception ex)
			{
				//throw ex;
			}
		}

		public async Task<List<ADMIN_COMPANY_INFORMATION?>> GetCompanyResource(string compCode)
		{
			var getInfo = await (from c in _context.ADMIN_COMPANY_INFORMATIONs where c.COMPANY_ID == compCode.Trim() && c.STATUS_ == "Activated" select c).ToListAsync();
			return getInfo;
		}

		public async Task<object> CheckIfUserExistBeforeCreating(string? compName, string? compCode, string? name, string? designation, string? phone, string? email, string? password)
		{
			myPopText = "";
			var getInfo = await (from c in _context.ADMIN_COMPANY_INFORMATIONs where c.EMAIL == email.Trim() && c.STATUS_ == "Activated" select c).FirstOrDefaultAsync();
			if (getInfo != null)
			{
				myPopText = "User with email already Exist";
				return new { isValid = false, popText = myPopText };
			}
			else
			{

				await Insert_ADMIN_COMPANY_INFORMATION(compName, compCode, name, designation, phone, email, password, 0);
				var resourceData = await GetCompanyResource(compCode);
				Send_Email_to_Profiled_User(compName, compCode, name, designation, phone, email, password);
				myPopText = "User Created";
				return new { isValid = true, popText = myPopText, data = resourceData };
			}
		}

		public async Task<int> Insert_ADMIN_COMPANY_INFORMATION(string compName, string compCode, string name, string designation, string phone, string email, string password, int elpsID)
		{
			var newInfo = new ADMIN_COMPANY_INFORMATION { ELPS_ID= elpsID, COMPANY_NAME = compName, COMPANY_ID = compCode, EMAIL = email, PASSWORDS = Encrypt(password), NAME = name, DESIGNATION = designation, PHONE_NO = phone, STATUS_ = "Activated", Created_by = compName, Date_Created = DateTime.Now };
			try
			{
				await _context.ADMIN_COMPANY_INFORMATIONs.AddAsync(newInfo);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				general_error_log icheck = new general_error_log();
				icheck.call_general_error_log(ex, email, "insert into ADMIN_COMPANY_INFORMATION");
			}
			return 1;
		}

		private void Send_Email_to_Profiled_User(string compName, string compCode, string name, string designation, string phone, string email, string password)
		{
			// Start 

			string subject = "Work Programme Login Credentials";

			string nes_body = "See Login Credentials Below";

			string company_operator_name = compName;
			string company_rep_name = name;
			string Email = email;
			string Password = password;
			string Applink = "Click <a href= https://workprogram.nuprc.gov.ng > HERE</a> to login to Work Program Application. Please change password for security reasons";

			string URLComment = "";

			string to = email;// "anthony.nwosu@brandonetech.com"; //To address

			string from = "no-reply@nuprc.gov.ng"; //From address 

			MailMessage message = new MailMessage(from, to);

			string mailbody = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


				"<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

				+ "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

				+ "<b>" + " Workprogam Notification " + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

				+ "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#00a65a>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"


				  + "<p>" + "</p>"  //  This will give a paragraph

				+ "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"

				 + "Dear " + company_rep_name + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


				   + "<p>" + "  " + nes_body + "</p>"

				   + "<p>" + "<b>" + " Company Name : " + "</b> " + company_operator_name + "</p>"
				   + "<p>" + "<b>" + " Login Email : " + "</b> " + Email + "</p>"
				   + "<p>" + "<b>" + " Password : " + "</b> " + Password + "</p>"

					   + "<p>" + " " + Applink + "</p>"

					  + URLComment + "<p>" + " Please contact NUPRC Work Programme Team for any help. " + "</p>" + "</span>" + "</p>" + "<p>"

					  + URLComment + "<p>" + " Thank you " + "</p>" + "</span>"

					  + "</p>" + "<p>" + "</b></span>" + "</p>"

				 //  + "<p><span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">" + " " + "<br>" + " " + "<br>"

				 + "<p><span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">" + " " + "<br>"


				+ "Note: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=3 align=left valign=top  bgcolor=#00a65a>"

				+ "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=11  bgcolor=#FFFFFF>"


				+ "<span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

				+ "&copy;" + " 2021 Powered by NUPRC Work Program Team"

				+ "</span>"

				+ "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";

			message.Subject = subject;
			message.Body = mailbody;
			message.BodyEncoding = Encoding.UTF8;
			message.IsBodyHtml = true;
			SmtpClient client = new SmtpClient("email-smtp.us-east-2.amazonaws.com", 587); //Gmail smtp             
			System.Net.NetworkCredential basicCredential1 = new
			System.Net.NetworkCredential("AKIAQCM2OPFBSV5LH3U7", "BJIdfFWQCb/fdKYej/Mw6EfHK3QJ9XPJ9k6UwHLcjjsu");
			client.EnableSsl = true;
			client.UseDefaultCredentials = false;
			client.Credentials = basicCredential1;
			client.DeliveryMethod = SmtpDeliveryMethod.Network;
			try
			{
				client.Send(message);
			}
			catch (Exception ex)
			{
				//throw ex;
			}


			// End
		}

		public async Task<List<ADMIN_COMPANY_INFORMATION?>> DeleteUser(string compCode, string Id)
		{

			var getInfo = await (from c in _context.ADMIN_COMPANY_INFORMATIONs where c.COMPANY_ID == compCode select c).FirstOrDefaultAsync();
			//System.Data.SqlClient.SqlCommand cmd2 = new SqlCommand("Select * from  ADMIN_COMPANY_INFORMATION  WHERE  COMPANY_ID = '" + compCode.ToString() + "' ", cnn2);
			if (getInfo != null)
			{
				var compInfo = await _context.ADMIN_COMPANY_INFORMATIONs.FindAsync(Convert.ToInt32(Id));
				_context.ADMIN_COMPANY_INFORMATIONs.Remove(compInfo);
				await _context.SaveChangesAsync();
				return await GetCompanyResource(compCode);
			}
			return null;
		}

		public async Task<object> ReturnPasswordInfo(string email)
		{
			var getInfo = await (from c in _context.ADMIN_COMPANY_INFORMATIONs where c.EMAIL == email select c).FirstOrDefaultAsync();
			//SqlCommand spcmd = new SqlCommand(" Select * from ADMIN_COMPANY_INFORMATION  WHERE  EMAIL =  '" + TextBox1.Text + "'  ", con);

			try
			{
				if (getInfo != null)
				{
					var myPassword = Decrypt(getInfo.PASSWORDS);
					Work_Program_Email_Notification_When_Password_is_Changed(email, myPassword, getInfo.COMPANY_NAME);
					myPopText = " Your Password have been sent to email address specified .. Please login and change your password";
					return new { isValid = true, popText = myPopText };
				}
				else
				{
					myPopText = "Email does not exist in our database .. Please check and try again";
					return new { isValid = false, popText = myPopText };
				}
			}
			catch (Exception ex)
			{
				string myMsgErr = ex.Message;
				return new { isValid = false, popText = myMsgErr };
			}
		}

		private void Work_Program_Email_Notification_When_Password_is_Changed(string email, string password, string compName)
		{

			string subject = "Forgot Password Notification";

			string nes_body = "See Password Below";

			string company_operator_name = compName;
			string company_rep_name = email;
			//string Email = TextBox4.Text;
			//string Password = TextBox5.Text;
			string Applink = "Click <a href= https://workprogram.nuprc.gov.ng > HERE</a> to login to Work Program Application. Please change password for security reasons";

			string URLComment = "";



			string to = email;// "anthony.nwosu@brandonetech.com"; //To address    
			string from = "no-reply@nuprc.gov.ng"; //From address    
			MailMessage message = new MailMessage(from, to);

			string mailbody = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


				"<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

				+ "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

				+ "<b>" + " Workprogam Notification " + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

				+ "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#00a65a>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"


				  + "<p>" + "</p>"  //  This will give a paragraph

				+ "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"

				 + "Dear " + company_rep_name + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


				   //+ "</p>" + " Notification of Request - see below details" + "</p>" + "<p>"

				   //  + "<p>" + " " + "<b>" + notification_header + "</b>" + "</p>" + "<p>"   Company_operator_name

				   + "<p>" + "  " + nes_body + "</p>"

				   + "<p>" + "<b>" + " Password : " + "</b> " + password + "</p>"

					   + "<p>" + " " + Applink + "</p>"

					  + URLComment + "<p>" + " Please contact NUPRC Work Programme Team for  any help. " + "</p>" + "</span>" + "</p>" + "<p>"

					  + URLComment + "<p>" + " Thank you " + "</p>" + "</span>"

					  + "</p>" + "<p>" + "</b></span>" + "</p>"

				 //  + "<p><span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">" + " " + "<br>" + " " + "<br>"

				 + "<p><span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">" + " " + "<br>"


				+ "Note: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=3 align=left valign=top  bgcolor=#00a65a>"

				+ "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=11  bgcolor=#FFFFFF>"


				+ "<span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

				+ "&copy;" + " 2021 Powered by NUPRC Work Program Team"

				+ "</span>"


				+ "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";

			message.Subject = subject;
			message.Body = mailbody;
			message.BodyEncoding = Encoding.UTF8;
			message.IsBodyHtml = true;
			SmtpClient client = new SmtpClient("email-smtp.us-east-2.amazonaws.com", 587); //Gmail smtp    
			System.Net.NetworkCredential basicCredential1 = new
			System.Net.NetworkCredential("AKIAQCM2OPFBSV5LH3U7", "BJIdfFWQCb/fdKYej/Mw6EfHK3QJ9XPJ9k6UwHLcjjsu");
			client.EnableSsl = true;
			client.UseDefaultCredentials = false;
			client.Credentials = basicCredential1;
			client.DeliveryMethod = SmtpDeliveryMethod.Network;
			try
			{
				client.Send(message);
			}

			catch (Exception ex)
			{
				//throw ex;
			}
		}
	}
}