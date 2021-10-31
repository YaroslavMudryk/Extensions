using System;

namespace Extensions.LinkPreview.Models
{
    public class Link
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string URL { get; set; }
        public bool IsFound
        {
            get
            {
                return !string.IsNullOrEmpty(Title) || !string.IsNullOrEmpty(Description) || !string.IsNullOrEmpty(Image);
            }
        }
    }
}
