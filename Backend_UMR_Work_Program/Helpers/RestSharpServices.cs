using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Backend_UMR_Work_Program.Helpers
{
    public class RestSharpServices
    {

        public static RestClient _client;
        public RestRequest _request;
        public Method _method;
        public string _url;
        ElpsServices elpsServices = new ElpsServices();



        public RestSharpServices()
        {
            RestClient restClient = new RestClient(ElpsServices._elpsBaseUrl);
            _client = restClient;
        }



        private Method restMethod(string methodType = null)
        {
            var method = methodType == "PUT" ? Method.Put : methodType == "POST" ? Method.Post : methodType == "DELETE" ? Method.Delete : Method.Get;
            return method;
        }


        private RestRequest ServiceRequest(string apiURL, string method = null)
        {
            _method = restMethod(method);
            var request = new RestRequest(apiURL, _method);
            return request;
        }


        private RestRequest AddParameters(string apiURL, string method = null, List<ParameterData> paramData = null)
        {
            var _request = ServiceRequest(apiURL, method);
            _request.AddUrlSegment("email", ElpsServices._elpsAppEmail);
            _request.AddUrlSegment("apiHash", ElpsServices.appHash);

            if (paramData != null)
            {
                foreach (var _paramData in paramData)
                {
                    _request.AddUrlSegment(_paramData.ParamKey, _paramData.ParamValue);
                }
            }


            return _request;
        }


        // For all request PUT, POST, GET 
        public async Task<RestResponse> Response(string apiURL, List<ParameterData> paramData = null, string method = null, object json = null, string ext = null)
        {

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            
                if (ext != null)
                {
                    _request = AddParameters(ElpsServices._elpsBaseUrl + apiURL + ext, method, paramData);
                }
                else
                {
                    _request = AddParameters(ElpsServices._elpsBaseUrl + apiURL, method, paramData);
                }
            
            _request.RequestFormat = DataFormat.Json;

            if (json != null)
            {
                _request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(json), ParameterType.RequestBody);
            }
            RestResponse _response = await _client.ExecuteAsync(_request);

            return _response;
        }

       
        public string ErrorResponse(RestResponse restResponse)
        {
            if (restResponse.ResponseStatus.ToString() == "Error")
            {
                return "A network related error has occured. Please try again";

                //return "A network related error has occured. Message : " + restResponse.ErrorException.Source.ToString() + " - " + restResponse.ErrorException.InnerException.Message.ToString() + " --- Error Code : " + restResponse.ErrorException.HResult;
            }
            else
            {
                return "A network related error has occured. Message : " + restResponse.ErrorException.ToString() + " - " + restResponse.ErrorException.InnerException?.Message.ToString() + " --- Error Code : " + restResponse.ErrorException.HResult;

            }
        }


        public List<ParameterData> parameterData(string key, string value)
        {
            var paramData = new List<ParameterData>();

            paramData.Add(new ParameterData
            {
                ParamKey = key,
                ParamValue = value
            });

            return paramData;
        }

    }
}
