using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.EndPoints
{
    public static class ApiEndpoints
    {
        private static string apiBaseUrl = AppConfiguration.Configuration.ApiBaseUrl;

        #region Authentication
        public static string Register = apiBaseUrl + "Authentication/Register";
        public static string Login = apiBaseUrl + "Authentication/Login";
        #endregion

        #region User
        public static string Subscribe = apiBaseUrl + "User/Subscribe";
        public static string Unsubscribe = apiBaseUrl + "User/Unsubscribe";
        public static string GetSubscriptions = apiBaseUrl + "User/GetSubscriptions";
        #endregion

        #region Book
        public static string GetBooks = apiBaseUrl + "Book/GetBooks";
        #endregion


    }
}
