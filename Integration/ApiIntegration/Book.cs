using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.ApiIntegration
{
    public static class Book
    {
        public static DataResult<BookResponse> GetBooks(string token)
        {
            var loginResponse = new DataResult<BookResponse>(null) { Code = ResponseCode.BadRequest, Message = "unsuccessful" };

            var apiResponse = IntegrationBase.Get<BookResponse>(EndPoints.ApiEndpoints.GetBooks, token);
            if (apiResponse != null)
            {
                loginResponse = JsonConvert.DeserializeObject<DataResult<BookResponse>>(apiResponse);
            }

            return loginResponse;
        }
    }
}
