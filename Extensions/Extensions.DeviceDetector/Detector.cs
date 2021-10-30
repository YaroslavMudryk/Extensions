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
            var dd = getDeviceDetector(false);
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
            var dd = getDeviceDetector();
            var browser = dd.GetBrowserClient();
            return browser.Success ? new Browser
            {
                Name = browser.Match.Name,
                Engine = browser.Match.Engine,
                Type = browser.Match.Type,
                Version = browser.Match.Version,
                EngineVersion = browser.Match.EngineVersion,
                ShortName = browser.Match.ShortName
            } : null;
        }

        public ClientInfo GetClientInfo()
        {
            var dd = getDeviceDetector();
            var device = new Device
            {
                Brand = getStringOrNull(dd.GetBrandName()),
                Model = getStringOrNull(dd.GetModel()),
                Type = getStringOrNull(dd.GetDeviceName()),
                BrandShortName = getStringOrNull(dd.GetBrand())
            };
            var browser = dd.GetBrowserClient();
            var browserInfo = browser.Success ? new Browser
            {
                Name = browser.Match.Name,
                Engine = browser.Match.Engine,
                Type = browser.Match.Type,
                Version = browser.Match.Version,
                EngineVersion = browser.Match.EngineVersion,
                ShortName = browser.Match.ShortName
            } : null;
            var os = dd.GetOs();
            var osInfo = os.Success ? new OS
            {
                Name = os.Match.Name,
                Version = os.Match.Version,
                Platform = os.Match.Platform,
                ShortName = os.Match.ShortName
            } : null;
            return new ClientInfo
            {
                Browser = browserInfo,
                Device = device,
                OS = osInfo
            };
        }

        public ClientInfo GetClientInfo(string ua)
        {
            if (string.IsNullOrEmpty(ua))
                return GetClientInfo();
            var dd = new DeviceDetectorNET.DeviceDetector(ua);
            dd.SkipBotDetection();
            dd.DiscardBotInformation(false);
            dd.Parse();
            var device = new Device
            {
                Brand = getStringOrNull(dd.GetBrandName()),
                Model = getStringOrNull(dd.GetModel()),
                Type = getStringOrNull(dd.GetDeviceName()),
                BrandShortName = getStringOrNull(dd.GetBrand())
            };
            var browser = dd.GetBrowserClient();
            var browserInfo = browser.Success ? new Browser
            {
                Name = browser.Match.Name,
                Engine = browser.Match.Engine,
                Type = browser.Match.Type,
                Version = browser.Match.Version,
                EngineVersion = browser.Match.EngineVersion,
                ShortName = browser.Match.ShortName
            } : null;
            var os = dd.GetOs();
            var osInfo = os.Success ? new OS
            {
                Name = os.Match.Name,
                Version = os.Match.Version,
                Platform = os.Match.Platform,
                ShortName = os.Match.ShortName
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
            var dd = getDeviceDetector();
            return new Device
            {
                Brand = getStringOrNull(dd.GetBrandName()),
                Model = getStringOrNull(dd.GetModel()),
                Type = getStringOrNull(dd.GetDeviceName()),
                BrandShortName = getStringOrNull(dd.GetBrand())
            };
        }

        public OS GetOs()
        {
            var dd = getDeviceDetector();
            var os = dd.GetOs();
            return os.Success ? new OS
            {
                Name = os.Match.Name,
                Version = os.Match.Version,
                Platform = os.Match.Platform,
                ShortName = os.Match.ShortName
            } : null;
        }

        private DeviceDetectorNET.DeviceDetector getDeviceDetector(bool skipBot = true)
        {
            var dd = new DeviceDetectorNET.DeviceDetector(_userAgent);
            if (skipBot)
            {
                dd.SkipBotDetection();
                dd.DiscardBotInformation(false);
            }
            dd.Parse();
            return dd;
        }

        private string getStringOrNull(string q) => string.IsNullOrEmpty(q) ? null : q;
    }
}