using System;
using System.IO;

namespace Budget_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const String sBudget_File = "budget.txt";
            int iMenuSelection;
            string sProceedOption;

            string sPerson1Name;
            string sPerson2Name;

            double dPerson1MonthlyIncome;
            double dPerson2MonthlyIncome;
            double dTotalMonthlyIncome;

            double dPerson1YearlySalary;
            double dPerson2YearlySalary;
            double dTotalYearlySalary;

            double dPerson1WagePercentage;
            double dPerson2WagePercentage;

            double dPerson1TotalToSpendPerWeek;
            double dPerson2TotalToSpendPerWeek;

            double dTotalRentPayment;
            double dRentPaymentForPerson1;
            double dRentPaymentForPerson2;

            double dTotalElectricPayment;
            double dElectricPaymentForPerson1;
            double dElectricPaymentForPerson2;

            double dTotalWaterPayment;
            double dWaterPaymentForPerson1;
            double dWaterPaymentForPerson2;

            double dPerson1MiscPayment;
            double dPerson2MiscPayment;
            double dTotalMiscPayment;

            double dTotalExpensesForPerson1WithoutMisc;
            double dTotalExpensesForPerson2WithoutMisc;
            double dTotalExpensesForPerson1;
            double dTotalExpensesForPerson2;
            double dTotalExpenses;
            double dTotalExpensesWithBothMisc;

            double dTotalAfterExpensesForPerson1;
            double dTotalAfterExpensesForPerson2;

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

                        Console.WriteLine("BY CREATING A NEW BUDGET, THIS WILL OVERWRITE THE EXISTING ONE ON FILE.");
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

                            Console.Write("Please enter the total income for " + sPerson1Name + " this month: £");
                            dPerson1MonthlyIncome = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.Write("Please enter the total income for " + sPerson2Name + " this month: £");
                            dPerson2MonthlyIncome = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();
                            Console.WriteLine();

                            dTotalMonthlyIncome = dPerson1MonthlyIncome + dPerson2MonthlyIncome;
                            dPerson1WagePercentage = dPerson1MonthlyIncome / dTotalMonthlyIncome;
                            dPerson2WagePercentage = dPerson2MonthlyIncome / dTotalMonthlyIncome;

                            dPerson1YearlySalary = dPerson1MonthlyIncome * 12;
                            dPerson2YearlySalary = dPerson2MonthlyIncome * 12;
                            dTotalYearlySalary = dPerson1YearlySalary + dPerson2YearlySalary;

                            Console.Write("Please enter the total rent payment for this month: £");
                            dTotalRentPayment = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.Write("Please enter the total electric payment for this month: £");
                            dTotalElectricPayment = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.Write("Please enter the total water payment for this month: £");
                            dTotalWaterPayment = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();
                            Console.WriteLine();

                            Console.Write("Please enter the total for misc fixed expenses for " + sPerson1Name + " this month: £");
                            dPerson1MiscPayment = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.Write("Please enter the total for misc fixed expenses for " + sPerson2Name + " this month: £");
                            dPerson2MiscPayment = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();
                            Console.WriteLine();

                            Console.WriteLine("Budget has been created.");

                            dTotalExpenses = dTotalRentPayment + dTotalElectricPayment + dTotalWaterPayment;
                            dTotalMiscPayment = dPerson1MiscPayment + dPerson2MiscPayment;
                            dTotalExpensesWithBothMisc = dTotalExpenses + dTotalMiscPayment;

                            dTotalExpensesForPerson1WithoutMisc = dPerson1WagePercentage * dTotalExpenses;
                            dTotalExpensesForPerson2WithoutMisc = dPerson2WagePercentage * dTotalExpenses;

                            dRentPaymentForPerson1 = dPerson1WagePercentage * dTotalRentPayment;
                            dRentPaymentForPerson2 = dPerson2WagePercentage * dTotalRentPayment;

                            dElectricPaymentForPerson1 = dPerson1WagePercentage * dTotalElectricPayment;
                            dElectricPaymentForPerson2 = dPerson2WagePercentage * dTotalElectricPayment;

                            dWaterPaymentForPerson1 = dPerson1WagePercentage * dTotalWaterPayment;
                            dWaterPaymentForPerson2 = dPerson2WagePercentage * dTotalWaterPayment;

                            dTotalExpensesForPerson1 = dTotalExpensesForPerson1WithoutMisc + dPerson1MiscPayment;
                            dTotalExpensesForPerson2 = dTotalExpensesForPerson2WithoutMisc + dPerson2MiscPayment;

                            dTotalAfterExpensesForPerson1 = dPerson1MonthlyIncome - dTotalExpensesForPerson1;
                            dTotalAfterExpensesForPerson2 = dPerson2MonthlyIncome - dTotalExpensesForPerson2;

                            dPerson1TotalToSpendPerWeek = dTotalAfterExpensesForPerson1 / 4;
                            dPerson2TotalToSpendPerWeek = dTotalAfterExpensesForPerson2 / 4;


                            using (StreamWriter sw = new StreamWriter(sBudget_File))
                            {
                                sw.WriteLine("                    Budget Calculation File ");
                                sw.WriteLine("_____________________________________________________________________");
                                sw.WriteLine();

                                sw.WriteLine("Monthly Income and Predicted Salary =");
                                sw.WriteLine();
                                sw.WriteLine(sPerson1Name + "'s monthly income is: " + dPerson1MonthlyIncome.ToString("C"));
                                sw.WriteLine(sPerson2Name + "'s monthly income is: " + dPerson2MonthlyIncome.ToString("C"));
                                sw.WriteLine("Your total monthly income is: " + dTotalMonthlyIncome.ToString("C"));
                                sw.WriteLine();

                                sw.WriteLine(sPerson1Name + "'s predicted yearly salary is: " + dPerson1YearlySalary.ToString("C"));
                                sw.WriteLine(sPerson2Name + "'s predicted yearly salary is: " + dPerson2YearlySalary.ToString("C"));
                                sw.WriteLine("Your total predicted salary is: " + dTotalYearlySalary.ToString("C"));
                                sw.WriteLine();
                                sw.WriteLine("_____________________________________________________________________");
                                
                                sw.WriteLine();
                                sw.WriteLine("Expenses =");
                                sw.WriteLine();
                                sw.WriteLine(sPerson1Name + "'s total expenses for this month is: " + dTotalExpensesForPerson1.ToString("C"));
                                sw.WriteLine("    Rent - " + dRentPaymentForPerson1.ToString("C"));
                                sw.WriteLine("    Electric - " + dElectricPaymentForPerson1.ToString("C"));
                                sw.WriteLine("    Water - " + dWaterPaymentForPerson1.ToString("C"));
                                sw.WriteLine("    Misc - " + dPerson1MiscPayment.ToString("C"));
                                sw.WriteLine();

                                sw.WriteLine(sPerson2Name + "'s total expenses for this month is: " + dTotalExpensesForPerson2.ToString("C"));
                                sw.WriteLine("    Rent - " + dRentPaymentForPerson2.ToString("C"));
                                sw.WriteLine("    Electric - " + dElectricPaymentForPerson2.ToString("C"));
                                sw.WriteLine("    Water - " + dWaterPaymentForPerson2.ToString("C"));
                                sw.WriteLine("    Misc - " + dPerson2MiscPayment.ToString("C"));
                                sw.WriteLine();

                                sw.WriteLine("Your total expenses for this month is: " + dTotalExpensesWithBothMisc.ToString("C"));
                                sw.WriteLine("    Rent - " + dTotalRentPayment.ToString("C"));
                                sw.WriteLine("    Electric - " + dTotalElectricPayment.ToString("C"));
                                sw.WriteLine("    Water - " + dTotalWaterPayment.ToString("C"));
                                sw.WriteLine("    Misc - " + dTotalMiscPayment.ToString("C"));
                                sw.WriteLine();
                                sw.WriteLine("_____________________________________________________________________");

                                sw.WriteLine();
                                sw.WriteLine("Left after fixed expenses =");
                                sw.WriteLine();
                                sw.WriteLine(sPerson1Name + "'s total left to spend this month is: " + dTotalAfterExpensesForPerson1.ToString("C"));
                                sw.WriteLine(sPerson1Name + "'s total left to spend per week this month is: " + dPerson1TotalToSpendPerWeek.ToString("C"));
                                sw.WriteLine();
                                sw.WriteLine(sPerson2Name + "'s total left to spend this month is: " + dTotalAfterExpensesForPerson2.ToString("C"));
                                sw.WriteLine(sPerson2Name + "'s total left to spend per week this month is: " + dPerson2TotalToSpendPerWeek.ToString("C"));
                            }
                        }

                    break;

                    case 2:
                        Console.Clear();

                        using (StreamReader sr = new StreamReader(sBudget_File))
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
            Console.WriteLine(" Budget Calculator ");
            Console.WriteLine("___________________");
            Console.WriteLine();
        }
        static void MainMenu()
        {
            Console.WriteLine("Would you like to create a new budget file or view the existing budget file?");
            Console.WriteLine();
            Console.WriteLine("1. Create new budget file");
            Console.WriteLine("2. View existing budget file");
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
