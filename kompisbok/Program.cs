using System;

namespace Kompisbok
{
    class KompisBok
    {
        static Kompis[] kompisregister = new Kompis[0]; //vi börjar vektorn med 0 platser. static=klassvariabel, det finns bara ETT kompisregister i programmet

        public static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("\nHej kompis!!");
            Console.WriteLine("Vad vill du/ni hitta på idag?");
            Console.WriteLine("\n-----------------------------------");
            Console.Write("\n1 - Visa kompislista");
            Console.Write("\n2 - Lägg till kompis");
            Console.Write("\n3 - Redigera eller ta bort kompis");
            Console.Write("\n4 - Stäng kompisboken\n");
            Console.WriteLine("\n-----------------------------------");
            Console.Write("\nVälj menyval genom att skriva in rätt siffra: ");
            int menyval = int.Parse(Console.ReadLine());

            /*if (menyval == 1)
            {
                SkrivUtKompisRegister();
            }*/
            if (menyval == 2)
            {
                do
                {
                    LäggTillKompis();
                    Console.Write("\nVill du lägga till en kompis till?? (j/n): ");
                } while (Console.ReadLine() != "n");
                SkrivUtKompisRegister();
                Console.Write("\n\nHejdå kompis!! :D");
                Console.ReadLine();
            }
            /*if (menyval == 4)
            {
                Console.Write("Hejdå kompis!! :D");
            }*/


        }

        //metod för menyval 1 där kompislistan kommer att skrivas ut i konsolen
        static void SkrivUtKompisRegister()
        {
            Console.WriteLine("\n\nHär är dina kompisar: ");
            Console.WriteLine("NAMN \t\t FÖDELSEDAG \t TELEFONNUMMER \t FAVVOFÄRG");
            for (int i = 0; i < kompisregister.Length; i++) //i en loop kommer varje kompis att skrivas ut i konsolen kompis för kompis
            {
                Console.WriteLine(kompisregister[i].namn + "\t\t" + kompisregister[i].fodelsedatum + "\t" + kompisregister[i].telefonnummer + "\t" + kompisregister[i].farg);
            }
        }

        //menyval 2 där man lägger till kompisar i boken
        static void LäggTillKompis()
        {
            Kompis ny = new Kompis(); //skapa ett objekt, i temporära variabeln "ny"
            Console.WriteLine("Kul med en ny kompis! Låt oss lägga till henne/honom!");
            Console.Write("\nNya kompisen namn: ");
            ny.namn = Console.ReadLine();
            Console.Write("Nya kompisens födelsedag (skriv såhär 01 jan 1999): ");
            ny.fodelsedatum = Console.ReadLine();
            Console.Write("Nya kompisens telefonnummer (skriv såhär 0712345678: ");
            while (true)
            {
                try
                {
                    ny.telefonnummer = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("\n" + e + "\n\n");
                    Console.WriteLine("Du matade inte in telefonnummret korrekt. \nSe till att du skriv såhär: 0712345678");
                }
            }
            Console.Write("Nya kompisens favvofärg: ");
            ny.farg = Console.ReadLine();

            kompisregister = UtokaVektor(kompisregister, ny); //anropar metoden för att utöka vektorn
        }

        //metod för att utöka vektorn
        public static Kompis[] UtokaVektor(Kompis[] vektor, Kompis nytt)
        {
            Kompis[] nyVektor = new Kompis[vektor.Length + 1];
            for (int i = 0; i < vektor.Length; i++)
                nyVektor[i] = vektor[i];
            nyVektor[vektor.Length] = nytt;
            return nyVektor;
        }

        /* //denna ska vi använda sedan för ta bort objekt från vektorn
        static Kompis[] DecreaseArray(Kompis[] vektor)
        {
            Kompis[] nyVektor = new Kompis[vektor.Length - 1];
            for (int i = 0; i < vektor.Length - 1; i++)
            {
                nyVektor[i] = vektor[i];
            }
            return nyVektor;
        }*/




        /* DETTA ÄR ETT FÖRSLAG PÅ MENY-METOD
        public static void Meny()
        {
            Console.Write("-----------------------------------");
            Console.Write("\nHej kompis!!");
            Console.Write("\nVad vill du/ni hitta på idag?");
            Console.Write("\n-----------------------------------");
            Console.Write("\n1 - Visa kompislista");
            Console.Write("\n2 - Lägg till kompis");
            Console.Write("\n3 - Redigera eller ta bort kompis");
            Console.Write("\n4 - Stäng kompisboken");
            Console.Write("\n-----------------------------------");
            Console.Write("\nVälj menyval genom att skriva in rätt siffra \n");

            /*while (true)
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
                            break;
                            //default:
                    }
                }
            }
        }
        //metod för att visa KompisLista
        public Kompis KompisLista(string namn, DateTime fodelsedatum, int telefonnummer, string farg)
        {
            //kompisbok är självaste boken som visar listan med kompisarna
            //Skriver ut kompislistan med alla attribut
            Console.WriteLine(
                kompisLista.namn + "\t\t" + kompisLista.fodelsedatum + "\t" + kompisLista.telefonnummer + "\t" + kompisLista.farg); 
        }*/
    }
}
