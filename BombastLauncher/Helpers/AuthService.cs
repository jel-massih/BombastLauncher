using BombastLauncher.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace BombastLauncher.Helpers
{
    class AuthService
    {
        public LoginStatusCode TryLogin(string email, string password)
        {
            if(email == "" || password == "")
            {
                return LoginStatusCode.LS_WRONG_ACCOUNT_INFO;
            }

            email = email.ToLower();

            var postData = JsonConvert.SerializeObject(new {
                email=email,
                password=password,
                source="Launcher"
            });

            var requestResponse = ApiRequestHelper.PostRequest("user_auth", postData);

            if (requestResponse.ResponseCode == HttpStatusCode.OK)
            {
                return LoginStatusCode.LS_SUCCESS;
            }
            else if (requestResponse.ResponseCode == HttpStatusCode.Unauthorized)
            {
                return LoginStatusCode.LS_WRONG_ACCOUNT_INFO;
            }
            else
            {
                return LoginStatusCode.LS_UNKNOWN_ERROR;
            }
        }
    }
}
