using System;
using System.Collections.Generic;
using System.Threading;

namespace Assignment
{
    class Program
    {

        static void Main(string[] args)
        {
            Menu();
        }

        //skapa en lista för medlemmar
        static List<Members> listOfNorr = new List<Members>();
        //Starta med en metod för login 
        //Lägg till så användaren har 3 försök på sig
        private static void Login()
        {
            bool checkPass = true;
            int tries = 1;
            int counter = 2;
            do
            {
                Console.WriteLine("Välkommen till .Net20D");
                Console.Write("Ange Löserord för tillgång till din basgrupp: ");
                string passWord = Console.ReadLine();
                if (passWord == "Norrlänningarna")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Korrekt Lösen! Välkommen till Norrlänningarna");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    checkPass = false;
                    Console.Clear();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Felaktigt lösenord! Försök nummer {tries} du har {counter} försök kvar");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                tries++;
                counter--;
                if (tries > 3)
                {
                    Console.WriteLine("Du har matat in fel lösenord 3 gånger, vänta en stund och försök igen");
                    Thread.Sleep(4000);
                    Environment.Exit(0);
                }

            } while (checkPass);
        }
        //Skapa där efter en metod för menyn och utgå därifrån vad som skall göras
        private static void Menu()
        {
            MembersOfNorr();
            Login();
            do
            {

                Console.WriteLine("Välkommen till Basgrupp Norrlänningarna!");
                Console.WriteLine("1. Visa elever");
                Console.WriteLine("2. Visa info om elever");
                Console.WriteLine("3. Ta bort elev");
                Console.WriteLine("4. Lägg till en elev");
                Console.WriteLine("5. Avsluta");
                char choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        ShowStudentsName();
                        break;
                    case '2':
                        ShowStudentsInfo();
                        break;
                    case '3':
                        RemoveStudent();
                        break;
                    case '4':
                        AddStudent();
                        break;
                    case '5':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        break;
                }

            } while (true);
        }


        private static void ShowStudentsName()
        {
            //Lista samtliga namn
            Console.Clear();
            foreach (Members students in listOfNorr)
            {
                Console.WriteLine($"{students.Name},");
            }
            Console.WriteLine();
            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn");
            Console.ReadKey();
            Console.Clear();
        }
        private static void ShowStudentsInfo()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Information om elever i Norrlänningarna! Tryck på siffran som motsvarar eleven för mer information");

