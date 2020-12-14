using System;
using System.ComponentModel.Design;
using System.Threading;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {           
            Menu();
        }
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

        private static void AddStudent()
        {
            
        }
        private static void RemoveStudent()
        {
            
        }
        private static void ShowStudentsInfo()
        {
           
        }
        private static void ShowStudentsName()
        {
           
        }
    }
    
}
