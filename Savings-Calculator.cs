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

            string sPerson1Name;
            string sPerson2Name;

            double dPerson1SavingsLeft;
            double dPerson2SavingsLeft;

            double dPerson1PercentageIntoCombinedSavings;
            double dPerson2PercentageIntoCombinedSavings;

            double dTurnPerson1PercentageIntoDecimal;
            double dTurnPerson2PercentageIntoDecimal;

            double dTotalAmountIntoCombinedSavingsForPerson1;
            double dTotalAmountIntoCombinedSavingsForPerson2;

            double dTotalAmountLeftForPerson1;
            double dTotalAmountLeftForPerson2;

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

                            Console.Write("Please enter the name for person 1: ");
                            sPerson1Name = Console.ReadLine();
                            Console.WriteLine();

                            Console.Write("Please enter the name for person 2: ");
                            sPerson2Name = Console.ReadLine();
                            Console.WriteLine();

                            ContinueOption();
                            Title();

                            Console.Write("Please enter the total amount that " + sPerson1Name + " has left to put into savings: £");
                            dPerson1SavingsLeft = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.Write("Please enter the total amount that " + sPerson2Name + " has left to put into savings: £");
                            dPerson2SavingsLeft = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();
                            Console.WriteLine();

                            Console.Write("Please enter the percentage that " + sPerson1Name + " would like to put away into combined savings: ");
                            dPerson1PercentageIntoCombinedSavings = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.Write("Please enter the percentage that " + sPerson2Name + " would like to put away into combined savings: ");
                            dPerson2PercentageIntoCombinedSavings = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();
                            Console.WriteLine();

                            dTurnPerson1PercentageIntoDecimal = dPerson1PercentageIntoCombinedSavings / 100;
                            dTurnPerson2PercentageIntoDecimal = dPerson2PercentageIntoCombinedSavings / 100;

                            dTotalAmountIntoCombinedSavingsForPerson1 = dPerson1SavingsLeft * dTurnPerson1PercentageIntoDecimal;
                            dTotalAmountIntoCombinedSavingsForPerson2 = dPerson2SavingsLeft * dTurnPerson2PercentageIntoDecimal;

                            dTotalAmountLeftForPerson1 = dPerson1SavingsLeft - dTotalAmountIntoCombinedSavingsForPerson1;
                            dTotalAmountLeftForPerson2 = dPerson2SavingsLeft - dTotalAmountIntoCombinedSavingsForPerson2;

                            Console.WriteLine("Savings has been calculated.");

                            using (StreamWriter sw = new StreamWriter(sSavings_File))
                            {
                                sw.WriteLine("                    Savings Calculation File ");
                                sw.WriteLine("_____________________________________________________________________");
                                sw.WriteLine();

                                sw.WriteLine(sPerson1Name + " has " + dPerson1SavingsLeft.ToString("C") + " left to save in total");
                                sw.WriteLine(sPerson2Name + " has " + dPerson2SavingsLeft.ToString("C") + " left to save in total");
                                sw.WriteLine();

                                sw.WriteLine(dTotalAmountIntoCombinedSavingsForPerson1.ToString("C") + " is to be put into combined savings from " + sPerson1Name);
                                sw.WriteLine(dTotalAmountIntoCombinedSavingsForPerson2.ToString("C") + " is to be put into combined savings from " + sPerson2Name);
                                sw.WriteLine();

                                sw.WriteLine(sPerson1Name + " will have " + dTotalAmountLeftForPerson1.ToString("C") + " left to put into personal savings");
                                sw.WriteLine(sPerson2Name + " will have " + dTotalAmountLeftForPerson2.ToString("C") + " left to put into personal savings");
                                sw.WriteLine();
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
            Console.WriteLine("Would you like to create a new savings file or view the existing savings file?");
            Console.WriteLine();
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
