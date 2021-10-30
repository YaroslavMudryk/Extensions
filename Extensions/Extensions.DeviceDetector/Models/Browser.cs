namespace Extensions.DeviceDetector.Models
{
    public class Browser : BaseModel
    {
        public string Type { get; set; }
        public string Engine { get; set; }
        public string EngineVersion { get; set; }
        public string ShortName { get; set; }
    }
}