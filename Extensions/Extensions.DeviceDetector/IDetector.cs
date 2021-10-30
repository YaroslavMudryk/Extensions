using Extensions.DeviceDetector.Models;

namespace Extensions.DeviceDetector
{
    public interface IDetector
    {
        Browser GetBrowser();
        Device GetDevice();
        OS GetOs();
        Bot GetBot();
        ClientInfo GetClientInfo();
    }
}