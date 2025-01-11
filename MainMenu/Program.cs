using System;

namespace MainMenu
{
    public class Program
    {
        public static void Main()
        {
            displayMenu();
        }

        private static void displayMenu()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Program Menu!");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1 - Binary statistics analyzer");
                Console.WriteLine("2 - ABC tree with height of 7 floors");
                Console.WriteLine("3 - ABC tree with your choice of height");
                Console.WriteLine("4 - String analyzer");
                Console.WriteLine("5 - Numbers statistics");
                Console.WriteLine("0 - Exit");
                Console.Write("Your choice: ");

                string userInput = Console.ReadLine();
                eUserChoice userChoice = parseUserChoice(userInput);

                switch (userChoice)
                {
                    case eUserChoice.Program1:
                        Console.WriteLine("You selected binary statistics analyzer.");
                        ProgramManager.RunProgram1();
                        break;

                    case eUserChoice.Program2:
                        Console.WriteLine("You selected ABC tree with height of 7 floors.");
                        ProgramManager.RunProgram2();
                        break;

                    case eUserChoice.Program3:
                        Console.WriteLine("You selected ABC tree with your choice of height.");
                        ProgramManager.RunProgram3();
                        break;

                    case eUserChoice.Program4:
                        Console.WriteLine("You selected string analyzer.");
                        ProgramManager.RunProgram4();
                        break;

                    case eUserChoice.Program5:
                        Console.WriteLine("You selected numbers statistics.");
                        ProgramManager.RunProgram5();
                        break;

                    case eUserChoice.Exit:
                        Console.WriteLine("Exiting the menu. Goodbye!");
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (isRunning)
                {
                    Console.WriteLine($"{Environment.NewLine}Press any key to return to the menu...");
                    Console.ReadKey();
                }
            }
        }

        private static eUserChoice parseUserChoice(string i_UserInput)
        {
            eUserChoice userChoice = eUserChoice.Invalid;

            if (int.TryParse(i_UserInput, out int numericChoice) && numericChoice >= 0 && numericChoice <= 5)
            {
                userChoice = (eUserChoice)numericChoice;
            }

            return userChoice;
        }
    }
}