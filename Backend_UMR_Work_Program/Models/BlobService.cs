using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Backend_UMR_Work_Program.DataModels;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

using static Backend_UMR_Work_Program.Models.GeneralModel;

namespace Backend_UMR_Work_Program.Models
{
	//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class BlobService
	{
		private readonly BlobServiceClient _blobServiceClient;
		string accessKey = string.Empty;
		private WKP_DBContext _context;
		public BlobService(BlobServiceClient blobServiceClient, IConfiguration config, WKP_DBContext context)
		{
			_blobServiceClient = blobServiceClient;
			this.accessKey = config.GetValue<string>("AzureBlobStorage");
			_context = context;
		}
		//private int? WKPCompanyNumber => Convert.ToInt32(User.FindFirstValue(ClaimTypes.PrimarySid));

		public string Filenamer(IFormFile file)
		{
			var name = Path.GetFileNameWithoutExtension(file.FileName);
			var ext = Path.GetExtension(file.FileName);

			var guid = Guid.NewGuid().ToString().Substring(2, 9);
			var span = DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds;
			Random rand = new Random();
			var regtext = name + span.ToString().Substring(0, 5) + guid + rand.Next(1000).ToString();
			var texo = System.Text.RegularExpressions.Regex.Replace(regtext, @"[^a-zA-Z0-9]", "");
			var goodname = texo + ext;
			return goodname;
		}

		public async Task<string> UploadFileBlobAsync(string blobContainerName, Stream content, string contentType, string fileName, string documentCategory, int WKPUserNumber, int yearOfWKP)
		{
			var containerClient = GetContainerClient(blobContainerName);
			var blobClient = containerClient.GetBlobClient(fileName);
			await blobClient.UploadAsync(content, new BlobHttpHeaders { ContentType = contentType });
			try
			{
				var checkIfDocExist = _context.SubmittedDocuments.Where(x => x.DocumentCategory == fileName && x.CreatedBy == WKPUserNumber.ToString() && x.YearOfWKP == yearOfWKP).FirstOrDefault();
				if (checkIfDocExist != null)
				{
					checkIfDocExist.DocSource = blobClient.Uri.AbsoluteUri;
					checkIfDocExist.UpdatedAt = DateTime.Now;
				}
				else
				{
					var subDoc = new SubmittedDocument()
					{
						DocSource = blobClient.Uri.AbsoluteUri,
						CreatedAt = DateTime.Now,
						CreatedBy = WKPUserNumber.ToString(),
						DocumentName = fileName,
						DocumentCategory = documentCategory,
						YearOfWKP = yearOfWKP
					};
					_context.SubmittedDocuments.Add(subDoc);
					_context.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
			return blobClient.Uri.AbsoluteUri;
		}

		public async Task<FileReturn> UploadFileBlobAsync(string blobContainerName, Stream content, string contentType, string fileName, long length)
		{
			var containerClient = GetContainerClient(blobContainerName);
			var blobClient = containerClient.GetBlobClient(fileName);
			await blobClient.UploadAsync(content, new BlobHttpHeaders { ContentType = contentType });
			var size = Lengther(length);

			//var storageAccount = CloudStorageAccount.Parse(accessKey);
			//var bloClient = storageAccount.CreateCloudBlobClient();
			//var serviceProperties = await bloClient.GetServicePropertiesAsync();
			//serviceProperties.DefaultServiceVersion = "2020-04-08";
			//await bloClient.SetServicePropertiesAsync(serviceProperties);

			return new FileReturn { fileId = fileName, fileSize = size, path = blobClient.Uri.AbsoluteUri };
		}

		private BlobContainerClient GetContainerClient(string blobContainerName)
		{
			var containerClient = _blobServiceClient.GetBlobContainerClient(blobContainerName);
			containerClient.CreateIfNotExists(PublicAccessType.Blob);
			return containerClient;
		}

		//public void Delete()
		//{
		//    FileNameList = fileName.Split(',').Where(t => t.ToString().Trim() != "").ToList();
		//}

		public async void DeleteOneFile(string fileUrl, string containerName)
		{
			Uri uriObj = new Uri(fileUrl);
			string BlobName = Path.GetFileName(uriObj.LocalPath);
			CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(accessKey);
			CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
			CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(containerName);
			CloudBlockBlob blockBlob = cloudBlobContainer.GetBlockBlobReference(BlobName);
			await blockBlob.DeleteAsync();
		}

		public async void DeleteOneFromDir(string fileUrl, string dirpath, string containerName)
		{
			Uri uriObj = new Uri(fileUrl);
			string BlobName = Path.GetFileName(uriObj.LocalPath);

			CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(accessKey);
			CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
			CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(containerName);

			//string pathPrefix = "postvideo" + "/";
			CloudBlobDirectory blobDirectory = cloudBlobContainer.GetDirectoryReference(dirpath + "/");
			// get block blob refarence    
			CloudBlockBlob blockBlob = blobDirectory.GetBlockBlobReference(BlobName);


			// delete blob from container        
			await blockBlob.DeleteAsync();
		}

		public async void DeleteManyFromDir(Dictionary<string, string> fileUrls, string containerName)
		{
			CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(accessKey);
			CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
			CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(containerName);


			foreach (KeyValuePair<string, string> file in fileUrls)
			{
				Uri uriObj = new Uri(file.Key);
				string BlobName = Path.GetFileName(uriObj.LocalPath);
				CloudBlobDirectory blobDirectory = cloudBlobContainer.GetDirectoryReference(file.Value + "/");
				CloudBlockBlob blockBlob = blobDirectory.GetBlockBlobReference(BlobName);
				await blockBlob.DeleteAsync();
			}
		}

		public async void DeleteManyFiles(List<string> fileUrls, string containerName)
		{
			CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(accessKey);
			CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
			CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(containerName);


			foreach (var file in fileUrls)
			{
				Uri uriObj = new Uri(file);
				string BlobName = Path.GetFileName(uriObj.LocalPath);
				CloudBlockBlob blockBlob = cloudBlobContainer.GetBlockBlobReference(BlobName);
				await blockBlob.DeleteAsync();
			}
		}

		public async Task<DownReturn> DownloadBlob(string contName, string fileName)
		{

			CloudBlockBlob blockBlob;
			await using (MemoryStream memoryStream = new MemoryStream())
			{
				string blobstorageconnection = accessKey;
				CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);
				CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
				CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(contName);
				blockBlob = cloudBlobContainer.GetBlockBlobReference(fileName);
				await blockBlob.DownloadToStreamAsync(memoryStream);
			}

			Stream blobStream = await blockBlob.OpenReadAsync();
			return new DownReturn { stream = blobStream, contentType = blockBlob.Properties.ContentType, name = blockBlob.Name };
		}

		public string DownloadBlobPath(string contName, string fileName)
		{
			var containerClient = GetContainerClient(contName);
			var blobClient = containerClient.GetBlobClient(fileName);
			return blobClient.Uri.AbsoluteUri;

		}

		public long Lengther(long length)
		{
			return Convert.ToInt64(Math.Round(length / 1024.0));
		}
	}
}