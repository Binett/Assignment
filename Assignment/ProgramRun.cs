using System;
using System.Collections.Generic;
using System.Threading;

namespace Assignment
{
    class ProgramRun
    {
        //|---------------------------------------------------------------------------------------------------------------------------------------|
        //|-----------------------------------------------> Listan med samtliga medlemmar <-------------------------------------------------------|
        //|---------------------------------------------------------------------------------------------------------------------------------------|


        private List<Members> listOfNorr = new List<Members>();

        public void Run()
        {
            MembersOfNorr();
            Menu();
        }


        //|---------------------------------------------------------------------------------------------------------------------------------------|
        //|----------------------------------> Meny med switch case som kallar på de olika metoderna nedan <--------------------------------------|
        //|---------------------------------------------------------------------------------------------------------------------------------------|


        private void Menu()
        {

            Login();
            do
            {
                Console.Title = "Norrlänningarna";
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Välkommen till Basgrupp Norrlänningarna!\n");
                Console.WriteLine("1.\t Visa elever");
                Console.WriteLine("2.\t Visa info om elever");
                Console.WriteLine("3.\t Ta bort elev");
                Console.WriteLine("4.\t Lägg till en elev");
                Console.WriteLine("5.\t Avsluta");
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
                Console.ResetColor();
            } while (true);
        }

        //|---------------------------------------------------------------------------------------------------------------------------------------|
        //|-----------------------------------------------------------> Login <-------------------------------------------------------------------|
        //|---------------------------------------------------------------------------------------------------------------------------------------|

