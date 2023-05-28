using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gregor_Pracovnici
{
    internal class Brigadnik:Osoba
    {
        public Brigadnik(string jmeno, string prijmeni, string rodneCislo, string bydliste, int pocetOdpracovanychHodin)
        : base(jmeno, prijmeni, rodneCislo, bydliste, pocetOdpracovanychHodin)
        {
        }
    }
}
