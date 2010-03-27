using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uebung01
{
    class Program
    {
        static void Main(string[] args)
        {
            Linie u2 = new Linie("u2", "violett");
            u2.ErsteStationEinfuegen("Karlsplatz");
            u2.LetzteStationEinfuegen("Stadion");

            u2.StationEinfuegenNach("MQ", "Karlsplatz");
            u2.StationEinfuegenNach("MQ", "gibtsnicht");

            u2.AusgabeStationen();

            Linie u1 = new Linie("u1", "rot");
            Linie u4 = new Linie("u4", "grün");

            VerkehrsnetzHelper vnHelper = new VerkehrsnetzHelper();
            vnHelper.LinieEinfuegen("linie1", u1);
            vnHelper.LinieEinfuegen("linie2", u2);
            vnHelper.LinieEinfuegen("linie3", u4);
            vnHelper.LinieEinfuegen("linie3", u4);

            Console.ReadLine();
        }


        //static void Main(string[] args)
        //{
        //    Ubahn u1 = new Ubahn();
        //    Ubahn u2 = new Ubahn(100, 50, "Niederflur-Ubahn");

        //    String u1Typ = u1.GetTyp();
        //    Console.WriteLine(u1Typ);

        //    String u2Typ = u2.GetTyp();
        //    Console.WriteLine(u2Typ);

        //    u1.Ansage();
        //    u1.SetAktFahrerDienstnr(234);

        //    Console.ReadLine();
        //}
    }
}
