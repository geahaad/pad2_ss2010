﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

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
                Console.WriteLine("Station {0} existiert bereits in Graphen", name);
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

        public void Einlesen()
        {
            try
            {
                StreamReader reader = new StreamReader(@"C:\Users\geahaad\Documents\lecturer\2010_ss\pad2\workspace\Uebung01\Uebung01\input\ubahn_km.csv");
                int distanceBefore = 0;
                string linieBefore = "";
                string stationBefore = "";
                Linie linie = null;

                while (!reader.EndOfStream) {
                    string line = reader.ReadLine();
                    string[] junks = line.Split(';');
                    if (junks.Length == 3)
                    {
                        if (linieBefore != junks[0])
                        {
                            // create new list
                            linie = new Linie(junks[0], "");
                            this.LinieEinfuegen(junks[0], linie);
                        }

                        // add station to linie
                        linie.LetzteStationEinfuegen(junks[1]);

                        // calculate distance
                        int distance = int.Parse(junks[2]) - distanceBefore;

                        // add station to graph
                        this.StationInGraphEinfuegen(junks[1]);

                        // connect neighbor, but exclude line changes
                        if (stationBefore != "" && linieBefore == junks[0])
                        {
                            this.NachbarVerbindungEinfuegen(stationBefore, junks[1]);
                            this.NachbarVerbindungEinfuegen(junks[1], stationBefore);
                        }

                        //Console.WriteLine("{0}: {1} - Distance: {2}", junks[0], junks[1], distance);
                        distanceBefore = int.Parse(junks[2]);
                        stationBefore = junks[1];
                        linieBefore = junks[0];
                    }
                    else
                    {
                        Console.WriteLine("Incorrect structure in line: {0}", line);
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
