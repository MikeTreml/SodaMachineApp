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
        public static void SodaChoice()
        {
            Console.WriteLine(" 1 Cola");
            Console.WriteLine(" 2 Root Beer");
            Console.WriteLine(" 3 Orange Soda");
            InputVerificationNumbers(1, 3, "Please select your drink: ");
        }
        public static void CoinInput()
        {
            Console.WriteLine("Please enter the number of coins you want put in the Soda Machine");
        }
        public static void Menu(double cola,double rootBeer,double OrangeSoda)
        {
            Console.WriteLine(" Cola        $"+ cola);
            Console.WriteLine(" Root Beer   $"+ rootBeer);
            Console.WriteLine(" Orange Soda $"+ OrangeSoda);
        }
                
        public static void CoinsInWallet(int quarter, int dime, int nickel, int penny)
        {
            Console.WriteLine(" The current money in your wallet is:");
            Console.WriteLine(" Quarters: "+quarter);
            Console.WriteLine(" Dimes: "+ dime );
            Console.WriteLine(" Nickels: "+ nickel);
            Console.WriteLine(" Pennies: "+ penny);
            Console.WriteLine(" Total Amount: $"+ quarter *25+ dime *10+ nickel * 5+ penny);
        }

        public static void InventoryDisplay(int cola, int rootBeer, int orangeSoda, int quarter,int dime,int nickel,int penny,string title)
        {
            double total = quarter * 0.25 + dime * 0.10 + nickel * .5 + penny * .01;
            Console.WriteLine(title+":");
            Console.WriteLine(" Soda's             Coins");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(" Cola " + cola + "             Quarters: "+ quarter);
            Console.WriteLine(" Root Beer " + rootBeer + "        Dimes: " + dime);
            Console.WriteLine(" Orange Soda " + orangeSoda + "      Nickels: " + nickel);
            Console.WriteLine("                    Penny: " + penny);
            Console.WriteLine("                    Total Amount: $"+ total+"\n");

        }
        public static void TransferCoin(Coin coin, int number, List<Coin> from, List<Coin> to)
        {
            for (int i = 0; i < number; i++)
            {
                from.Remove(coin);
                to.Add(coin);
            }
        }
    }
}
