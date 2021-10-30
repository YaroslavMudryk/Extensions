namespace Extensions.DeviceDetector.Models
{
    public class OS : BaseModel
    {
        public virtual string ShortName { get; set; }
        public string Platform { get; set; }
    }
}
