using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transfermarkt.Models;

namespace Transfermarkt.MobileApp
{
    public class APIService
    {
        public static string Token { get; set; }

        private readonly string _route;

#if DEBUG
        private readonly string _apiUrl = "http://localhost:52736/api";
#endif
#if RELEASE
        private string _apiUrl = "https://mywebsite.azure.com/api/"; 
#endif

        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object search = null, string relativeRoute = null)
        {
            string url;
            if (string.IsNullOrEmpty(relativeRoute))
            {
                url = $"{_apiUrl}/{_route}";
            }
            else
            {
                url = $"{_apiUrl}/{_route}/{relativeRoute}";
            }
            if (search != null)
            {
                url += "?";
                url += await search.ToQueryString();
            }

            return await url.WithOAuthBearerToken(Token).GetJsonAsync<T>();
        }

        public async Task<T> GetById<T>(object id, string relativeRoute = null)
        {
            string url;
            if (string.IsNullOrEmpty(relativeRoute))
            {
                url = $"{_apiUrl}/{_route}/{id}";
            }
            else
            {
                url = $"{_apiUrl}/{_route}/{relativeRoute}/{id}";
            }

            return await url.WithOAuthBearerToken(Token).GetJsonAsync<T>();
        }

        public async Task<T> Insert<T>(object insert, string relativeRoute = null)
        {
            string url;
            if (string.IsNullOrEmpty(relativeRoute))
            {
                url = $"{_apiUrl}/{_route}";
            }
            else
            {
                url = $"{_apiUrl}/{_route}/{relativeRoute}";
            }
            return await url.WithOAuthBearerToken(Token).PostJsonAsync(insert).ReceiveJson<T>();
        }

        public async Task<T> Update<T>(object insert, string relativeRoute = null)
        {
            string url;
            if (string.IsNullOrEmpty(relativeRoute))
            {
                url = $"{_apiUrl}/{_route}";
            }
            else
            {
                url = $"{_apiUrl}/{_route}/{relativeRoute}";
            }

            return await url.WithOAuthBearerToken(Token).PutJsonAsync(insert).ReceiveJson<T>();
        }
    }
}
