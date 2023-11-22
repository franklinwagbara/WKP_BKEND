using RestSharp;

namespace WKP.Application.Common.Interfaces
{
    public interface IElpsConnect
    {
        RestResponse Post(RestRequest request);
        Task<string> Get(RestRequest request);
        RestResponse Put(RestRequest request);
        RestResponse Delete(RestRequest request);
    }
}