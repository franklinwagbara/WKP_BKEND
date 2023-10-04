using WKP.Application.Common.Interfaces;

namespace WKP.Infrastructure.GeneralServices
{
    public class RNGenerator : IRNGenerator
    {
        private Object lockThis = new object();

        public RNGenerator()
        {
        }

        public string Generate()
        {
            lock (lockThis)
            {
                Thread.Sleep(1000);
                return DateTime.Now.ToString("MMddyyHHmmss");
            }
        }
    }
}