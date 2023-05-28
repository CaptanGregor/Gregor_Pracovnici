using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gregor_Pracovnici
{
    internal class Zamestnanec:Osoba
    {
        public int PocetLetPraxe { get; set; }
        public int PocetDeti { get; set; }

        public Zamestnanec(string jmeno, string prijmeni, string rodneCislo, string bydliste, int pocetOdpracovanychHodin, int pocetLetPraxe, int pocetDeti)
            : base(jmeno, prijmeni, rodneCislo, bydliste, pocetOdpracovanychHodin)
        {
            PocetLetPraxe = pocetLetPraxe;
            PocetDeti = pocetDeti;
        }
    }
}
