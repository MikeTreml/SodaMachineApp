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
        public static void SodaMenu()
        {
            Console.WriteLine(" Press 1 for Cola ($0.35 per can)");
            Console.WriteLine(" Press 2 for Root Beer ($0.60 per can)");
            Console.WriteLine(" Press 3 for Orange Soda ($0.06 per can)");
        }
        public static void CoinMenu()
        {
            Console.WriteLine(" Press 1 for Quarter");
            Console.WriteLine(" Press 2 for Dime");
            Console.WriteLine(" Press 3 for Nickel");
            Console.WriteLine( "Press 4 for Penny");
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
        public static void DisplaySodaInventory(int cola, int rootBeer, int orangeSoda, int quarter,int dime,int nickel,int penny)
        {
            double total = quarter * 0.25 + dime * 0.10 + nickel * .5 + penny * .01;
            Console.WriteLine("The Soda Machine inventory:");
            Console.WriteLine(" Soda's             Coins");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(" Cola " + cola + "             Quarters: "+ quarter);
            Console.WriteLine(" Root Beer " + rootBeer + "        Dimes: " + dime);
            Console.WriteLine(" Orange Soda " + orangeSoda + "     Nickels: " + nickel);
            Console.WriteLine("                    Penny: " + penny);
            Console.WriteLine("                    Total Amount: $"+ total+"\n");

        }

    }
}
