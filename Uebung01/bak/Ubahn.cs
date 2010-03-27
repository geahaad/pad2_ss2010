using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uebung01
{
    /// <summary>
    /// Ich bin eine U-Bahn
    /// </summary>
    class Ubahn
    {
        private int anzStehplaetze;
        private int anzSitzplaetze;
        private int kmStand;
        private int aktFahrerDienstnr;
        private string typ;

        public Ubahn()
        {
            this.anzStehplaetze = 60;
            this.anzSitzplaetze = 30;
            this.kmStand = 0;
            this.typ = "Standard-Ubahn";
        }

        public Ubahn(int steh, int sitz, string typ)
        {
            this.anzStehplaetze = steh;
            this.anzSitzplaetze = sitz;
            this.typ = typ;
        }

        public void Fahren()
        {
            Console.WriteLine("U-Bahn fährt");
        }

        public void Ansage()
        {
            Console.WriteLine("Zug fährt ab");
        }

        public void TuerOeffnen()
        {
            Console.WriteLine("Türen öffnen");
        }

        public void TuerSchliessen()
        {
            Console.WriteLine("Türen schließen");
        }

        public string GetTyp()
        {
            return this.typ;
        }

        public int GetAktFahrerDienstnr()
        {
            return this.aktFahrerDienstnr;
        }

        public void SetAktFahrerDienstnr(int nr)
        {
            // Prüfungen ob Dienstnummer existiert
            // ...
            this.aktFahrerDienstnr = nr;
        }
    }
}
