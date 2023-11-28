using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WKP.Infrastructure.GeneralServices
{
    public static class Utils
    {
        public static string Stringify(this object any) => JsonConvert.SerializeObject(any);

        public static string GetValue(this Dictionary<string, string> dic, string key)
            => dic.FirstOrDefault(x => x.Key.Equals(key, StringComparison.OrdinalIgnoreCase)).Value;

        public static object GetValue(this Dictionary<string, object> dic, string key)
            => dic.FirstOrDefault(x => x.Key.Equals(key, StringComparison.OrdinalIgnoreCase)).Value;

        public static TOut Parse<TOut>(this string any)
        {
            return JsonConvert.DeserializeObject<TOut>(any, new JsonSerializerSettings
            {
                Error = delegate (object sender, Newtonsoft.Json.Serialization.ErrorEventArgs args)
                {
                    args.ErrorContext.Handled = true;
                },
                Converters = { new IsoDateTimeConverter() }
            });
        }

        public static async Task<HttpResponseMessage> Send(string url, HttpRequestMessage message)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls 
                                                   | SecurityProtocolType.Tls11 
                                                   | SecurityProtocolType.Tls12;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                return await client.SendAsync(message);
            }
        }

        public static string GenerateSha512(this string inputString)
        {
            SHA512 sha512 = SHA512.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha512.ComputeHash(bytes);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }

        private static readonly Object lockThis = new object();

        public static string RefrenceCode()
        {
            lock (lockThis)
            {
                Thread.Sleep(1000);
                return $"214{DateTime.Now.ToString("MMddyyHHmmss")}";
            }
        }

        public static string ReadTextFile(string webrootpath, string filename)
        {
            string body;
            using (var sr = new StreamReader($"{webrootpath}\\Templates\\{filename}"))
            {
                body =  sr.ReadToEndAsync().Result;
            }
            return body;
        }

        public static string GenerateCompanyCode(string CompanyName)
		{
            var strIntitials = string.Empty;

            var companyNames = CompanyName.Split(' ');

            //check if company name has more than one string

            if (companyNames.Length <= 1)
            {
                strIntitials = CompanyName.Substring(0, 4);
            }
            else
            {
                foreach (var item in companyNames)
                {
                    if(item.length > 0)
                        strIntitials += item[0];
                }
            }

            //var rndmize=new Randomize
            var rnd = new Random();
            var firstRndNumber = rnd.Next(0, 9999).ToString().PadLeft(4, '0');
            var accessCaode = strIntitials.ToUpper() + firstRndNumber;

            return accessCaode;
		}
        
        // private static Byte[] BitmapToBytes(Bitmap img)
        // {
        //     using MemoryStream stream = new MemoryStream();
        //     img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
        //     return stream.ToArray();
        // }

        // public static Byte[] GenerateQrCode(string url)
        // {
        //     QRCodeGenerator qrGenerator = new QRCodeGenerator();
        //     QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
        //     QRCode qrCode = new QRCode(qrCodeData);
        //     Bitmap qrCodeImage = qrCode.GetGraphic(20);
        //     var imageResult = BitmapToBytes(qrCodeImage);
        //     return imageResult;
        // }
    }

}