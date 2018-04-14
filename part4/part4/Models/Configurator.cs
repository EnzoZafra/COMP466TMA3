using System;
using System.Collections.Generic;

namespace part4.Models
{
    public class Configurator
    {
        private Computer Computer { get; set; }
        private List<Part> Processors { get; set; }
        private List<Part> Motherboards { get; set; }
        private List<Part> Rams { get; set; }
        private List<Part> Harddrives { get; set; }
        private List<Part> Videocards { get; set; }
        private List<Part> Powersupplies { get; set; }
        private List<Part> Soundcards { get; set; }
        private List<Software> Operatingsystems { get; set; }

        public Configurator(Computer comp, List<Part> cpus, List<Part> motherboards,
                            List<Part> rams, List<Part> harddrives, List<Part> videocards,
                            List<Part> powersupplies, List<Part> soundcards, List<Software> oss
                           )
        {
            this.Computer = comp;
            this.Processors = cpus;
            this.Motherboards = motherboards;
            this.Rams = rams;
            this.Harddrives = harddrives;
            this.Videocards = videocards;
            this.Powersupplies = powersupplies;
            this.Soundcards = soundcards;
            this.Operatingsystems = oss;
        }

        public Computer getComputer() {
            return Computer;
        }

        public List<Part> getProcessorsStock()
        {
            return Processors;
        }

        public List<Part> getMotherboardsStock()
        {
            return Motherboards;
        }

        public List<Part> getRamsStock()
        {
            return Rams;
        }

        public List<Part> getHarddrivesStock()
        {
            return Harddrives;
        }

        public List<Part> getVideocardsStock()
        {
            return Videocards;
        }

        public List<Part> getPowersuppliesStock()
        {
            return Powersupplies;
        }

        public List<Part> getSoundcardsStock()
        {
            return Soundcards;
        }

        public List<Software> getOSStock()
        {
            return Operatingsystems;
        }
    }
}
