using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uebung01
{
    class Linie
    {
        private string name;
        private string farbe;
        private LinkedList<string> strecke;

        public Linie()
        {
            this.name = "Leer";
            this.farbe = "Farblos";
            this.strecke = new LinkedList<string>();
        }

        public Linie(string name, string farbe)
        {
            this.name = name;
            this.farbe = farbe;
            this.strecke = new LinkedList<string>();
        }

        public void ErsteStationEinfuegen(string name)
        {
            this.strecke.AddFirst(name);
        }

        public void LetzteStationEinfuegen(string name)
        {
            this.strecke.AddLast(name);
        }

        public void StationEinfuegenNach(string name, string nach)
        {
            LinkedListNode<string> erg = this.strecke.Find(nach);

            if (erg != null)
            {
                this.strecke.AddAfter(erg, name);
            }
        }

        public void AusgabeStationen()
        {
            LinkedListNode<string> current = this.strecke.First;

            while(current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
        }

        //TODO Ausgabe Stationen in umgekehrter Reihenfolge
        //
    }
}
