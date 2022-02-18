using System;

namespace Kompisbok
{
    class KompisBok
    {
        static Kompis[] kompisregister = new Kompis[0]; //vi börjar vektorn med 0 platser. static=klassvariabel, det finns bara ETT kompisregister i programmet

        public static void Main(string[] args)
        {
            //ToDO LaddaSparadTextfil();
            Meny();
            //ToDO SparaTillTextfil();
        }

        /// <summary>
        /// metod för programmets meny
        /// </summary>
        public static void Meny()
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("\nHej kompis!!");
            Console.WriteLine("Vad vill du/ni hitta på?");
            Console.WriteLine("\n-----------------------------------");
            Console.Write("\n1 - Visa kompislista");
            Console.Write("\n2 - Lägg till kompis");
            Console.Write("\n3 - Redigera eller ta bort kompis"); //ToDo metod för att ta bort kompis. Redigera är inte ett krav för godkänt
            Console.Write("\n4 - Stäng kompisboken\n");
            Console.WriteLine("\n-----------------------------------");
            Console.Write("\nVälj menyval genom att skriva in rätt siffra: ");
            int menyval = int.Parse(Console.ReadLine());
            //ToDO if-meny eller switch-case??



            if (menyval == 1)
            {
                SkrivUtKompisRegister();
            }
            else if (menyval == 2)
            {
                do
                {
                    LäggTillKompis();
                    Console.Write("\nVill du lägga till en kompis till?? (j/n): ");
                } while (Console.ReadLine() != "n");
                Meny(); 
            }

            //ToDO menyval == 3 ta bort en kompis

            else if (menyval == 4)
            {
                Console.Write("Hejdå kompis!! :D");
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
            //ToDO lägga till så att registret sorteras enligt nån viss ordning, tex namn
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
            Console.WriteLine("Kul med en ny kompis! Låt oss lägga till henne/honom!");
            Console.Write("\nNya kompisen namn: ");
            ny.namn = Console.ReadLine();
            Console.Write("Nya kompisens födelsedag (skriv såhär: ååmmdd): "); //kan man lägga till en == av något slag som hantering av fel inmatning?
            ny.fodelsedatum = MataInInt();
            Console.Write("Nya kompisens telefonnummer (skriv såhär: 46712345678: "); //influderar riktnummer för att annars går vi miste om den första 0:an i utskriften
            ny.telefonnummer = MataInInt();
            Console.Write("Nya kompisens favvofärg: ");
            ny.farg = Console.ReadLine();

            kompisregister = UtokaVektor(kompisregister, ny); //anropar metoden för att utöka vektorn
        }

        /// <summary>
        /// metod för hantering av fel inmatning vid int-typ
        /// </summary>
        /// <returns></returns>
        public static int MataInInt() 
        {
            int check;
            while (!int.TryParse(Console.ReadLine(), out check))//Medan inmatat inte är heltal skriv ut felmedelande och fråga igen.
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
        public static Kompis[] UtokaVektor(Kompis[] vektor, Kompis nytt)
        {
            Kompis[] nyVektor = new Kompis[vektor.Length + 1];
            for (int i = 0; i < vektor.Length; i++)
                nyVektor[i] = vektor[i];
            nyVektor[vektor.Length] = nytt;
            return nyVektor;
        }

        /// <summary>
        /// denna metod ska vi använda sedan för ta bort objekt från vektorn
        /// </summary>
        /// <param name="vektor"></param>
        /// <returns></returns>
        public static Kompis[] DecreaseArray(Kompis[] vektor)
        {
            Kompis[] nyVektor = new Kompis[vektor.Length - 1];
            for (int i = 0; i < vektor.Length - 1; i++)
            {
                nyVektor[i] = vektor[i];
            }
            return nyVektor;
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

        //ToDO skapa en metod så att det skriver ut i ett textdokument
        /// <summary>
        /// metod som skriver ut boken i ett textdokument
        /// </summary>
        public static void KompisStream()
        {

        }


        /* DETTA ÄR ETT FÖRSLAG PÅ MENY-METOD
        public static void Meny()
        {

            /*while (!avsluta)
            {
                int menyval;
                Console.Write("\nVälj menyval: ");
                while (!int.TryParse(Console.ReadLine(), out menyval))
                {
                    Console.Write("\nDet blev något fel i inmatningen.");

                    switch (menyval)
                    {
                        case 1:
                            KompisLista();
                        case 2:
                            LaggTillKompis(); //nadjas
                        case 3:
                            RedigeraKompis();
                        case 4:
                            Console.Write("Hejdå kompis!");
                            avsluta = true;
                            break;
                       //default:
                    }
                }
            }
        }*/

    }
}
