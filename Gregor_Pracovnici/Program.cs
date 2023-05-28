using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gregor_Pracovnici
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Zamestnanec> zamestnanci = new List<Zamestnanec>();
            List<Brigadnik> brigadnici = new List<Brigadnik>();

            Console.WriteLine("Vítejte ve firmě!");

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Vyberte možnost:");
                Console.WriteLine("1 - Přidat zaměstnance");
                Console.WriteLine("2 - Přidat brigádníka");
                Console.WriteLine("3 - Vypsat všechny zaměstnance");
                Console.WriteLine("4 - Vypsat všechny brigádníky");
                Console.WriteLine("5 - Vypočítat mzdy a stravenky");
                Console.WriteLine("0 - Ukončit program");

                int volba;
                if (!int.TryParse(Console.ReadLine(), out volba))
                {
                    Console.WriteLine("Neplatná volba. Zadejte číslo možnosti.");
                    continue;
                }
                Console.Clear();
                switch (volba)
                {
                    case 1:                        
                        PridatZamestnance(zamestnanci);
                        break;
                    case 2:
                        PridatBrigadnika(brigadnici);
                        break;
                    case 3:
                        VypsatZamestnance(zamestnanci);
                        Console.ReadKey();
                        break;
                    case 4:
                        VypsatBrigadniky(brigadnici);
                        Console.ReadKey();
                        break;
                    case 5:
                        VypocitatMzdy(zamestnanci, brigadnici);
                        Console.ReadKey();
                        break;
                    case 0:
                        Console.WriteLine("Program ukončen.");
                        return;
                    default:
                        Console.WriteLine("Neplatná volba. Zadejte číslo možnosti.");
                        break;
                }
            }
        }

        static void PridatZamestnance(List<Zamestnanec> zamestnanci)
        {
            Console.WriteLine("Zadejte informace o zaměstnanci:");
            Console.Write("Jméno: ");
            string jmeno = Console.ReadLine();
            Console.Write("Příjmení: ");
            string prijmeni = Console.ReadLine();
            Console.Write("Rodné číslo: ");
            string rodneCislo = Console.ReadLine();
            Console.Write("Bydliště: ");
            string bydliste = Console.ReadLine();
            Console.Write("Počet odpracovaných hodin: ");
            int odpracovaneHodiny;
            if (!int.TryParse(Console.ReadLine(), out odpracovaneHodiny))
            {
                Console.WriteLine("Neplatná hodnota pro počet odpracovaných hodin. Zaměstnanec nebyl přidán.");
                return;
            }
            Console.Write("Počet let praxe: ");
            int pocetLetPraxe;
            if (!int.TryParse(Console.ReadLine(), out pocetLetPraxe))
            {
                Console.WriteLine("Neplatná hodnota pro počet let praxe. Zaměstnanec nebyl přidán.");
                return;
            }
            Console.Write("Počet dětí: ");
            int pocetDeti;
            if (!int.TryParse(Console.ReadLine(), out pocetDeti))
            {
                Console.WriteLine("Neplatná hodnota pro počet dětí. Zaměstnanec nebyl přidán.");
                return;
            }

            Zamestnanec zam = new Zamestnanec(jmeno, prijmeni, rodneCislo, bydliste, odpracovaneHodiny, pocetLetPraxe, pocetDeti);
            zamestnanci.Add(zam);

            Console.WriteLine("Zaměstnanec byl úspěšně přidán.");
        }

        static void PridatBrigadnika(List<Brigadnik> brigadnici)
        {
            Console.WriteLine("Zadejte informace o brigádníkovi:");
            Console.Write("Jméno: ");
            string jmeno = Console.ReadLine();
            Console.Write("Příjmení: ");
            string prijmeni = Console.ReadLine();
            Console.Write("Rodné číslo: ");
            string rodneCislo = Console.ReadLine();
            Console.Write("Bydliště: ");
            string bydliste = Console.ReadLine();
            Console.Write("Počet odpracovaných hodin: ");
            int odpracovaneHodiny;
            if (!int.TryParse(Console.ReadLine(), out odpracovaneHodiny))
            {
                Console.WriteLine("Neplatná hodnota pro počet odpracovaných hodin. Brigádník nebyl přidán.");
                return;
            }

            Brigadnik brig = new Brigadnik(jmeno, prijmeni, rodneCislo, bydliste, odpracovaneHodiny);
            brigadnici.Add(brig);

            Console.WriteLine("Brigádník byl úspěšně přidán.");
        }

        static void VypsatZamestnance(List<Zamestnanec> zamestnanci)
        {
            Console.WriteLine("Seznam zaměstnanců:");
            foreach (var zam in zamestnanci)
            {
                Console.WriteLine(zam.Jmeno + " " + zam.Prijmeni);
            }
        }

        static void VypsatBrigadniky(List<Brigadnik> brigadnici)
        {
            Console.WriteLine("Seznam brigádníků:");
            foreach (var brig in brigadnici)
            {
                Console.WriteLine(brig.Jmeno + " " + brig.Prijmeni);
            }
        }

        static void VypocitatMzdy(List<Zamestnanec> zamestnanci, List<Brigadnik> brigadnici)
        {
            Console.Write("Zadejte hodinovou sazbu: ");
            double sazba;
            if (!double.TryParse(Console.ReadLine(), out sazba))
            {
                Console.WriteLine("Neplatná hodnota pro hodinovou sazbu. Mzdy nebyly vypočítány.");
                return;
            }

            Console.WriteLine("Výpočet mzdy a stravenek:");

            foreach (var zam in zamestnanci)
            {
                double hrubaMzda = zam.PocetOdpracovanychHodin * sazba;
                double cistaMzda = hrubaMzda - (hrubaMzda * 0.3) + (hrubaMzda * 0.02 * zam.PocetDeti);
                double stravenky = zam.PocetOdpracovanychHodin / 8 * 100;

                Console.WriteLine("Zaměstnanec: {0} {1}", zam.Jmeno, zam.Prijmeni);
                Console.WriteLine("Čistá mzda: {0} Kč", cistaMzda);
                Console.WriteLine("Částka k proplacení ve stravenkách: {0} Kč", stravenky);
                Console.WriteLine();
            }

            foreach (var brig in brigadnici)
            {
                double hrubaMzda = brig.PocetOdpracovanychHodin * sazba;
                double cistaMzda = hrubaMzda - (hrubaMzda * 0.15);

                Console.WriteLine("Brigádník: {0} {1}", brig.Jmeno, brig.Prijmeni);
                Console.WriteLine("Čistá mzda: {0} Kč", cistaMzda);
                Console.WriteLine();
            }
            
        }
    }
}
