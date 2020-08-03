using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            try
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
                    url += await search.ToQueryString();
                }
                return await url.WithOAuthBearerToken(Token).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("Wrong username or password.", "Warining", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Forbidden)
                {
                    MessageBox.Show("Forbidden.", "Warining", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                throw;
            }
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
            try
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
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, {string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }
        }

        public async Task<T> Update<T>(object insert, string Id, string relativeRoute = null)
        {
            try
            {
                string url;
                if (string.IsNullOrEmpty(relativeRoute))
                {
                    url = $"{Properties.Settings.Default.APIUrl}/{_route}/{Id}";
                }
                else
                {
                    url = $"{Properties.Settings.Default.APIUrl}/{_route}/{relativeRoute}";
                }

                return await url.WithOAuthBearerToken(Token).PutJsonAsync(insert).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }
        }
    }
}
