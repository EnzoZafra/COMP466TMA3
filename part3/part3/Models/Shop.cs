using System;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;

namespace part3.Models
{
    public class Shop
    {
        private ArrayList<Computer> PrebuiltConfigurations { get; set; }
        private ArrayList<Part> Hardware { get; set; }

        public Shop(ArrayList<Computer> prebuilts, ArrayList<Part> hardware)
        {
            this.PrebuiltConfigurations = prebuilts;
            this.Hardware = hardware;
        }

        public ArrayList<Computer> getPrebuiltConfigurations()
        {
            return PrebuiltConfigurations;
        }

        public ArrayList<Part> getHardware()
        {
            return Hardware;
        }
    }
}
