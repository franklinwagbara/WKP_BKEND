namespace WKP.Application.Common
{
    public interface IRequestResult
    {
        IEnumerable<object> GetValue();
    }
}