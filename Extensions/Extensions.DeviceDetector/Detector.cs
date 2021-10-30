using Extensions.DeviceDetector.Models;
using Microsoft.AspNetCore.Http;

namespace Extensions.DeviceDetector
{
    internal class Detector : IDetector
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string _userAgent;
        public Detector(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _userAgent = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"];
        }

        public Bot GetBot()
        {
            var dd = new DeviceDetectorNET.DeviceDetector(_userAgent);
            dd.Parse();
            var bot = dd.GetBot();
            return bot.Success ? new Bot
            {
                Name = bot.Match.Name,
                Category = bot.Match.Category,
                Producer = bot.Match.Producer,
                Url = bot.Match.Url
            } : null;
        }

        public Browser GetBrowser()
        {
            var dd = new DeviceDetectorNET.DeviceDetector(_userAgent);
            dd.SkipBotDetection();
            dd.DiscardBotInformation();
            dd.Parse();
            var browser = dd.GetBrowserClient();
            return browser.Success ? new Browser
            {
                Name = browser.Match.Name,
                Engine = browser.Match.Engine,
                Type = browser.Match.Type,
                Version = browser.Match.Version
            } : null;
        }

        public ClientInfo GetClientInfo()
        {
            var dd = new DeviceDetectorNET.DeviceDetector(_userAgent);
            dd.SkipBotDetection();
            dd.DiscardBotInformation();
            dd.Parse();
            var device = new Device
            {
                Brand = getStringOrNull(dd.GetBrandName()),
                Model = getStringOrNull(dd.GetModel()),
                Type = getStringOrNull(dd.GetDeviceName())
            };
            var browser = dd.GetBrowserClient();
            var browserInfo = browser.Success ? new Browser
            {
                Name = browser.Match.Name,
                Engine = browser.Match.Engine,
                Type = browser.Match.Type,
                Version = browser.Match.Version
            } : null;
            var os = dd.GetOs();
            var osInfo = os.Success ? new OS
            {
                Name = os.Match.Name,
                Version = os.Match.Version,
                Platform = os.Match.Platform
            } : null;
            return new ClientInfo
            {
                Browser = browserInfo,
                Device = device,
                OS = osInfo
            };
        }

        public Device GetDevice()
        {
            var dd = new DeviceDetectorNET.DeviceDetector(_userAgent);
            dd.SkipBotDetection();
            dd.DiscardBotInformation();
            dd.Parse();
            return new Device
            {
                Brand = getStringOrNull(dd.GetBrandName()),
                Model = getStringOrNull(dd.GetModel()),
                Type = getStringOrNull(dd.GetDeviceName())
            };
        }

        public OS GetOs()
        {
            var dd = new DeviceDetectorNET.DeviceDetector(_userAgent);
            dd.SkipBotDetection();
            dd.DiscardBotInformation();
            dd.Parse();
            var os = dd.GetOs();
            return os.Success ? new OS
            {
                Name = os.Match.Name,
                Version = os.Match.Version,
                Platform = os.Match.Platform
            } : null;
        }

        private string getStringOrNull(string q) => string.IsNullOrEmpty(q) ? null : q;
    }
}