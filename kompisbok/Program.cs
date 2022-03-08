using System;
using System.IO;

namespace Kompisbok
{
    class KompisBok
    {
        static Kompis[] kompisregister = new Kompis[0]; //vi börjar vektorn med 0 platser. static=klassvariabel, det finns bara ETT kompisregister i programmet

        public static void Main(string[] args)
        {
            LaddaSparadTextFil();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("\nHej kompis!!");
            Console.WriteLine("Vad vill du/ni hitta på?");
            Meny();
            //ToDO SparaTillTextfil();
        }

        /// <summary>
        /// metod för programmets meny
        /// </summary>
        public static void Meny()
        {
            Console.WriteLine("\n-----------------------------------");
            Console.Write("1 - Visa kompislista");
            Console.Write("\n2 - Lägg till kompis");
            Console.Write("\n3 - Ta bort kompis"); //ToDo metod för att ta bort kompis. Redigera är inte ett krav för godkänt
            Console.Write("\n4 - Spara och stäng kompisboken\n");
            Console.WriteLine("-----------------------------------");
            Console.Write("\nVälj menyval genom att skriva in rätt siffra: ");
            int menyval = int.Parse(Console.ReadLine());
            //ToDO if-meny eller switch-case??

            if (menyval == 1)
            {
                //LaddaSparadTextFil();
                SkrivUtKompisRegister();
                Meny();
            }
            else if (menyval == 2)
            {
                do
                {
                    LäggTillKompis();
                    Console.Write("\nVill du lägga till en kompis till?? (j/n): ");
                } while (Console.ReadLine().ToLower() != "n");
                Meny();
            }
            //ToDO menyval == 3 ta bort en kompis
            else if (menyval == 3)
            {
                int i = 0;
                Console.Write("Sök efter personen: ");
                string sokning = Console.ReadLine();
                //SokningViaNamn(kompisregister, sokning);
                Meny();
            }
            else if (menyval == 4)
            {
                SparaTillTextfil();
                Console.Write("\n\nHejdå kompis!! :D");
            }
            else
            {
                Console.Write("Ojdå, du verkar ha skrivit in fel! Vi försöker igen :)");
            }
            //ToDO ifall användaren skriver in felaktigt menyval --> tillbaka till menyn
        }

        /// <summary>
        /// metod där kompislistan kommer att skrivas ut i konsolen. menyval 1
        /// </summary>
        static void SkrivUtKompisRegister()
        {
            Console.WriteLine("\n\nHär är dina kompisar: ");
            Console.WriteLine("NAMN \t\t FÖDELSEDAG \t TELEFONNUMMER \t FAVVOFÄRG");
            for (int i = 0; i < kompisregister.Length; i++) //i en loop kommer varje kompis att skrivas ut i konsolen kompis för kompis
            {
                Console.WriteLine(kompisregister[i].namn + "\t\t" + kompisregister[i].fodelsedatum + "\t\t" + kompisregister[i].telefonnummer + "\t" + kompisregister[i].farg);
            }
        }

        /// <summary>
        /// metod för att lägga till en kompis i boken. menyval 2
        /// </summary>
        public static void LäggTillKompis()
        {
            Kompis ny = new Kompis(); //skapa ett objekt, i temporära variabeln "ny"
            Console.WriteLine("\nKul med en ny kompis! Låt oss lägga till henne/honom!");
            Console.Write("\nNya kompisen namn: ");
            ny.namn = Console.ReadLine();
            Console.Write("Nya kompisens födelsedag (skriv såhär: ååmmdd): "); //kan man lägga till en == av något slag som hantering av fel inmatning?
            ny.fodelsedatum = MataInInt();
            Console.Write("Nya kompisens telefonnummer (skriv såhär: 46712345678: "); //inkluderar riktnummer för att annars går vi miste om den första 0:an i utskriften
            ny.telefonnummer = MataInInt();
            Console.Write("Nya kompisens favvofärg: ");
            ny.farg = Console.ReadLine();

            UtokaVektor(ny); //anropar metoden för att utöka vektorn
            SorteraEfterNamn();
        }

        /// <summary>
        /// felhantering av inmatning vid int-typ
        /// </summary>
        /// <returns></returns>
        public static double MataInInt() //ToDO byta namn på metoden till något i stil med FelhanteringDouble??
        {
            double check;
            while (!double.TryParse(Console.ReadLine(), out check))//Medan inmatat inte är heltal skriv ut felmedelande och fråga igen.
            {
                Console.Write("Hmm, du verkar ha skrivt fel input. Försök igen: ");
            }
            return check;
        }

        /// <summary>
        /// metod för att utöka vektorn
        /// </summary>
        /// <param name="vektor"></param>
        /// <param name="nytt"></param>
        /// <returns></returns>
        public static void UtokaVektor(Kompis nytt)
        {
            Kompis[] nyVektor = new Kompis[kompisregister.Length + 1];// Ändra namn på "nyvektor"
            for (int i = 0; i < kompisregister.Length; i++)
                nyVektor[i] = kompisregister[i];
            nyVektor[kompisregister.Length] = nytt;
            kompisregister = nyVektor;
        }

        /// <summary>
        /// denna metod ska vi använda sedan för ta bort objekt från vektorn
        /// </summary>
        /// <param name="vektor"></param>
        /// <returns></returns>
        public static void TaBortElement(int index)
        {
            Kompis[] nyVektor = new Kompis[kompisregister.Length - 1];
            for (int i = 0; i < index; i++)
            {
                nyVektor[i] = kompisregister[i];
            }
            for (int i = index + 1; i < kompisregister.Length; i++)
            {
                nyVektor[i - 1] = kompisregister[i];
            }
            kompisregister = nyVektor;
        }

