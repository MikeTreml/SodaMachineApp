using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    static class UserInterface
    {
        static Quarter quater = new Quarter();
        static Dime dime = new Dime();
        static Nickel nickel = new Nickel();
        static Penny penny = new Penny();
        
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
        public static int SodaChoice(double moneyInput)
        {
            Console.WriteLine("\nYou put in $" + moneyInput + "\n");

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

        public static void InventoryDisplay(int[] sodaQty, int[] coinQty, string title)
        {
            double total = coinQty[0] * quater.Value + coinQty[1] * dime.Value + coinQty[2] * dime.Value + coinQty[3] * penny.Value;
            Console.WriteLine(title + ":");
            Console.WriteLine(" Soda's             Coins");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(" Cola " + sodaQty[0] + "             Quarters: " + coinQty[0]);
            Console.WriteLine(" Root Beer " + sodaQty[1] + "        Dimes: " + coinQty[1]);
            Console.WriteLine(" Orange Soda " + sodaQty[2] + "      Nickels: " + coinQty[2]);
            Console.WriteLine("                    Penny: " + coinQty[3]);
            Console.WriteLine("                    Total Amount: $" + total + "\n");

        }
        
        public static void Menu(SodaMachine sodaMachine)
        {
            Console.WriteLine("\n   ************************");
            Console.WriteLine("   *  Cola        $" + sodaMachine.cola.Cost);
            Console.WriteLine("   *  Root Beer   $" + sodaMachine.rootBeer.Cost);
            Console.WriteLine("   *  Orange Soda $" + sodaMachine.orangeSoda.Cost);
            Console.WriteLine("   ************************");
        }
        
        

    }
}
