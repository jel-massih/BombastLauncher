using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace BombastLauncher.Helpers
{
    public class ApiRequestResponseModel
    {
        public string ResponseText { get; set; }
        public HttpStatusCode ResponseCode { get; set; }
    }

    public static class ApiRequestHelper
    {
        public static ApiRequestResponseModel PostRequest(string apiUrl, string postData)
        {
            var request = WebRequest.Create(BombastSettings.ApiUrl + apiUrl);
            request.Method = "POST";

            byte[] postDataByteArray = Encoding.UTF8.GetBytes(postData);

            request.ContentType = "application/json;charset=UTF-8";
            request.ContentLength = postDataByteArray.Length;

            request.Proxy = new WebProxy("127.0.0.1:8888", false);

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(postDataByteArray, 0, postDataByteArray.Length);
            }

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(dataStream))
                        {
                            return new ApiRequestResponseModel
                            {
                                ResponseText = reader.ReadToEnd(),
                                ResponseCode = response.StatusCode
                            };

                        }
                    }
                }
            }
            catch (WebException ex)
            {
                return new ApiRequestResponseModel
                {
                    ResponseText = ex.Message,
                    ResponseCode = ((HttpWebResponse)ex.Response).StatusCode
                };
            }
            catch (Exception ex)
            {
                return new ApiRequestResponseModel
                {
                    ResponseText = ex.Message,
                    ResponseCode = HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
