using System;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;

namespace part3.Models
{
    public class Configurator
    {
        private Computer Computer;
        private ArrayList<Part> Processors;
        private ArrayList<Part> Motherboards;
        private ArrayList<Part> Rams;
        private ArrayList<Part> Harddrives;
        private ArrayList<Part> Videocards;
        private ArrayList<Part> Powersupplies;
        private ArrayList<Part> Soundcards;
        private ArrayList<Software> Operatingsystems;

        public Configurator(Computer computer, ArrayList<Part> cpus, ArrayList<Part> motherboards,
                            ArrayList<Part> rams, ArrayList<Part> harddrives, ArrayList<Part> videocards,
                            ArrayList<Part> powersupplies, ArrayList<Part> soundcards, ArrayList<Software> oss
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

        public ArrayList<Part> getProcessorsStock()
        {
            return Processors;
        }

        public ArrayList<Part> getMotherboardsStock()
        {
            return Motherboards;
        }

        public ArrayList<Part> getRamsStock()
        {
            return Rams;
        }

        public ArrayList<Part> getHarddrivesStock()
        {
            return Harddrives;
        }

        public ArrayList<Part> getVideocardsStock()
        {
            return Videocards;
        }

        public ArrayList<Part> getPowersuppliesStock()
        {
            return Powersupplies;
        }

        public ArrayList<Part> getSoundcardsStock()
        {
            return Soundcards;
        }

        public ArrayList<Software> getOSStock()
        {
            return Operatingsystems;
        }
    }
}
