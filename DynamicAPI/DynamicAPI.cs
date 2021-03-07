using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text; 
using System.Threading.Tasks; 

namespace CDS.DynamicAPI
{
    public static class DynamicAPI
    {
        private static async Task<HttpResponseMessage> CallRestAPI(string clientToken,string URI, string body, HttpMethod Method)
        { 
            var HttpResponseMessage = new HttpResponseMessage();
            try
            { 
                var uri = new Uri(URI);
                var _client = new HttpClient();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", clientToken);
                var request = new HttpRequestMessage
                {
                    Method = Method,
                    RequestUri = new Uri(URI)
                }; 
                if (Method != HttpMethod.Get)
                {
                    request.Content = new StringContent(body, Encoding.UTF8, "application/json");
                    if (Method == HttpMethod.Patch)
                    {
                        request.Headers.Add("If-Match","*");
                    }
                }
                HttpResponseMessage = await _client.SendAsync(request);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return HttpResponseMessage;
        }

        public static async Task<string> CallApi(string clientToken,string uri,string body ,HttpMethod method)
        {
            var _httpResponseMessage = await CallRestAPI(clientToken,uri,body, method);
            var content = await _httpResponseMessage.Content.ReadAsStringAsync();
            if (_httpResponseMessage.Headers.Contains("OData-EntityId"))
            {
                var headers=_httpResponseMessage.Headers.GetValues("OData-EntityId").FirstOrDefault(); 
                var idEntity = headers.Split('(', ')')[1];
                content = idEntity;
            }
            return content;
        }
    }
}
