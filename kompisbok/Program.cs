﻿using System;
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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nHej kompis!!");
            Console.WriteLine("Vad vill du/ni hitta på?");
            Console.ForegroundColor = ConsoleColor.White;
            Meny1();
        }

        #region Meny

        /// <summary>
        /// metod för programmets meny
        /// </summary>
        public static void Meny()
        {
            Console.WriteLine("\n-----------------------------------");
            Console.Write("1 - Visa kompislista");
            Console.Write("\n2 - Lägg till kompis");
            Console.Write("\n3 - Ta bort kompis"); 
            Console.Write("\n4 - Spara och stäng kompisboken\n");
            Console.WriteLine("-----------------------------------");
            Console.Write("\nVälj menyval genom att skriva in rätt siffra: ");
            double menyval = FelhanteringDouble();
            //ToDO if-meny eller switch-case??

            if (menyval == 1)
            {
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
            else if (menyval == 3)
            {
                SokningViaNamn();
                Meny();
            }
            else if (menyval == 4)
            {
                SparaTillTextfil();
                Console.WriteLine($"Sparat: {DateTime.Now}");
                Console.Write("\n\nHejdå kompis!! :D");
            }
            else
            {
                Console.Write("\nOjdå, du verkar ha skrivit in fel! Vi försöker igen :)");
                Meny();
            }
        }
        #endregion

        #region Meny1

        public static void Meny1() //denna metod används inte just nu
        {
            bool avsluta = false; //bytte till false
            while (!avsluta)
            {
                Console.WriteLine("\n-----------------------------------");
                Console.Write("1 - Visa kompislista");
                Console.Write("\n2 - Lägg till kompis");
                Console.Write("\n3 - Ta bort kompis");
                Console.Write("\n4 - Spara och stäng kompisboken\n");
                Console.WriteLine("-----------------------------------");
                Console.Write("\nVälj menyval genom att skriva in rätt siffra: ");
                double menyval = FelhanteringDouble();

                switch (menyval)
                {
                    case 1:
                        Console.WriteLine("Visa kompislista");
                        SkrivUtKompisRegister();
                        break;
                    case 2:
                        Console.WriteLine("Lägg till kompis");
                        do
                        {
                            LäggTillKompis();
                            Console.Write("\nVill du lägga till en kompis till?? (j/n): "); //byta till MataInInt funktionen ist så man får en säkrare frlhantering??
                        } while (Console.ReadLine().ToLower() != "n");
                        break;
                    case 3:
                        Console.WriteLine("Ta bort en kompis");
                        SokningViaNamn();
                        break;
                    case 4:
                        SparaTillTextfil();
                        Console.WriteLine("\n\nSparat: ", DateTime.Now);
                        Console.Write("\nHejdå kompis!! :D");
                        avsluta = true;
                        break;
                    default:
                        Console.WriteLine("Hmm.. så ska det inte vara");
                        break;
                }
            }
        }
        #endregion

        #region Skriv ut register

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

        #endregion

        #region Lägg till kompis

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
            ny.fodelsedatum = FelhanteringDouble();
            Console.Write("Nya kompisens telefonnummer (skriv såhär: 46712345678: "); //inkluderar riktnummer för att annars går vi miste om den första 0:an i utskriften. Här måste vi även använda oss utan double för att den ska kunna spara ett så stort tal. Vi ändrade felhanteringen MataInDouble() för att passa detta.
            ny.telefonnummer = FelhanteringDouble();
            Console.Write("Nya kompisens favvofärg: ");
            ny.farg = Console.ReadLine();

            LäggTillKompisTillVektor(ny); //anropar metoden för att utöka vektorn
            SorteraEfterNamn();
        }
        #endregion

        #region Felhantering av Double

        /// <summary>
        /// Felhantering av inmatning vid int-typ
        /// </summary>
        /// <returns></returns>
        public static double FelhanteringDouble() //ToDO byta namn på metoden till något i stil med FelhanteringDouble??
        {
            double check;
            while (!double.TryParse(Console.ReadLine(), out check))//Medan inmatat inte är heltal skriv ut felmedelande och fråga igen.
            {
                Console.Write("Hmm, du verkar ha skrivt fel input. Försök igen: ");
            }
            return check;
        }
        #endregion

        #region Ökning och minskning av vektor

        /// <summary>
        /// Ta bort kompisar(objekt) från vektorn
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

        /// <summary>
        /// Lägga över den gamla vektorn till en ny vektor med den nya kompisen
        /// </summary>
        /// <param name="gamlaKompisRegister"></param>
        /// <param name="nyKompis"></param>
        /// <returns></returns>
        public static void LäggTillKompisTillVektor(Kompis nyKompis)
        {
            Kompis[] nyKompisRegister = new Kompis[kompisregister.Length + 1];
            for (int i = 0; i < kompisregister.Length; i++)
            {
                nyKompisRegister[i] = kompisregister[i]; 
            }
            nyKompisRegister[kompisregister.Length] = nyKompis;
            kompisregister = nyKompisRegister;
        }
        #endregion

        #region Sortering

        /// <summary>
        /// Sorterar kompisregistret efter namn
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
                    Swap(minst, i);
                }
            }
        }
        
        /// <summary>
        /// Metod som stöttar metoden SorteraEfterNamn och byter plats på två objekt i vektorn
        /// </summary>
        /// <param name="vektor"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Swap(int a, int b)
        {
            Kompis tilf = kompisregister[a]; //tilf=tillfällig
            kompisregister[a] = kompisregister[b];
            kompisregister[b] = tilf;
        }
        #endregion

        #region Sökning

        /// <summary>
        /// Söker efter kompis och raderar sedan från vektorn
        /// </summary>
        public static void SokningViaNamn()
        {
            Console.Write("\nSök efter personen: ");
            string sokning = Console.ReadLine().ToLower();
            bool kontroll = true;
            for (int i = 0; i < kompisregister.Length; i++)
            {
                if (kompisregister[i].namn.ToLower().CompareTo(sokning) == 0)
                {
                    Console.WriteLine($"\nVi hittade: {sokning}!");
                    TaBortElement(i);
                    Console.WriteLine($"{sokning} är nu borttagen från boken.");
                    kontroll = false;
                }
            }
            if (kontroll)
            {
                Console.WriteLine("\nPersonen som du söker efter finns inte i boken");
            }
        }
        #endregion

        #region StreamReader och StreamWriter
        /// <summary>
        /// Läser in alla element från textfilen och sparar i vektorn kompisregister
        /// </summary>
        public static void LaddaSparadTextFil()
         {
            StreamReader infil = new StreamReader("RegisterLista.txt");
            string rad;
            while ((rad = infil.ReadLine()) != null)
            {
                Kompis ny = new Kompis();
                string[] attribut = rad.Split('\t');
                ny.namn = attribut[0];
                ny.fodelsedatum = double.Parse(attribut[1]);
                ny.telefonnummer = double.Parse(attribut[2]);
                ny.farg = attribut[3];

                LäggTillKompisTillVektor(ny);
            }
            infil.Close();
         }

        /// <summary>
        /// Skriver över vektorns innehåll in i en textfil
        /// </summary>
        public static void SparaTillTextfil()
        {
            StreamWriter utfil = new StreamWriter("RegisterLista.txt");
            for (int i = 0; i < kompisregister.Length; i++)
            {
                Kompis k = kompisregister[i];
                utfil.WriteLine("{0}\t{1}\t{2}\t{3}\t", k.namn, k.fodelsedatum, k.telefonnummer, k.farg);
            }
            utfil.Close();
        }
        #endregion
    }
}