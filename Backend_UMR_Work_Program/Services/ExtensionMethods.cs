using System.Collections.Generic;
using System.Linq;
using Backend_UMR_Work_Program.Services;
using static Backend_UMR_Work_Program.Models.ViewModel;

namespace Backend_UMR_Work_Program.Services
{
    public static class ExtensionMethods
    {
        public static IEnumerable<UserToken> WithoutPasswords(this IEnumerable<UserToken> users) {
            return users.Select(x => x.WithoutPassword());
        }

        public static UserToken WithoutPassword(this UserToken user) {
            // user.Password = null;
            return user;
        }
    }
}