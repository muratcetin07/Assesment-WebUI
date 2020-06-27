using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration
{
    public static class IntegrationBase
    {
        public static string Post<T>(string endpoint, T inputParam, string token = null)
        {
            var client = new RestClient(endpoint);
            var request = new RestRequest(Method.POST);
            string jsonSerializedParam = JsonConvert.SerializeObject(inputParam);
            request.AddHeader("Content-Type", "application/json");
            if (!string.IsNullOrEmpty(token))
            {
                request.AddHeader("Authorization", "Bearer " + token);
            }
            request.AddParameter("undefined", jsonSerializedParam, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if(response?.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response?.Content;
            }

            return null;
        }

        public static string Get<T>(string endpoint, string token)
        {
            var client = new RestClient(endpoint);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + token);

            IRestResponse response = client.Execute(request);

            if (response?.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response?.Content;
            }

            return null;


        }
    }
}
