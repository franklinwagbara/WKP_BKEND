using System.Security.Cryptography;
using System.Text;

namespace Backend_UMR_Work_Program.Helpers
{
	public static class MyUtils
	{
		public static string GenerateSha512(string inputString)
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

		public static string ElpsHasher(string appemail, string appid) => GenerateSha512($"{appemail}{appid}");

    }
}
