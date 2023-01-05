using System;
using System.IO;

namespace Savings_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const String sSavings_File = "savings.txt";
            int iMenuSelection;
            string sProceedOption;

            Title();
            MainMenu();
            Console.Write("Please enter option: ");
            iMenuSelection = Convert.ToInt32(Console.ReadLine());

            while (iMenuSelection > 3)
            {
                Console.WriteLine();
                Console.Write("Please re-enter your option: ");
                iMenuSelection = Convert.ToInt32(Console.ReadLine());
            }

            while (iMenuSelection != 3)
            {
                Console.Clear();

                switch (iMenuSelection)
                {
                    case 1:

                        Console.WriteLine("BY CREATING A NEW SAVINGS FILE, THIS WILL OVERWRITE THE EXISTING ONE ON FILE.");
                        Console.WriteLine();
                        Console.Write("Would you like to proceed? (Y/N): ");
                        sProceedOption = Console.ReadLine();

                        if (sProceedOption == "Y" || sProceedOption == "y")
                        {
                            Console.Clear();
                            Title();

                            using (StreamWriter sw = new StreamWriter(sSavings_File))
                            {

                            }
                        }

                    break;

                    case 2:
                        Console.Clear();

                        using (StreamReader sr = new StreamReader(sSavings_File))
                        {
                            while (sr.Peek() != -1)
                            {
                                Console.WriteLine(sr.ReadLine());
                            }
                        }
                    break;
                }

                ContinueOption();

                Title();
                MainMenu();
                Console.Write("Please enter option: ");
                iMenuSelection = Convert.ToInt32(Console.ReadLine());

                while (iMenuSelection > 3)
                {
                    Console.WriteLine();
                    Console.Write("Please re-enter your option: ");
                    iMenuSelection = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        static void Title()
        {
            Console.WriteLine(" Savings Calculator ");
            Console.WriteLine("___________________");
            Console.WriteLine();
        }
        static void MainMenu()
        {
            Console.WriteLine("1. Create new savings file");
            Console.WriteLine("2. View existing savings file");
            Console.WriteLine("3. Exit program");
            Console.WriteLine();
        }
        static void ContinueOption()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
