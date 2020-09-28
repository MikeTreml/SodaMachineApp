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
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine(text);
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public static void SodaChoice(double moneyInput)
        {
            Console.WriteLine("\nYou put in $" + moneyInput + "\n");
            Console.WriteLine(" 1 Cola");
            Console.WriteLine(" 2 Root Beer");
            Console.WriteLine(" 3 Orange Soda");
           
        }
       

        public static void SodaMachineInventoryDisplay(int[] sodaQty, int[] coinQty, string title,double payment)
        {
            double total = coinQty[0] * quater.Value + coinQty[1] * dime.Value + coinQty[2] * nickel.Value + coinQty[3] * penny.Value;
            Console.WriteLine(title + ":");
            Console.WriteLine(" Soda's             Coins");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(" Cola " + sodaQty[0] + "             Quarters: " + coinQty[0]);
            Console.WriteLine(" Root Beer " + sodaQty[1] + "        Dimes: " + coinQty[1]);
            Console.WriteLine(" Orange Soda " + sodaQty[2] + "      Nickels: " + coinQty[2]);
            Console.WriteLine("                    Penny: " + coinQty[3]);
            Console.WriteLine(" Payment:"+payment+"  Total Amount: $" + total + "\n");

        }
        public static void CustomerInventoryDisplay(int[] sodaQty, int[] coinQty, string title)
        {
            double total = coinQty[0] * quater.Value + coinQty[1] * dime.Value + coinQty[2] * nickel.Value + coinQty[3] * penny.Value;
            Console.WriteLine(title + ":");
            Console.WriteLine(" Soda's             Coins          ");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(" Cola " + sodaQty[0] + "             Quarters: " + coinQty[0]+"    ");
            Console.WriteLine(" Root Beer " + sodaQty[1] + "        Dimes: " + coinQty[1] + "      ");
            Console.WriteLine(" Orange Soda " + sodaQty[2] + "      Nickels: " + coinQty[2] + "     ");
            Console.WriteLine("                    Penny: " + coinQty[3] + "      ");
            Console.WriteLine("           Total Amount: $" + total + "  \n");
            

        }

        public static void ShowCustomersStuff(Customer customer)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            string title = "\nCustomer Inventory               ";
            int[] sodaQty = Functions.CanListCount(customer.backpack.can);
            int[] coinQty = Functions.CoinListCount(customer.wallet.coin);
            UserInterface.CustomerInventoryDisplay(sodaQty, coinQty, title);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ShowSodaMachineStuff(SodaMachine sodaMachine)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            string title = "\nThe Soda Machine inventory";
            int[] sodaQty = Functions.CanListCount(sodaMachine.inventory);
            int[] coinQty = Functions.CoinListCount(sodaMachine.register);
            double payment = sodaMachine.paymentTotal();
            UserInterface.SodaMachineInventoryDisplay(sodaQty, coinQty, title, payment);
            Console.ForegroundColor = ConsoleColor.White;

        }
        public static string LeaveSodaMachine() 
        {
            string input;
            Console.WriteLine("please press q to leave");
            input = Console.ReadLine();
            return input.ToLower();
        }

    }
}
