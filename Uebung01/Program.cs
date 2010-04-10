using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAD2_Verkehrsnetz
{
    class Program
    {
        static void Main(string[] args)
        {
            //Linie u1 = new Linie("u1", "rot");
            //u1.ErsteStationEinfuegen("Leopoldau");
            //u1.LetzteStationEinfuegen("Reumannplatz");

            //Linie u2 = new Linie("u2", "violett");
            //u2.ErsteStationEinfuegen("Karlsplatz");
            //u2.LetzteStationEinfuegen("Stadion");

            //u2.StationEinfuegenNach("MQ", "Karlsplatz");    // erfolgreich
            //u2.StationEinfuegenNach("MQ", "gibtsnicht");    // kann nicht eingefügt werden

            //u2.StationEinfuegenNach("Volkstheater", "MQ");
            //u2.StationEinfuegenNach("Rathaus", "Volkstheater");
            //u2.StationEinfuegenNach("Schottentor", "Rathaus");
            //u2.StationEinfuegenNach("Schottenring", "Schottentor");
            //u2.StationEinfuegenNach("Taborstraße", "Schottenring");
            //u2.StationEinfuegenNach("Praterstern", "Taborstraße");
            //u2.StationEinfuegenNach("Messe-Prater", "Praterstern");
            //u2.StationEinfuegenNach("Krieau", "Messe-Prater");

            //Console.WriteLine("\nNormale Richtung");
            //u2.AusgabeStationen();
            //Console.WriteLine("\nGegenrichtung:");
            //u2.AusgabeStationenGegenrichtung();

            //Linie u3 = new Linie("u3", "orange");
            //Linie u4 = new Linie("u4", "grün");
            //Linie u6 = new Linie("u6", "braun");

            //VerkehrsnetzHelper vnHelper = new VerkehrsnetzHelper();
            //vnHelper.LinieEinfuegen("linie1", u1);
            //vnHelper.LinieEinfuegen("linie2", u2);
            //vnHelper.LinieEinfuegen("linie3", u4);
            //vnHelper.LinieEinfuegen("linie3", u4);  // kann nicht eingefügt werden - Duplikat

            //vnHelper.LinienAusgabe();


            VerkehrsnetzHelper vnHelper = new VerkehrsnetzHelper();
            vnHelper.StationInGraphEinfuegen("Hütteldorf");
            vnHelper.StationInGraphEinfuegen("Schönbrunn");
            vnHelper.StationInGraphEinfuegen("Spittelau");
            vnHelper.StationInGraphEinfuegen("Karlsplatz");

            vnHelper.StationInGraphEinfuegen("Hütteldorf"); // Fehler: existiert bereits


            vnHelper.NachbarVerbindungEinfuegen("Hütteldorf", "Ober St. Veit");
            vnHelper.NachbarVerbindungEinfuegen("Schönbrunn", "Hietzing");
            vnHelper.NachbarVerbindungEinfuegen("Schönbrunn", "Hietzing"); // Fehler
            vnHelper.NachbarVerbindungEinfuegen("Schönbrunn", "Meidlinger Hauptstraße");

            vnHelper.NachbarVerbindungEinfuegen("Spitelau", "Heiligenstadt"); // Fehler

            Console.ReadLine();
        }
    }
}
