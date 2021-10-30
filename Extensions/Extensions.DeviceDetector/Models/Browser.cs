using DeviceDetectorNET.Class;

namespace Extensions.DeviceDetector.Models
{
    public class Browser : BaseModel
    {
        public string Type { get; set; }
        public string Engine { get; set; }
    }

    public class Bot
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public Producer Producer { get; set; }
        public string Url { get; set; }
    }
}
