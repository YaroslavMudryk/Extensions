using Extensions.LinkPreview.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
namespace Extensions.LinkPreview
{
    public static class Extensions
    {
        public static async Task<Link> GetLinkInfoAsync(this string q)
        {
            var handler = new HttpClientHandler();
            handler.AllowAutoRedirect = true;
            handler.MaxAutomaticRedirections = 3;
            var httpClient = new HttpClient(handler);
            var response = await httpClient.GetAsync(q);
            var html = await response.Content.ReadAsStringAsync();
            html = Regex.Replace(html, @"\t|\n|\r", "");
            Regex metaTag = new Regex("<meta[\\s]+[^>]*?[property|name]?=[\\s\"\']+(.*?)[\"\']+.*?content[\\s]?=[\\s\"\']+(.*?)[\"\']+.*?>");
            Dictionary<string, string> metaInformation = new Dictionary<string, string>();
            var iyte = metaTag.Matches(html);
            foreach (Match m in iyte)
            {
                if (!metaInformation.ContainsKey(m.Groups[1].Value))
                    metaInformation.Add(m.Groups[1].Value, m.Groups[2].Value);
            }
            Link newLink = new Link { URL = q };
            if (metaInformation.ContainsKey("og:title"))
                newLink.Title = HttpUtility.HtmlDecode(metaInformation["og:title"]);
            else
                newLink.Title = HttpUtility.HtmlDecode(Regex.Match(html, "(?<=<title>)(.*?)(?=</title>)").ToString());
            if (metaInformation.ContainsKey("og:description"))
                newLink.Description = HttpUtility.HtmlDecode(metaInformation["og:description"]);
            else if (metaInformation.ContainsKey("twitter:description"))
                newLink.Description = HttpUtility.HtmlDecode(metaInformation["twitter:description"]);
            else if (metaInformation.ContainsKey("description"))
                newLink.Description = HttpUtility.HtmlDecode(metaInformation["description"]);
            if (metaInformation.ContainsKey("og:image"))
                newLink.Image = metaInformation["og:image"][0] == '/' ? $"{q}{metaInformation["og:image"]}" : metaInformation["og:image"];
            return newLink;
        }

        public static async Task<Link> GetLinkInfoAsync(this Uri uri)
        {
            return await GetLinkInfoAsync(uri.OriginalString);
        }
    }
}