using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.ApiIntegration
{
    public static class User
    {
        public static DataResult<UserSubscriptionListResponse> GetSubscriptionList(string token)
        {
            var loginResponse = new DataResult<UserSubscriptionListResponse>(null) { Code = ResponseCode.BadRequest, Message = "unsuccessful" };

            var apiResponse = IntegrationBase.Get<UserSubscriptionListResponse>(EndPoints.ApiEndpoints.GetSubscriptions, token);
            if (apiResponse != null)
            {
                loginResponse = JsonConvert.DeserializeObject<DataResult<UserSubscriptionListResponse>>(apiResponse);
            }

            return loginResponse;
        }

        public static DataResult<SubscribeResponse> Subscribe(SubscribeRequest subscribeRequest, string token)
        {
            var subscribeResponse = new DataResult<SubscribeResponse>(null) { Code = ResponseCode.BadRequest, Message = "unsuccessful" };

            var apiResponse = IntegrationBase.Post<SubscribeRequest>(EndPoints.ApiEndpoints.Subscribe, subscribeRequest, token);
            if (apiResponse != null)
            {
                subscribeResponse = JsonConvert.DeserializeObject<DataResult<SubscribeResponse>>(apiResponse);
            }

            return subscribeResponse;
        }

        public static DataResult<SubscribeResponse> Unsubscribe(SubscribeRequest subscribeRequest, string token)
        {
            var subscribeResponse = new DataResult<SubscribeResponse>(null) { Code = ResponseCode.BadRequest, Message = "unsuccessful" };

            var apiResponse = IntegrationBase.Post<SubscribeRequest>(EndPoints.ApiEndpoints.Subscribe, subscribeRequest, token);
            if (apiResponse != null)
            {
                subscribeResponse = JsonConvert.DeserializeObject<DataResult<SubscribeResponse>>(apiResponse);
            }

            return subscribeResponse;
        }
    }
}
