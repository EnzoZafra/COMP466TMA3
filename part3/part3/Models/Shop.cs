using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;

namespace part3.Models
{
    public class Shop
    {
        private List<Computer> PrebuiltConfigurations { get; set; }
        private List<Part> Hardware { get; set; }
        private List<Software> Software { get; set; }
        private List<Peripheral> Peripherals { get; set; }

        public Shop(List<Computer> prebuilts, List<Part> hardware, 
                    List<Software> software, List<Peripheral> peripherals)
        {
            this.PrebuiltConfigurations = prebuilts;
            this.Hardware = hardware;
            this.Software = software;
            this.Peripherals = peripherals;
        }

        public List<Computer> getPrebuiltConfigurations()
        {
            return PrebuiltConfigurations;
        }

        public List<Part> getHardware()
        {
            return Hardware;
        }

        public List<Software> getSoftware()
        {
            return Software;
        }

        public List<Peripheral> getPeripherals()
        {
            return Peripherals;
        }
    }
}
