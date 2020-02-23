using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DotNetTools.Adapter
{
    //public interface IHttpClientAdapter
    //{
    //    Task<HttpResponseMessage> Get(string url);
    //    Task<T> GetAsyncWithToken<T>(string url, string token);
    //    Task<T> GetAsync<T>(string url);
    //    Task<T> GetAsync<T>(string url, string data);
    //    Task<HttpResponseMessage> Post(string url, HttpContent content);
    //    Task<HttpResponseMessage> Post(string url, HttpContent content, string token);
    //    Task<HttpResponseMessage> Put(string url, HttpContent content, string token);
    //    Task<HttpResponseMessage> Patch(string url, HttpContent data);
    //    Task<HttpResponseMessage> Patch(string url, HttpContent data, string token);
    //    Task<HttpResponseMessage> Delete(string url, string token);
    //}

    public static class HttpClientAdapter/* : IHttpClientAdapter*/
    {
        /// <summary>
        /// Get without token
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fullUrl">Full Url in String. Eg: https://localhost:1234/api/User </param>
        /// <param name="data">String data</param>
        /// <returns></returns>
        public static async Task<T> GetAsync<T>(string fullUrl, string data)
        {
            try
            {
                var finalUri = fullUrl + "?" + data;
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(finalUri);
                    var json = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<T>(json);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get given full url. No token required. Returns HttpResponseMessage
        /// </summary>
        /// <param name="fullUrl">Full Url in String. Eg: https://localhost:1234/api/User </param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> Get(string fullUrl)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(fullUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();

                        return JsonConvert.DeserializeObject<HttpResponseMessage>(json);
                    }
                    return new HttpResponseMessage(response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get given full url and token. No Content required.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fullUrl">Full Url in String. Eg: https://localhost:1234/api/User </param>
        /// <param name="token">Token as string.</param>
        /// <returns></returns>
        public static async Task<T> GetAsyncWithToken<T>(string fullUrl, string token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    if (token != null)
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }
                    var response = await client.GetAsync(fullUrl);
                    var json = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<T>(json);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get given full url. No Token required
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fullUrl">Full Url in String. Eg: https://localhost:1234/api/User </param>
        /// <returns></returns>
        public static async Task<T> GetAsync<T>(string fullUrl)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(fullUrl);
                    var json = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<T>(json);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Post withouth any token required.
        /// </summary>
        /// <param name="fullUrl">Full Url in String. Eg: https://localhost:1234/api/User </param>
        /// <param name="content"> HttpContent type. 
        /// Eg: new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"); 
        /// </param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> Post(string fullUrl, HttpContent content)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.PostAsync(fullUrl, content);
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Post with given token (Authentication). 
        /// </summary>
        /// <param name="url">Full Url in String. Eg: https://localhost:1234/api/User </param>
        /// <param name="content"> HttpContent type. 
        /// Eg: new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"); 
        /// </param>
        /// <param name="token">Token as string</param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> Post(string fullUrl, HttpContent content, string token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    if (token != null)
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }
                    var response = await client.PostAsync(fullUrl, content);
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Put with given token (Authentication)
        /// </summary>
        /// <param name="url">Full Url in String. Eg: https://localhost:1234/api/User </param>
        /// <param name="content"> HttpContent type. 
        /// Eg: new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"); 
        /// </param>
        /// <param name="token">Token as string</param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> Put(string fullUrl, HttpContent content, string token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    if (token != null)
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }
                    var response = await client.PutAsync(fullUrl, content);
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Patch without any token
        /// </summary>
        /// <param name="url">Full Url in String. Eg: https://localhost:1234/api/User </param>
        /// <param name="content">HttpContent type. 
        /// Eg: new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"); 
        /// </param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> Patch(string fullUrl, HttpContent content)
        {
            try
            {
                var method = new HttpMethod("PATCH");

                var request = new HttpRequestMessage(method, fullUrl)
                {
                    Content = content
                };

                using (var client = new HttpClient())
                {
                    var response = await client.SendAsync(request);
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Patch with Token
        /// </summary>
        /// <param name="url">Full Url in String. Eg: https://localhost:1234/api/User </param>
        /// <param name="content">HttpContent type. 
        /// Eg: new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"); 
        /// </param>
        /// <param name="token">Token as String</param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> Patch(string fullUrl, HttpContent content, string token)
        {
            try
            {
                var method = new HttpMethod("PATCH");

                var request = new HttpRequestMessage(method, fullUrl)
                {
                    Content = content
                };
                using (var client = new HttpClient())
                {
                    if (token != null)
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }
                    var response = await client.SendAsync(request);
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete with token
        /// </summary>
        /// <param name="url">Full Url in String. Eg: https://localhost:1234/api/User </param>
        /// <param name="token">Token as string</param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> Delete(string fullUrl, string token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    if (token != null)
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }
                    var response = await client.DeleteAsync(fullUrl);
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
