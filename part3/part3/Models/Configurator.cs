using System;
namespace part3.Models
{
    public class Configurator
    {
        private Computer Computer;

        public Configurator(Computer computer)
        {
            this.Computer = computer;
        }

        public Computer getComputer() {
            return Computer;
        }
    }
}
