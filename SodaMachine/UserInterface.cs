using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    static class UserInterface
    {
        public static int InputVerificationNumbers(int min, int max, string prompt)
        {
            int input;
            Console.Write(prompt);
            do
            {
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    if (input >= min && input <= max)
                        return (input);
                    Console.WriteLine("You entered " + input + ", but your choices are (" + min + " - " + max + ". Please try again...");
                }
                else
                    Console.WriteLine("That is not a real number. Please try again...");
            } while (true);
        }
        public static void DisplayText(string text)
        {
            Console.WriteLine(text);
        }
        public static int SodaChoice(SodaMachine sodaMachine)
        {
            Console.WriteLine("\nYou put in $" + CustomerInputMoney(sodaMachine)+"\n");

            Console.WriteLine(" 1 Cola");
            Console.WriteLine(" 2 Root Beer");
            Console.WriteLine(" 3 Orange Soda");
            return InputVerificationNumbers(1, 3, "Please select your drink: ");
        }
        public static void CoinInput()
        {
            Console.WriteLine("Please enter the number of coins you want put in the Soda Machine");
        }
        public static void Menu(double cola, double rootBeer, double OrangeSoda)
        {
            Console.WriteLine(" Cola        $" + cola);
            Console.WriteLine(" Root Beer   $" + rootBeer);
            Console.WriteLine(" Orange Soda $" + OrangeSoda);
        }

        public static void CoinsInWallet(int quarter, int dime, int nickel, int penny)
        {
            Console.WriteLine(" The current money in your wallet is:");
            Console.WriteLine(" Quarters: " + quarter);
            Console.WriteLine(" Dimes: " + dime);
            Console.WriteLine(" Nickels: " + nickel);
            Console.WriteLine(" Pennies: " + penny);
            Console.WriteLine(" Total Amount: $" + quarter * 25 + dime * 10 + nickel * .05 + penny*.01);
        }

        public static void InventoryDisplay(int cola, int rootBeer, int orangeSoda, int quarter, int dime, int nickel, int penny, string title, SodaMachine sodaMachine)
        {
            double total = quarter * sodaMachine.quarter.Value + dime * sodaMachine.dime.Value + nickel * sodaMachine.nickel.Value + penny * sodaMachine.penny.Value;
            Console.WriteLine(title + ":");
            Console.WriteLine(" Soda's             Coins");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(" Cola " + cola + "             Quarters: " + quarter);
            Console.WriteLine(" Root Beer " + rootBeer + "        Dimes: " + dime);
            Console.WriteLine(" Orange Soda " + orangeSoda + "      Nickels: " + nickel);
            Console.WriteLine("                    Penny: " + penny);
            Console.WriteLine("                    Total Amount: $" + total + "\n");

        }
        public static void ShowSodaMachineInventory(SodaMachine sodaMachine)
        {
            int cola = 0, rootBeer = 0, orangeSoda = 0, quarter = 0, dime = 0, nickel = 0, penny = 0;
            string title = "The Soda Machine inventory";
            foreach (Can can in sodaMachine.inventory)
            {
                if (can.name.Contains("Cola")) { cola++; }
                else if (can.name.Contains("Root Beer")) { rootBeer++; }
                else if (can.name.Contains("Orange Soda")) { orangeSoda++; }
            }
            foreach (Coin coin in sodaMachine.register)
            {
                if (coin.name.Contains("Quarter")) { quarter++; }
                else if (coin.name.Contains("Dime")) { dime++; }
                else if (coin.name.Contains("Nickel")) { nickel++; }
                else if (coin.name.Contains("Penny")) { penny++; }
            }
           
            InventoryDisplay(cola, rootBeer, orangeSoda, quarter, dime, nickel, penny, title);
        }
        public static void Menu(SodaMachine sodaMachine)
        {
            Console.WriteLine("\n   ************************");
            Console.WriteLine("   *  Cola        $" + sodaMachine.cola.Cost);
            Console.WriteLine("   *  Root Beer   $" + sodaMachine.rootBeer.Cost);
            Console.WriteLine("   *  Orange Soda $" + sodaMachine.orangeSoda.Cost);
            Console.WriteLine("   ************************");
        }
        public static void ShowCustomersStuff(Customer customer)
        {
            int cola = 0, rootBeer = 0, orangeSoda = 0, quarter = 0, dime = 0, nickel = 0, penny = 0;
            string title = "\nCustomer Inventory";
            foreach (Can can in customer.backpack.cans)
            {
                if (can.name.Contains("Cola")) { cola++; }
                else if (can.name.Contains("Root Beer")) { rootBeer++; }
                else if (can.name.Contains("Orange Soda")) { orangeSoda++; }
            }
            foreach (Coin coin in customer.wallet.coins)
            {
                if (coin.name.Contains("Quarter")) { quarter++; }
                else if (coin.name.Contains("Dime")) { dime++; }
                else if (coin.name.Contains("Nickel")) { nickel++; }
                else if (coin.name.Contains("Penny")) { penny++; }
            }
            InventoryDisplay(cola, rootBeer, orangeSoda, quarter, dime, nickel, penny, title);
        }
        public static double CustomerInputMoney(SodaMachine sodaMachine)
        {
            double payment = 0;
            foreach (Coin coin in sodaMachine.payment)
            {
                if (coin.name.Contains("Quarter")) { payment+=.25; }
                else if (coin.name.Contains("Dime")) { payment += .10; }
                else if (coin.name.Contains("Nickel")) { payment += .05; }
                else if (coin.name.Contains("Penny")) { payment += .01; }
            }
           return payment;
        }

    }
}
