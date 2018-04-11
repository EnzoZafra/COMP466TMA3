using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;

namespace part3.Models
{
    public class Configurator
    {
        private Computer Computer;
        private List<Part> Processors;
        private List<Part> Motherboards;
        private List<Part> Rams;
        private List<Part> Harddrives;
        private List<Part> Videocards;
        private List<Part> Powersupplies;
        private List<Part> Soundcards;
        private List<Software> Operatingsystems;

        public Configurator(Computer computer, List<Part> cpus, List<Part> motherboards,
                            List<Part> rams, List<Part> harddrives, List<Part> videocards,
                            List<Part> powersupplies, List<Part> soundcards, List<Software> oss
                           )
        {
            this.Computer = computer;
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
