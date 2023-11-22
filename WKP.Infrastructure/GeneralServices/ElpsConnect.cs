using Microsoft.Extensions.Options;
using RestSharp;
using WKP.Application.Common.Interfaces;
using WKP.Domain.Entities;

namespace WKP.Infrastructure.GeneralServices
{
    public class ElpsConnect : IElpsConnect
    {
        private readonly AppSettings _appSettings;

        public ElpsConnect(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }

        public RestResponse Delete(RestRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Get(RestRequest request)
        {
            if(_appSettings.elpsBaseUrl == null)
                throw new Exception("Elps Base Url must be provided.");

            var client = new RestClient(_appSettings.elpsBaseUrl);
            var response = await client.ExecuteAsync(request);

            if(!response.IsSuccessful)
                throw new Exception("Error: Get request to Elps failed. ~~~ " + response.ErrorMessage);
            return response.Content;
        }

        public RestResponse Post(RestRequest request)
        {
            throw new NotImplementedException();
        }

        public RestResponse Put(RestRequest request)
        {
            throw new NotImplementedException();
        }
    }
}