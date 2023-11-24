using WKP.Application.Common.Interfaces;

namespace WKP.Infrastructure.GeneralServices
{
    public class UtilsInjectable : IUtilsInjectable
    {
        public string GenerateCompanyCode(string CompanyCode)
        {
            return Utils.GenerateCompanyCode(CompanyCode);
        }
    }
}