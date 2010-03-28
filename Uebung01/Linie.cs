using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAD2_Verkehrsnetz
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

        /// <summary>
        /// Fügt eine Station am Anfang der Liste ein
        /// </summary>
        /// <param name="name">Name der Station</param>
        public void ErsteStationEinfuegen(string name)
        {
            this.strecke.AddFirst(name);
        }

        /// <summary>
        /// Fügt eine Station am Ende der Liste ein
        /// </summary>
        /// <param name="name">Name der Station</param>
        public void LetzteStationEinfuegen(string name)
        {
            this.strecke.AddLast(name);
        }

        /// <summary>
        /// Fügt eine Station nach einer bereits bestehenden Station ein
        /// </summary>
        /// <param name="name">Name der neuen Station</param>
        /// <param name="nach">Name der existierenden Station</param>
        /// <returns>true wenn das Einfügen erfolgreich war; false bei Misserfolg</returns>
        public bool StationEinfuegenNach(string name, string nach)
        {
            LinkedListNode<string> erg = this.strecke.Find(nach);

            if (erg != null)
            {
                this.strecke.AddAfter(erg, name);
                return true;
            }
            else
            {
                Console.WriteLine("Station {0} konnte nicht eingefügt werden. Station {1} existiert nicht!", name, nach);
                return false;
            }
        }

        /// <summary>
        /// Fügt eine Station vor einer bereits bestehenden Station ein
        /// </summary>
        /// <param name="name">Name der neuen Station</param>
        /// <param name="nach">Name der existierenden Station</param>
        /// <returns>true wenn das Einfügen erfolgreich war; false bei Misserfolg</returns>
        public bool StationEinfuegenVor(string name, string vor)
        {
            //TODO Einfügen einer Station "name" vor der Station "vor"
            return false;
        }

        /// <summary>
        /// Ausgabe aller Stationen in normaler Reihenfolge
        /// </summary>
        public void AusgabeStationen()
        {
            LinkedListNode<string> current = this.strecke.First;

            while(current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
        }

        /// <summary>
        /// Ausgabe aller Stationen in umgekehrter Reihenfolge
        /// </summary>
        public void AusgabeStationenGegenrichtung()
        {
            //TODO Ausgabe Stationen in umgekehrter Reihenfolge
        }

        /// <summary>
        /// Entfernen einer Station aus der Liste
        /// </summary>
        /// <param name="name">Name der zu entfernenden Station</param>
        /// <returns>true bei erfolgreichem Entfernen; false bei Misserfolg</returns>
        public bool StationEntfernen(string name)
        {
            //TODO Entfernen einer Station "name" aus der Liste mittels
            // this.strecke.Remove
            // Rückgabe von true, wenn erfolgreich, false wenn keine Station gefunden/gelöscht wurde
            return false;
        }   
    }
}
