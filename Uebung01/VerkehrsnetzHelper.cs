using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAD2_Verkehrsnetz
{
    class VerkehrsnetzHelper
    {
        Dictionary<string, Linie> uebersichtLinien;

        Dictionary<string, LinkedList<string>> graph;

        
        //TODO liste aller stationen (Type: Dictionary)

        public VerkehrsnetzHelper()
        {
            this.uebersichtLinien = new Dictionary<string, Linie>();

            this.graph = new Dictionary<string, LinkedList<string>>();
        }


        public void StationInGraphEinfuegen(string name)
        {
            bool gefunden = this.graph.ContainsKey(name);
            if (gefunden == false)
            {
                 LinkedList<string> liste = new LinkedList<string>();

                this.graph.Add(name, liste);
            }
            else
            {
                Console.WriteLine("Station existiert bereits in Graphen");
            }
        }

        public void NachbarVerbindungEinfuegen(string station, string nachbarNeu)
        {
            bool existiertStation = this.graph.ContainsKey(station);

            if (existiertStation == true)
            {
                LinkedList<string> nachbarn = this.graph[station];

                bool existiertNachbar = nachbarn.Contains(nachbarNeu);

                if (existiertNachbar == false)
                {
                    nachbarn.AddLast(nachbarNeu);
                }
                else
                {
                    Console.WriteLine("Nachbar {0} existiert bereits", nachbarNeu);
                }
            }
            else
            {
                Console.WriteLine("Station {0} nicht gefunden", station);
            }
        }


        /// <summary>
        /// Einfügen einer Linie in eine Übersicht vom Typ Dictionary
        /// </summary>
        /// <param name="name">Name der einzufügenden Linie (eindeutig)</param>
        /// <param name="linie">Objekt einer Linie</param>
        /// <returns>true wenn das Einfügen erfolgreich war - false bei Misserfolg</returns>
        public bool LinieEinfuegen(string name, Linie linie)
        {
            bool gefunden = this.uebersichtLinien.ContainsKey(name);
            if (gefunden == false)
            {
                this.uebersichtLinien.Add(name, linie);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Einfügen einer Statio in eine Übersicht vom Typ Dictionary
        /// </summary>
        /// <param name="name">Name der einzufügenden Station (eindeutig)</param>
        /// <param name="linie">Objekt einer Station</param>
        /// <returns>true wenn das Einfügen erfolgreich war - false bei Misserfolg</returns>
        public void StationEinfuegen(string name, Station station)
        {
            // TODO: Einfügen einer Station - analog zu LinieEinfuegen
            // inkl. return values true/false bei Erfolg/Misserfolg
        }

        public void LinienAusgabe()
        {
            foreach (String key in this.uebersichtLinien.Keys)
            {
                Linie aktuelleLinie = uebersichtLinien[key];
                Console.WriteLine(aktuelleLinie.getName());

                //Console.WriteLine(uebersichtLinien[key].getName());
            }
        }
    }
}
