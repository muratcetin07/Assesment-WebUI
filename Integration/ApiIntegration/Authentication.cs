using Newtonsoft.Json;

namespace Integration.ApiIntegration
{
    public static class Authentication
    {
        
        public static DataResult<LoginResponse> Login(LoginRequest loginRequest)
        {
            var loginResponse = new DataResult<LoginResponse>(null) { Code = ResponseCode.BadRequest, Message = "unsuccessful" };

            var apiResponse = IntegrationBase.Post<LoginRequest>(EndPoints.ApiEndpoints.Login, loginRequest);
            if(apiResponse != null)
            {
                loginResponse = JsonConvert.DeserializeObject<DataResult<LoginResponse>>(apiResponse);
            }

            return loginResponse;
        }

        public static DataResult<RegisterResponse> Register(RegisterRequest registerRequest)
        {
            var loginResponse = new DataResult<RegisterResponse>(null) { Code = ResponseCode.BadRequest, Message = "unsuccessful" };

            var apiResponse = IntegrationBase.Post<RegisterRequest>(EndPoints.ApiEndpoints.Register, registerRequest);
            if (apiResponse != null)
            {
                loginResponse = JsonConvert.DeserializeObject<DataResult<RegisterResponse>>(apiResponse);
            }

            return loginResponse;
        }

    }
}
