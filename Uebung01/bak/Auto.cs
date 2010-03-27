using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAD2_Verkehrsnetz
{
    class Auto
    {
        private String type;
        private String color;

        public Auto()
        {
            this.type = "Mazda 323";
            this.color = "blue";
        }

        public void printCarInformation() 
        {
            Console.WriteLine("Type: {0}, Color: {1}", this.type, this.color);
        }
    }
}
