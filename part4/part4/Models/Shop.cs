using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;

namespace part4.Models
{
    public class Shop
    {
        private List<Product> PrebuiltConfigurations { get; set; }
        private List<Product> Hardware { get; set; }
        private List<Product> Software { get; set; }
        private List<Product> Peripherals { get; set; }

        public Shop(List<Product> prebuilts, List<Product> hardware, 
                    List<Product> software, List<Product> peripherals)
        {
            this.PrebuiltConfigurations = prebuilts;
            this.Hardware = hardware;
            this.Software = software;
            this.Peripherals = peripherals;
        }

        public List<Product> getPrebuiltConfigurations()
        {
            return PrebuiltConfigurations;
        }

        public List<Product> getHardware()
        {
            return Hardware;
        }

        public List<Product> getSoftware()
        {
            return Software;
        }

        public List<Product> getPeripherals()
        {
            return Peripherals;
        }
    }
}