        private void Login()
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
                    Console.WriteLine();
                    Console.WriteLine("Korrekt Lösen! Välkommen till Norrlänningarna");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    checkPass = false;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine();
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
                    Console.WriteLine();
                    Console.WriteLine("Du har matat in fel lösenord 3 gånger, vänta en stund och försök igen");
                    Thread.Sleep(4000);
                    Environment.Exit(0);
                }

            } while (checkPass);
        }

        //|---------------------------------------------------------------------------------------------------------------------------------------|
        //|--------------------------------> Används för att visa studenternas namn på vilka som går kursen <-------------------------------------|
        //|---------------------------------------------------------------------------------------------------------------------------------------|


        private void ShowStudentsName()
        {
            //Lista samtliga namn
            Console.Clear();
            foreach (Members students in listOfNorr)
            {
                Console.Write($" {students.Name},");
            }
            Console.WriteLine();
            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn");
            Console.ReadKey();
            Console.Clear();
        }


        //|---------------------------------------------------------------------------------------------------------------------------------------|
        //|--------------------------------------------> Ytterliggare information om studenterna <------------------------------------------------|
        //|---------------------------------------------------------------------------------------------------------------------------------------|


        private void ShowStudentsInfo()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Clear();
                Console.WriteLine("Information om elever i Norrlänningarna! Tryck på siffran som motsvarar eleven för mer information\n");

                int index = 1;
                foreach (Members students in listOfNorr)
                {
                    Console.WriteLine($"{index}\t{students.Name}");
                    index++;
                }
                Console.WriteLine();
                Console.WriteLine("Vill du ha mer info om någon student tryck siffran som representerar dem.");
                int input = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < listOfNorr.Count; i++)
                {
                    if (input - 1 == i)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(listOfNorr[i]);
                        Console.ResetColor();
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

        //|---------------------------------------------------------------------------------------------------------------------------------------|
        //|-----------------------------------------> Tar bort personer från listan av studenter <------------------------------------------------|
        //|---------------------------------------------------------------------------------------------------------------------------------------|

        private void RemoveStudent()
        {
            //Lista eleverna med hjälp av en loop ge sedan alternativet att ta bort från index i listan
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            int index = 1;
            Console.WriteLine("Här nedan listas eleverna i Norrlänningarna!");
            foreach (Members students in listOfNorr)
            {
                Console.WriteLine($"{index}\t{students.Name}");
                index++;
            }
            Console.Write("Vill du ta bort någon medlem? Ange \"ja\", \nAnnars tryck valfri tangent för att återgå till menyn\n");
            string input = Console.ReadLine();

            try
            {
                if (input == "ja")
                {
                    Console.WriteLine("Ange siffran som representerar eleven för att ta bort från klasslistan");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    listOfNorr.RemoveAt(choice - 1);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Personen borttagen!");
                    Thread.Sleep(3000);
                    Console.ResetColor();
                    RemoveStudent();
                }
            }
            catch (Exception e)
            {                
                Console.WriteLine("Felaktig inmatning " +e.Message);
                Thread.Sleep(3000);
            }
            Console.Clear();
        }

        //|---------------------------------------------------------------------------------------------------------------------------------------|
        //|--------------------------------------> Lägger till personer från listan av studenter <------------------------------------------------|
        //|---------------------------------------------------------------------------------------------------------------------------------------|

        private void AddStudent()
        {
            Console.WriteLine("Vill du lägga någon medlem? Ange \"ja\", \nAnnars tryck valfri tangent för att återgå till menyn\n");
            string input = Console.ReadLine();
            if (input.ToLower() == "ja")
            {
                try
                {
                    Console.Write("Namn: ");
                    string name = Console.ReadLine();
                    Console.Write("Heigth: ");
                    int height = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Age: ");
                    int age = Convert.ToInt32(Console.ReadLine());
                    Console.Write("City: ");
                    string city = Console.ReadLine();
                    Console.Write("Hobby: ");
                    string hobby = Console.ReadLine();
                    Console.Write("Favourite food: ");
                    string food = Console.ReadLine();
                    Console.Write("Favourite drink: ");
                    string drink = Console.ReadLine();
                    Console.Write("Music: ");
                    string music = Console.ReadLine();
                    Console.Write("Children: ");
                    int children = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Största driv: ");
                    string driv = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine($"Du angav\n{name}\n{height}\n{age}\n{city}\n{hobby}\n{food}\n{drink}\n{music}\n{children}\n{driv}\n");
                    Console.WriteLine("Om du vill lägga till i listan ange \"ja\" Annars tryck Enter för att ångra");
                    string askToAdd = Console.ReadLine();

                    if (askToAdd.ToLower() == "ja")
                    {
                        listOfNorr.Add(new Members(name, height, age, city, hobby, food, drink, music, children, driv));
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"{name} Tillagd i listan");
                        Console.ResetColor();
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Felaktig inmatning" + e.Message);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Thread.Sleep(2000);
                    Console.Clear();
                    AddStudent();
                }

            }
            Console.Clear();
        }

        //|---------------------------------------------------------------------------------------------------------------------------------------|
        //|-------------------------> Har skapar jag objekten av klassen memember och lägger till dessa i listan <--------------------------------|
        //|---------------------------------------------------------------------------------------------------------------------------------------|

        private void MembersOfNorr()
        {
            listOfNorr.Add(new Members("Tobias Binett", 192, 31, "Hudiksvall", "Träning, Musik, Spel, Familjen", "Kött", "Öl", "The Black Dahlia Murders", 2, "Att kunna skapa något användbart för mig själv och and och att kunna arbeta med det."));
            listOfNorr.Add(new Members("Fredrik Hoffman", 192, 28, "Östersund", "musik,socialisera,film,serier,automation och skriptning,programmering,testa nytt,äta ute,whiskykväll och öl", "Entrecote med rotfrukter och vitlökssmör", "Trocadero Zero, Ardbeg och Budvar", "Armin Van Buuren (annars progressive trance, house, trance, electronic, progressive house, rock, metal, heavy metal)", 0, "Möjlighet till karriärutveckling."));
            listOfNorr.Add(new Members("Dennis Lindquist", 182, 32, "Älvdalen", "Gitarr/musik", "Friterad kyckling", "öl", "Metallica", 1, "Att få skapa och kunna vara kreativ. Men även att få göra ett byte av karriär."));
            listOfNorr.Add(new Members("Benny Christensen", 194, 38, "Brunflo", "Datorspel, Fiske, Programmering, Landsvägscykling", "Älgkebab", "Coca Cola", "Foo Fighters", 2, "Att kunna skapa något från grunden och lösa problem med det jag skapat. Att sedan kunna använda detta till att tjäna hutlösa summor pengar är ju i sig ytterligare en morot."));
            listOfNorr.Add(new Members("Håkan Eriksson", 187, 44, "Uppsala", " Moto-X, Sporthojar, Online gaming", "Shish kebab", "Loka Citron", "Disturbed", 0, "Social engineering, datasäkerhet, pentesting."));
            listOfNorr.Add(new Members("Tina Eriksson", 165, 30, "Brunflo/Östersund", "Spela TV-spel", "Potatis & Purjolökssoppa", "Kaffe", "Avicii", 2, "Få ett bra jobb, som jag tycker om"));
            listOfNorr.Add(new Members("Emil Örjes", 184, 26, "Falun", "Snowboard, Gitarr, Musik, Hunden, Tv-spel", "Feta Hamburgare", "Öl", "System Of a Down", 0, "Att lära sig ett nytt yrke helt från grunden som känns givande."));
            listOfNorr.Add(new Members("Mattias Vikström", 187, 33, "Umeå", "Fiske,matlagning", "Cowboysoppa", "Gin och Tonic", "Infected Mushroom", 0, "Personlig utveckling och kreativitet"));
            listOfNorr.Add(new Members("Nicklas Eriksson", 175, 26, "Umeå", "Skidor, cykel, simma, springa, fjällvandring, klättring och dataspel", "Gröt med jornötssmör", "Whiskey", "Falling in Reverse och Self Deception", 0, "Drivet kommer från att man får vara kreativ och en problemlösare på samma gång. Sen så drivs man såklart av att få testa på en annan karriär än den man har haft tidigare"));
            listOfNorr.Add(new Members("Josefine Rönnqvist", 164, 34, "Gideå", "Sy,pussla,umgås", "Frukt", "Vatten", "Halsbandet", 2, "Personlig utveckling och karriärbyte"));
        }


    }
}
