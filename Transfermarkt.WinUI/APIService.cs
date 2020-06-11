using System.Threading.Tasks;
using Flurl.Http;
using Transfermarkt.Models;

namespace Transfermarkt.WinUI
{
    public class APIService
    {
        public static string Token { get; set; }

        private readonly string _route;

        public APIService(string route)
        {
            _route = route;
        }
        
        public async Task<T> Get<T>(object search = null, string relativeRoute = null)
        {
            string url;
            if (string.IsNullOrEmpty(relativeRoute))
            {
                url = $"{Properties.Settings.Default.APIUrl}/{_route}";
            }
            else
            {
                url = $"{Properties.Settings.Default.APIUrl}/{_route}/{relativeRoute}";
            }
            if (search != null)
            {
                url += "?";
                url +=await search.ToQueryString();
            }

            return await url.WithOAuthBearerToken(Token).GetJsonAsync<T>();
        }

        public async Task<T> GetById<T>(object id, string relativeRoute = null)
        {
            string url;
            if (string.IsNullOrEmpty(relativeRoute))
            {
                url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";
            }
            else
            {
                url = $"{Properties.Settings.Default.APIUrl}/{_route}/{relativeRoute}/{id}";
            }

            return await url.WithOAuthBearerToken(Token).GetJsonAsync<T>();
        }

        public async Task<T> Insert<T>(object insert, string relativeRoute = null)
        {
            string url;
            if (string.IsNullOrEmpty(relativeRoute))
            {
                url = $"{Properties.Settings.Default.APIUrl}/{_route}";
            }
            else
            {
                url = $"{Properties.Settings.Default.APIUrl}/{_route}/{relativeRoute}";
            }
            return await url.WithOAuthBearerToken(Token).PostJsonAsync(insert).ReceiveJson<T>();
        }

        public async Task<T> Update<T>(object insert, string relativeRoute = null)
        {
            string url;
            if (string.IsNullOrEmpty(relativeRoute))
            {
                url = $"{Properties.Settings.Default.APIUrl}/{_route}";
            }
            else
            {
                url = $"{Properties.Settings.Default.APIUrl}/{_route}/{relativeRoute}";
            }

            return await url.WithOAuthBearerToken(Token).PutJsonAsync(insert).ReceiveJson<T>();
        }
    }
}