        //ToDO metod för att lägga till gamla och nya kompisar i vektorn (sparar objekten (kompisarna) i vektorn)
        /// <summary>
        /// metod för att lägga till gamla och nya kompisar i vektorn
        /// </summary>
        /// <param name="gamlaKompisRegister"></param>
        /// <param name="nyKompis"></param>
        /// <returns></returns>
        public static Kompis[] LäggTillKompisTillVektor(Kompis[] gamlaKompisRegister, Kompis nyKompis)
        {
            Kompis[] nyKompisRegister = new Kompis[gamlaKompisRegister.Length + 1];
            for (int i = 0; i < gamlaKompisRegister.Length; i++)
            {
                nyKompisRegister[i] = gamlaKompisRegister[i];
            }
            nyKompisRegister[gamlaKompisRegister.Length] = nyKompis;
            return nyKompisRegister;
        }

        /// <summary>
        /// metod som sorterar kompisregistret efter namn
        /// </summary>
        public static void SorteraEfterNamn()
        {
            for (int i = 0; i < kompisregister.Length; i++)
            {
                int minst = i;

                for (int j = i + 1; j < kompisregister.Length; j++)
                {
                    if (kompisregister[minst].namn.CompareTo(kompisregister[j].namn) > 0)
                    {
                        minst = j;
                    }
                }
                if (i < minst)
                {
                    Swap(kompisregister, minst, i);
                }
            }
        }

        /// <summary>
        /// metod som stöttar metoden SorteraEfterNamn och byter plats på två objekt i vektorn
        /// </summary>
        /// <param name="vektor"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Swap(Kompis[] vektor, int a, int b)
        {
            Kompis tilf = vektor[a]; //tilf=tillfällig
            vektor[a] = vektor[b];
            vektor[b] = tilf;
        }

        /// <summary>
        /// Söker efter kompis och raderar sedan från vektorn
        /// </summary>
        /*public static int SokningViaNamn(Kompis[] kompisregister, string p)
        {
            int i = 0;
            Console.Write("Sök efter personen: ");
            string sokning = Console.ReadLine();
            for (int k = 0; k < kompisregister.Length; k++)
            {
                if (kompisregister[i].namn.ToUpper().CompareTo(sokning.ToUpper()) == 0)
                {
                    Console.WriteLine("Hittat personen!");
                    TaBortElement(i);
                    Console.WriteLine("Personen är nu borttagen från boken.\n\n");
                    return i;
                }
                return -1;
            }

            /*int i = 0;
            Console.Write("Sök efter personen: ");
            string sokning = Console.ReadLine();
            foreach (Kompis k in kompisregister)
            {
                for (kompisregister[i].namn.ToUpper().CompareTo(sokning.ToUpper()) != 0)
                {
                    Console.WriteLine("Hittade inte. Försök igen!");
                    //i++;
                    Console.Write("Sök efter personen: ");
                    sokning = Console.ReadLine();
                }
                Console.WriteLine("Hittat personen!");
                TaBortElement(i);
                Console.WriteLine("Personen är nu borttagen från boken.\n\n");
                break;
            }*/

            /*int i = 0;
            Console.Write("Sök efter personen: ");
            string sokning = Console.ReadLine();
            while (kompisregister[i].namn.ToUpper().CompareTo(sokning.ToUpper()) != 0)
            {
                Console.WriteLine("Hittade inte. Försök igen!");
                //i++;
                Console.Write("Sök efter personen: ");
                sokning = Console.ReadLine();
            }
            Console.WriteLine("Hittat personen!");
            TaBortElement(i);
            Console.WriteLine("Personen är nu borttagen från boken.\n\n");
        }*/

        //ToDO skapa en metod så att det skriver ut i ett textdokument



        
        public static void LaddaSparadTextFil()
        {
            StreamReader inTextfil = new StreamReader("RegisterLista.txt");
            if (inTextfil == null)
            {
                Console.WriteLine("Kompisboken är tom just nu");
            }
            else { }
            while (true)
            {
                string line = inTextfil.ReadLine();
                if (line == null) break;
                string[] lines = line.Split('\t');

                Kompis s = new Kompis();
                s.namn = lines[0];
                s.fodelsedatum = double.Parse(lines[1]);
                s.telefonnummer = double.Parse(lines[2]);
                s.farg = lines[3];

                kompisregister = LäggTillKompisTillVektor(kompisregister, s);
            }

            /*StreamReader infil = new StreamReader("RegisterLista.txt");
            string rad;
            while ((rad = infil.ReadLine()) != null)
            {
                Kompis ny = new Kompis();
                string[] attribut = rad.Split('\t');
                ny.namn = attribut[0];
                ny.fodelsedatum = int.Parse(attribut[1]);
                ny.telefonnummer = int.Parse(attribut[2]);
                ny.farg = attribut[3];

                //LäggTillKompis();
                /*infil.WriteLine("Namn: " + attribut[0]);
                infil.WriteLine("Födelsedag: " + attribut[1]);
                infil.WriteLine("Telefonnummer: " + attribut[2]);
                infil.WriteLine("Färg: " + attribut[3] + "\n");
            }
            infil.Close();*/
        }

        /// <summary>
        /// Skriver vektorns innehåll in i en textfil
        /// </summary>
        public static void SparaTillTextfil()
        {
            StreamWriter utfil = new StreamWriter("RegisterLista.txt");
            for (int i = 0; i < kompisregister.Length; i++)
            {
                Kompis k = kompisregister[i];
                utfil.Write("{0}\t{1}\t{2}\t{3}\t", k.namn, k.fodelsedatum, k.telefonnummer, k.farg);
            }
            utfil.Close();
        }
    }
}