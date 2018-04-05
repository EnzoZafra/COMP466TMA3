using System;
namespace part2.Models
{
    public class myImage
    {
        public String Url { get; set; }
        public String Caption { get; set; }

        public myImage(String url, String caption)
        {
            this.Url = url;
            this.Caption = caption;
        }
    }
}
