using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAD2_Verkehrsnetz
{
    class VerkehrsnetzHelper
    {
        Dictionary<string, Linie> uebersichtLinien;
        
        //TODO liste aller stationen (Type: Dictionary)

        public VerkehrsnetzHelper()
        {
            this.uebersichtLinien = new Dictionary<string, Linie>();
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

    }
}
