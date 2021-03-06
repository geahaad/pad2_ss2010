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

        /// <summary>
        /// Erstellt einen Knoten im Graphen
        /// </summary>
        /// <param name="name">Name des Knotens (= Stationsname)</param>
        public void StationInGraphEinfuegen(string name)
        {
            // Prüfen, ob der Knoten schon existiert
            bool gefunden = this.graph.ContainsKey(name);

            // Wenn ja, darf er nicht nochmals eingefügt werden
            if (gefunden == false)
            {
                // Erstellung einer leeren Liste (wir kennen noch keine Nachbarn)
                LinkedList<string> liste = new LinkedList<string>();

                // Den Knoten und die leere Liste in den Graphen einfügen
                this.graph.Add(name, liste);
            }
            else
            {
                Console.WriteLine("Station {0} existiert bereits in Graphen", name);
            }
        }

        /// <summary>
        /// Verbindung zwischen zwei Knoten herstellen
        /// </summary>
        /// <param name="station">Knotenname</param>
        /// <param name="nachbarNeu">Nachbar</param>
        public void NachbarVerbindungEinfuegen(string station, string nachbarNeu)
        {
            // im Graphen nachschauen, ob die Station (= der Knoten) schon existiert
            bool existiertStation = this.graph.ContainsKey(station);

            // Wenn ja, können wir eine Verbindung aufbauen
            // Wenn nein, haben wir Pech gehabt
            if (existiertStation == true)
            {
                // Hole alle bestehenden Nachbarn dieses Knotens (kann auch leer sein)
                LinkedList<string> nachbarn = this.graph[station];
                
                // prüfen, ob der Nachbar schon in der Liste existiert
                bool existiertNachbar = nachbarn.Contains(nachbarNeu);

                // Wenn ja, brauchen wir ihn nicht nochmals hinzufügen
                if (existiertNachbar == false)
                {
                    // Nachbarn der Liste hinzufügen
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
        /// Einfügen einer Station in eine Übersicht vom Typ Dictionary
        /// </summary>
        /// <param name="name">Name der einzufügenden Station (eindeutig)</param>
        /// <param name="linie">Objekt einer Station</param>
        /// <returns>true wenn das Einfügen erfolgreich war - false bei Misserfolg</returns>
        public void StationEinfuegen(string name, Station station)
        {
            // TODO: Einfügen einer Station - analog zu LinieEinfuegen
            // inkl. return values true/false bei Erfolg/Misserfolg
        }


        /// <summary>
        /// Ausgabe der Namen aller Linien, die in uebersichtLinien gespeichert sind
        /// </summary>
        public void LinienAusgabe()
        {
            foreach (String key in this.uebersichtLinien.Keys)
            {
                Linie aktuelleLinie = uebersichtLinien[key];
                Console.WriteLine(aktuelleLinie.getName());
            }
        }

        /// <summary>
        /// Verkehrsnetz aus Datei einlesen und Liste bzw. Graphen aufbauen
        /// Format der Datei:
        ///     Knotenname;Nachbar 1;Entfernung;Linie;Nachbar 2;Entfernung;Linie;...
        /// Annahme: Pro Datei wird nur die Information für 1 Linie angegeben
        /// </summary>
        public void Einlesen()
        {
            // Datei öffnen
            StreamReader sr = new StreamReader(@"..\..\input\LinieU2.txt");

            // Leeres Linienobjekt erzeugen
            Linie linie = new Linie();

            // Solange lesen bis das Ende der Datei erreich ist
            while (!sr.EndOfStream)
            {
                // Einzelne Zeile lesen
                string zeile = sr.ReadLine();

                // Gelesene Teile in Blöcke zerteilen - Trennzeichen: Strichpunkt ;
                string[] bloecke = zeile.Split(';');

                // An erster Position muss immer der Knotenname (die Station) stehen
                // Diese fügen wir in die Stationenliste unserer Linie ein
                linie.ErsteStationEinfuegen(bloecke[0]);
                
                // Ausgabe des Stationennamens
                Console.Write("{0}: ", bloecke[0]);

                // Ebenso wird der erste Block (= Knoten) in den Graphen eingefügt
                this.StationInGraphEinfuegen(bloecke[0]);

                // Es können beliebig viele Nachbarn in der Datei stehen
                // Die Schleife iteriert über alle Blöcke bis die Gesamtlänge erreicht wurde
                // Es wird jeweils immer um +3 weitergesprungen, da pro Nachbar
                // 3 Informationen vorhanden sind (Name, Entfernung, Linie)
                for (int i = 1; i < bloecke.Length; i = i + 3)
                {
                    // Ignoriere leere Blöcke (z.b. vom Ende der Linie)
                    if (bloecke[i] != "")
                    {
                        // Nachbar ausgeben
                        Console.Write("{0}, ", bloecke[i]);

                        // Nachbar in Graph einfügen = Verbindung zw.
                        // zwei Knoten aufbauen
                        this.NachbarVerbindungEinfuegen(bloecke[0], bloecke[i]);
                    }
                }

                Console.WriteLine();    // Leerzeile erzeugen
            }

            // Als Test geben wir die gesamte Stationenliste nochmals aus
            Console.WriteLine("########################");
            linie.AusgabeStationen();

            // Einfügen der aktuell erstellten Linie (Linienobjekt mit Stationenliste)
            // in die Übersicht des Verkehrsnetzhelpers
            this.LinieEinfuegen("u2", linie);
        }

        #region
        public void EinlesenAlt()
        {
            try
            {
                StreamReader reader = new StreamReader(@"..\..\input\ubahn_km.csv");
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
        #endregion
    }
}
