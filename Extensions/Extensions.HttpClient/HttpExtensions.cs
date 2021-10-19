using System.Net.Http;
using System.Net.Http.Headers;
namespace Extensions.Http
{
    public static class HttpExtensions
    {
        public static void SetBearerToken(this HttpClient httpClient, string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}