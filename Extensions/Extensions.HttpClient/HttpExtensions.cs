using System.Net.Http.Headers;

namespace Extensions.HttpClient
{
    public static class HttpExtensions
    {
        public static void SetBearerToken(this System.Net.Http.HttpClient httpClient, string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
