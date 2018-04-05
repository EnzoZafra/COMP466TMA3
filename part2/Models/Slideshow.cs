using System;
using System.Linq;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace part2.Models
{
    public class Slideshow
    {
        private ArrayList<myImage> MyImages { get; set; }

        public Slideshow(IConfigurationRoot configuration)
        {
            this.MyImages = new ArrayList<myImage>();
            parseJson(configuration);
        }

        public ArrayList<myImage> getImages() {
            return MyImages;
        }

        private void parseJson(IConfigurationRoot configuration) 
        {
            var sections = configuration.GetSection("Slideshow");
            foreach (IConfigurationSection section in sections.GetChildren())
            {
                if (section == null) {
                    continue;
                } else {
                    var url = section.GetValue<String>("Url");
                    var caption = section.GetValue<String>("Caption");
                    var img = new myImage(url, caption);
                    MyImages.Add(img);
                }
            }
        }
    }
}
