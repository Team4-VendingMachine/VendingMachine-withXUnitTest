﻿using VendingMachineProject.Models;

namespace VendingMachineProject.Services
{
    public class VendingMachine : IVending
    {
        //----------- Vending Machine atributes initialization --------//
        private List<Product> inventory = new List<Product>();
        private double moneyPool = 0;
        private double[] denominations = new double[] { 1, 5, 10, 20, 50, 100, 500, 1000 };

        //----------- Adding items in Inventory List --------//
        public VendingMachine()
        {
            AddProduct(new PlayStation5Game(1, "FIFA 24", 699, "Experience the thrill of soccer with FIFA 24.", "Family", 5));
            AddProduct(new PlayStation5Game(2, "Spider-Man: Miles Morales", 799, "Swing through New York as Spider-Man in this exciting adventure.", "Action", 3));
            AddProduct(new PlayStation5Game(3, "Demon's Souls", 899, "Face the challenges of Demon's Souls and emerge victorious.", "Horror", 2));

            AddProduct(new PlayStation4Game(4, "The Last of Us Part III", 399, "Action-adventure game", "Action", 12));
            AddProduct(new PlayStation4Game(5, "God of War", 349, "Action-adventure game", "Action", 7));
            AddProduct(new PlayStation4Game(6, "Uncharted 4: A Thief's End", 299, "Action-adventure game", "Action", 9));

            AddProduct(new NintendoSwitchGame(7, "The Legend of Zelda: Breath of the Wild", 499, "Action-adventure game", "Action", 20));
            AddProduct(new NintendoSwitchGame(8, "Animal Crossing: New Horizons", 399, "Life simulation game", "Family", 18));
            AddProduct(new NintendoSwitchGame(9, "Super Mario Odyssey", 449, "Platform game", "Family", 25));
        }

        //----------- Function for Adding items in Inventory --------//
        public void AddProduct(Product item)
        {
            inventory.Add(item);
        }

        //----------- Function for Displaying Available item --------//
        public void displayMenu()
        {
            Console.WriteLine("\nVending Machine Menu: ");
            foreach (var item in inventory)
            {
                Console.WriteLine($"{item.Id}. {item.Name} - {item.Cost}kr");
            }
        }
        //----------- private input reader for reciving options --------//
        //private readonly inputReader reciveOption;

        //----------- Function for reciving item code to sell item --------//
        public void selectItem()
        {
            displayMenu();
            Console.WriteLine("\nEnter Item ID you want to purchase: ");

            //---------- Taking input from user -----------//
            //string input = reciveOption.readLine();
            string input = Console.ReadLine();
            //--------------------- Checking if input is other than number ------------//
            while (!(input.All(Char.IsDigit)) || input == "")
                {
                    Console.WriteLine("kindly Choose any number from 1 to 9!\n");
                    input = Console.ReadLine();
                }
            // --------- Check End ----------//
            int itemId = Convert.ToInt32(input);
            var item = inventory.FirstOrDefault(p => p.Id == itemId);
            //----------- check for item Availability --------//
            if (item != null)
            {
                //----------- Check for required price and balance --------//
                double itemPrice = item.Cost;
                if (moneyPool >= itemPrice)
                {
                    moneyPool -= itemPrice;
                    Console.WriteLine($"\nEnjoy your {item.Name} for {itemPrice}kr. \nRemaining Balance is {moneyPool}kr.");
                    Console.WriteLine(item.Use());
                }
                else
                {
                    Console.WriteLine("\nInsufficient Balance! Please add more money.");
                }
                //----------- price Checking closed --------//
            }
            else
            {
                Console.WriteLine("\nProduct not found. please try again!");
            }
            //----------- Item availibility Checking closed --------//
        }

        //----------- Function reciving money for money pool --------//

        public void insertMoney()
        {
            Console.WriteLine("\nPlease insert money: ");
            //---------- Taking input from user -----------//
            string takemoney = Console.ReadLine();
            //--------------------- Checking if input is other than number ------------//
            while (!(takemoney.All(Char.IsDigit)) || takemoney == "")
            {
                Console.WriteLine("kindly Insert money in denomination of 1kr, 5kr, 10kr, 20kr, 50kr, 100kr, 500kr, 1000kr. ");
                takemoney = Console.ReadLine();
            }
            // --------- Check End ----------//
            double insertedMoney = Convert.ToDouble(takemoney);
            //--------------------- Checking if denomination has amount ------------//
            if (denominations.Contains(insertedMoney))
            {
                moneyPool += insertedMoney;
                Console.WriteLine($"\nYou have inserted {insertedMoney}kr. Total Balance available: {moneyPool}kr.");
            }
            else
            {
                Console.WriteLine("\nInvalid denomination. please try again! \nInsert money in denomination of 1kr, 5kr, 10kr, 20kr, 50kr, 100kr, 500kr, 1000kr. ");
            }
            //--------------------- Closed Check for denomination  ------------//
        }

        //--------------------- Closing machine while Returning Change ------------//

        public double returnChange()
        {
            double remainingMoney = moneyPool;
            if (moneyPool > 0)
            {
                Console.WriteLine($"\nHere is your remaining change: {moneyPool}kr.\nThanks for Buying !..");
                moneyPool = 0;
            }
            else
            {
                Console.WriteLine("\nThanks for Buying !..");
            }

            return remainingMoney;
        }
        //--------------------- Displaying amount of Money in pool ------------//

        public void checkBalance()
        {
            Console.WriteLine($"\nYou have {moneyPool}kr in moneyPool.");
        }

        //--------------------- Starting Machine ------------//
        public void StartMachine()
        {
            bool started = true;
            while (started)
            {
                Console.WriteLine("\nChoose an option: \n1. Insert Money\n2. Select item\n3. Check Balance in moneyPool\n4. Return change and Exit\n");
                //---------- Taking input from user -----------//
                string takeoption = Console.ReadLine();
                //--------------------- Checking if input is other than number ------------//
                while (!(takeoption.All(Char.IsDigit)) || takeoption == "")
                {
                    Console.WriteLine("kindly Choose any number from 1 to 4!\n");
                    takeoption = Console.ReadLine();
                }
                // ------- Check end ------//
                int option = Convert.ToInt32(takeoption);
                //----------- Switch start ----------//
                switch (option)
                {
                    case 1:
                        insertMoney();
                        break;
                    case 2:
                        selectItem();
                        break;
                    case 3:
                        checkBalance();
                        break;
                    case 4:
                        returnChange();
                        started = false;
                        break;
                    default:
                        Console.WriteLine("\nInvalid Selection. Please try again!");
                        break;
                }
                //------ Switch closed -------------//
            }
            //---------- while loop closed ----------//
        }
        // ---------- start machine function closed -----------//
    }
}
