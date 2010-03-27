using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uebung01
{
    class VerkehrsnetzHelper
    {
        Dictionary<string, Linie> uebersichtLinien;
        
        //TODO liste aller stationen

        public VerkehrsnetzHelper()
        {
            this.uebersichtLinien = new Dictionary<string, Linie>();
        }

        public void LinieEinfuegen(string name, Linie linie)
        {
            bool gefunden = this.uebersichtLinien.ContainsKey(name);
            if (gefunden == false)
            {
                this.uebersichtLinien.Add(name, linie);
            }
        }

    }
}
