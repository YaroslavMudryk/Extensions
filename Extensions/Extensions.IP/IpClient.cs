using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
namespace Extensions.IP
{
    public class IpClient
    {
        public static async Task<IPInfo> GetIpInfoAsync(string ipAddress)
        {
            string url = null;
            if (string.IsNullOrEmpty(ipAddress))
            {
                url = "json?fields=66846719";
            }
            else
            {
                url = $"json/{ipAddress}?fields=66846719";
            }
            HttpClient httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://ip-api.com"),
                Timeout = TimeSpan.FromSeconds(20)
            };
            var resposne = await httpClient.GetAsync(url);
            return JsonSerializer.Deserialize<IPInfo>(await resposne.Content.ReadAsStringAsync());
        }
    }
}