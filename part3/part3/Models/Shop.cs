using System;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;

namespace part3.Models
{
    public class Shop
    {
        private ArrayList<Computer> PrebuiltConfigurations { get; set; }
        private ArrayList<Part> Hardware { get; set; }
        private ArrayList<Software> Software { get; set; }
        private ArrayList<Peripheral> Peripherals { get; set; }

        public Shop(ArrayList<Computer> prebuilts, ArrayList<Part> hardware, 
                    ArrayList<Software> software, ArrayList<Peripheral> peripherals)
        {
            this.PrebuiltConfigurations = prebuilts;
            this.Hardware = hardware;
            this.Software = software;
            this.Peripherals = peripherals;
        }

        public ArrayList<Computer> getPrebuiltConfigurations()
        {
            return PrebuiltConfigurations;
        }

        public ArrayList<Part> getHardware()
        {
            return Hardware;
        }

        public ArrayList<Software> getSoftware()
        {
            return Software;
        }

        public ArrayList<Peripheral> getPeripherals()
        {
            return Peripherals;
        }
    }
}
