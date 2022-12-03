using System;
using System.IO;

namespace Drinks_Shopping_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declare Variables
            String Name;
            const String sShopping_File = "shopping_list.txt";
            int iShoppingListOption;
            int iOption;
            String NameOfItem;
            double PriceOfNormalItem;
            String ShopOfNormalItem;
            double PriceOfItemFromAgrimark;
            String AddOnlyAgrimarkItem;
            String ProductInTesco;
            double PriceOfItemFromTesco;
            String AddToShoppingList;
            String AddPriceToItem;

            Console.Write("Would you like to create a new shopping list or add to the existing shopping list?");
            Console.WriteLine();
            Console.WriteLine("1. Create new shopping list");
            Console.WriteLine("2. Add to existing shopping list");
            Console.WriteLine();
            Console.Write("Enter option (1 or 2): ");
            iShoppingListOption = Convert.ToInt32(Console.ReadLine());

            // Validate user input
            while (iShoppingListOption > 2)
            {
                Console.WriteLine();
                Console.Write("Please re-enter your option: ");
                iShoppingListOption = Convert.ToInt32(Console.ReadLine());
            }

            if (iShoppingListOption == 1)
            {
                Console.Clear();
                // Ask user for name to personalise shopping list
                Console.Write("Please enter your name: ");
                Name = Console.ReadLine();

                // Create shopping list file with title
                using (StreamWriter sw = new StreamWriter(sShopping_File))
                {
                    sw.WriteLine("  Shopping List for " + Name);
                    sw.WriteLine("_______________________________");
                    sw.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine("New shopping list has been created for " + Name);
                Console.WriteLine();
                Console.WriteLine("Click enter to continue.");
                Console.ReadKey();
            }
                
            // Clear console and display menu
            Console.Clear();
            MainMenu();

            // Ask user for option choice
            Console.WriteLine();
            Console.Write("Enter option (1-4): ");
            iOption = Convert.ToInt32(Console.ReadLine());

            // Validate user input
            while (iOption < 1 || iOption > 4)
            {
                Console.Write("Please re-enter option from menu: ");
                iOption = Convert.ToInt32(Console.ReadLine());
            }

            while (iOption != 4)
            {
                Console.Clear();

                switch (iOption)
                {
                    case 1:
                        Console.Write("Please enter the name of the item: ");
                        NameOfItem = Console.ReadLine();
                        Console.WriteLine();

                        Console.Write("How much is " + NameOfItem + " from Agrimark?: ");
                        PriceOfItemFromAgrimark = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine();

                        Console.Write("Is the product available in Tesco? (Y/N): ");
                        ProductInTesco = Console.ReadLine();
                        Console.WriteLine();

                        if (ProductInTesco == "Y")
                        {
                            Console.Write("How much is " + NameOfItem + " from Tesco?: ");
                            PriceOfItemFromTesco = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.Write("Would you like to add the cheapest item to shopping list? (Y/N): ");
                            AddToShoppingList = Console.ReadLine();
                            Console.WriteLine();

                            if (AddToShoppingList == "Y")
                            {
                                if (PriceOfItemFromAgrimark > PriceOfItemFromTesco)
                                {
                                    using (StreamWriter sw = new StreamWriter(sShopping_File, true))
                                    {
                                        sw.WriteLine(" - " + NameOfItem + " from Tesco = " + PriceOfItemFromTesco.ToString("C"));
                                    }
                                }
                                else
                                {
                                    using (StreamWriter sw = new StreamWriter(sShopping_File, true))
                                    {
                                        sw.WriteLine(" - " + NameOfItem + " from Agrimark = " + PriceOfItemFromAgrimark.ToString("C"));
                                    }
                                }

                                Console.WriteLine();
                                Console.WriteLine("Product has been added to shopping list.");
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Product has not been added.");
                            }
                        }
                        else
                        {
                            Console.Write("Would you like to add the item from Agrimark to the shopping list? (Y/N): ");
                            AddOnlyAgrimarkItem = Console.ReadLine();
                            Console.WriteLine();

                            if (AddOnlyAgrimarkItem == "Y")
                            {
                                using (StreamWriter sw = new StreamWriter(sShopping_File, true))
                                {
                                    sw.WriteLine(" - " + NameOfItem + " from Agrimark = " + PriceOfItemFromAgrimark.ToString("C"));
                                }

                                Console.WriteLine();
                                Console.WriteLine("Product has been added to shopping list.");
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Product has not been added.");
                            }
                        }

                        break;

                    case 2:
                        Console.Write("Please enter the name of the item: ");
                        NameOfItem = Console.ReadLine();
                        Console.WriteLine();

                        Console.Write("Please enter what shop the item is from: ");
                        ShopOfNormalItem = Console.ReadLine();
                        Console.WriteLine();

                        Console.Write("Would you like to add the price of the item to shopping list? (Y/N): ");
                        AddPriceToItem = Console.ReadLine();
                        Console.WriteLine();

                        if (AddPriceToItem == "Y")
                        {
                            Console.Write("Please enter price of item: ");
                            PriceOfNormalItem = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            using (StreamWriter sw = new StreamWriter(sShopping_File, true))
                            {
                                sw.WriteLine(" - " + NameOfItem + " from " + ShopOfNormalItem + " = " + PriceOfNormalItem.ToString("C"));
                            }
                        }
                        else
                        {
                            using (StreamWriter sw = new StreamWriter(sShopping_File, true))
                            {
                                sw.WriteLine(" - " + NameOfItem + " from " + ShopOfNormalItem);
                            }
                        }

                        Console.WriteLine();
                        Console.WriteLine("Product has been added to shopping list.");

                        break;

                    case 3:
                        using (StreamReader sr = new StreamReader(sShopping_File))
                        {
                            while (sr.Peek() != -1)
                            {
                                Console.WriteLine(sr.ReadLine());
                            }
                        }

                        break;
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                Console.Clear();

                // Clear console and display menu
                Console.Clear();
                MainMenu();

                // Ask user for option choice
                Console.WriteLine();
                Console.Write("Enter option (1-4): ");
                iOption = Convert.ToInt32(Console.ReadLine());

                // Validate user input
                while (iOption < 1 || iOption > 4)
                {
                    Console.Write("Please re-enter option from menu: ");
                    iOption = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        static void MainMenu()
        {
            Console.WriteLine("Compare items and create your own shopping list!");
            Console.WriteLine("________________________________________________");
            Console.WriteLine();
            Console.WriteLine("1. Compare items");
            Console.WriteLine("2. Add item to Shopping List");
            Console.WriteLine("3. View Shopping list");
            Console.WriteLine("4. Exit Program");
        }
    }
}
