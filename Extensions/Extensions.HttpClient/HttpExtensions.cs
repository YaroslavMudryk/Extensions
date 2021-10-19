using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace Extensions.Http
{
    public static class HttpExtensions
    {
        public static void SetBearerToken(this HttpClient httpClient, string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public static async Task<TEntity> GetResponseFromJson<TEntity>(this HttpClient httpClient, string url)
        {
            var response = await httpClient.GetAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();
            var objectContent = JsonSerializer.Deserialize<TEntity>(responseContent);
            return objectContent is not null ? objectContent : default; 
        }

        public static async Task<TEntity> PostResponseFromJson<TEntity>(this HttpClient httpClient, string url, object data = null)
        {
            var postData = new StringContent(data.ToString(), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, postData);
            var responseContent = await response.Content.ReadAsStringAsync();
            var objectContent = JsonSerializer.Deserialize<TEntity>(responseContent);
            return objectContent is not null ? objectContent : default;
        }
    }
}