                int index = 1;
                foreach (Members students in listOfNorr)
                {
                    Console.WriteLine("{0}", index + "\t" + $"{students.Name}");
                    index++;
                }
                Console.WriteLine();
                Console.WriteLine("Vill du ha mer info om någon student tryck siffran som representerar dem.");
                int input = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < listOfNorr.Count; i++)
                {
                    if (input - 1 == i)
                    {
                        Console.WriteLine(listOfNorr[i]);
                    }
                }
                Console.WriteLine("Vill du ha info om någon annan? Ange \"ja\", \nAnnars tryck valfri tangent för att återgå till menyn\n");
                string askAgain = Console.ReadLine();
                if (askAgain == "ja")
                {
                    ShowStudentsInfo();
                }
                Console.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine("Felaktig inmatning! Du återgår nu till menyn \n" + e.Message);
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
        private static void RemoveStudent()
        {
            //Lista eleverna med hjälp av en loop ge sedan alternativet att ta bort från index i listan
            Console.Clear();
            int index = 1;
            Console.WriteLine("Här nedan listas eleverna i Norrlänningarna!");
            foreach (Members students in listOfNorr)
            {
                Console.WriteLine("{0}", index + "\t" + $"{students.Name}");
                index++;
            }
            Console.Write("Vill du ta bort någon medlem? Ange \"ja\", \nAnnars tryck valfri tangent för att återgå till menyn\n");
            string input = Console.ReadLine();

            if (input == "ja")
            {
                Console.WriteLine("Ange siffran som representerar eleven för att ta bort från klasslistan");
                int choice = Convert.ToInt32(Console.ReadLine());
                listOfNorr.RemoveAt(choice - 1);
            }
            Console.Clear();
        }
        private static void AddStudent()
        {
            Console.WriteLine("Vill du lägga någon medlem? Ange \"ja\", \nAnnars tryck valfri tangent för att återgå till menyn\n");
            string input = Console.ReadLine();
            if (input == "ja")
            {
                try
                {

                    Console.Write("Namn: ");
                    string name = Console.ReadLine();
                    Console.Write("Heigth: ");
                    int height = Convert.ToInt32(Console.ReadLine());
                    Console.Write("age: ");
                    int age = Convert.ToInt32(Console.ReadLine());
                    Console.Write("city: ");
                    string city = Console.ReadLine();
                    Console.Write("hobby: ");
                    string hobby = Console.ReadLine();
                    Console.Write("favourite food: ");
                    string food = Console.ReadLine();
                    Console.Write("favourite drink: ");
                    string drink = Console.ReadLine();
                    Console.Write("Music: ");
                    string music = Console.ReadLine();
                    Console.Write("Children: ");
                    int children = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Största driv: ");
                    string driv = Console.ReadLine();



                    listOfNorr.Add(new Members(name, height, age, city, hobby, food, drink, music, children, driv));
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"{name} Tillagd i listan");
                    Console.ResetColor();
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Felaktig inmatning" + e.Message);
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    Console.Clear();
                    AddStudent();

                }

            }
        }
        private static void MembersOfNorr()
        {
            Members tobias = new Members("Tobias Binett", 192, 31, "Hudiksvall", "Familjen", "Kött", "Öl", "The Black Dahlia Murders", 2, "Att kunna skapa något användbart för mig själv och and och att kunna arbeta med det.");
            Members fredrik = new Members("Fredrik Hoffman", 192, 28, "Östersund", "musik,socialisera,film,serier,automation och skriptning,programmering,testa nytt,äta ute,whiskykväll och öl", "Entrecote med rotfrukter och vitlökssmör", "Trocadero Zero, Ardbeg och Budvar", "Armin Van Buuren (annars progressive trance, house, trance, electronic, progressive house, rock, metal, heavy metal)", 0, "Möjlighet till karriärutveckling.");
            Members dennis = new Members("Dennis Lindquist", 182, 32, "Älvdalen", "Gitarr/musik", "Friterad kyckling", "öl", "Metallica", 1, "Att få skapa och kunna vara kreativ. Men även att få göra ett byte av karriär.");
            Members benny = new Members("Benny Christensen", 194, 38, "Brunflo", "Datorspel, Fiske, Programmering, Landsvägscykling", "Älgkebab", "Coca Cola", "Foo Fighters", 2, "Att kunna skapa något från grunden och lösa problem med det jag skapat. Att sedan kunna använda detta till att tjäna hutlösa summor pengar är ju i sig ytterligare en morot.");
            Members håkan = new Members("Håkan Eriksson", 187, 44, "Uppsala", " Moto-X, Sporthojar, Online gaming", "Shish kebab", "Loka Citron", "Disturbed", 0, "Social engineering, datasäkerhet, pentesting.");
            Members tina = new Members("Tina Eriksson", 165, 30, "Brunflo/Östersund", "Spela TV-spel", "Potatis & Purjolökssoppa", "Kaffe", "Avicii", 2, "Få ett bra jobb, som jag tycker om");
            Members emil = new Members("Emil Örjes", 184, 26, "Falun", "Snowboard, Gitarr, Musik, Hunden, Tv-spel", "Feta Hamburgare", "Öl", "System Of a Down", 0, "Att lära sig ett nytt yrke helt från grunden som känns givande.");
            Members mattias = new Members("Mattias Vikström", 187, 33, "Umeå", "Fiske,matlagning", "Cowboysoppa", "Gin och Tonic", "Infected Mushroom", 0, "Personlig utveckling och kreativitet");
            Members nicklas = new Members("Nicklas Eriksson", 175, 26, "Umeå", "Skidor, cykel, simma, springa, fjällvandring, klättring och dataspel", "Gröt med jornötssmör", "Whiskey", "Falling in Reverse och Self Deception", 0, "Drivet kommer från att man får vara kreativ och en problemlösare på samma gång. Sen så drivs man såklart av att få testa på en annan karriär än den man har haft tidigare");
            Members josefine = new Members("Josefine Rönnqvist", 164, 34, "Gideå", "Sy,pussla,umgås", "Frukt", "Vatten", "Halsbandet", 2, "Personlig utveckling och karriärbyte");
            listOfNorr.Add(tobias);
            listOfNorr.Add(fredrik);
            listOfNorr.Add(dennis);
            listOfNorr.Add(benny);
            listOfNorr.Add(håkan);
            listOfNorr.Add(tina);
            listOfNorr.Add(emil);
            listOfNorr.Add(mattias);
            listOfNorr.Add(nicklas);
            listOfNorr.Add(josefine);

        }

    }

}
