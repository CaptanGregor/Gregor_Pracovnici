using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gregor_Pracovnici
{
    internal class Osoba
    {
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string RodneCislo { get; set; }
        public string Bydliste { get; set; }
        public int PocetOdpracovanychHodin { get; set; }

        public Osoba(string jmeno, string prijmeni, string rodneCislo, string bydliste, int pocetOdpracovanychHodin)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            RodneCislo = rodneCislo;
            Bydliste = bydliste;
            PocetOdpracovanychHodin = pocetOdpracovanychHodin;
        }
    }
}
