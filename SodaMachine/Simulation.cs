using System;
using System.Collections.Generic;

namespace SodaMachine
{
    class Simulation
    {
        //member Variables 

        //Constructor
        public Simulation()
        {

        }
        //member methods
        public void Run()
        {
            SodaMachine sodaMachine = new SodaMachine();
            Console.BackgroundColor = ConsoleColor.Blue;
            UserInterface.DisplayText("Welcome to Treml's vending service");
            Console.BackgroundColor = ConsoleColor.Black;
            sodaMachine.ShowInventory();
            UserInterface.SodaMenu();
            
           

          
            
            Console.ReadLine();
            
        }
        public double CoinTotal(List<Coin> coin)
        {
            double total = 0;
            for (int i = 0; i < coin.Count; i++)
            {
                Console.WriteLine(coin[i].name + " "+coin[i].Value);
                total += coin[i].Value;
                Console.WriteLine(Math.Round(total,2));
            }
            return total;
        }
        public static double CoinTotalA(Coin coin)
        {
            double total = 0;
            Console.WriteLine(coin.Value);
            total += coin.Value;
            return total;
        }
        public double CanTotal(List<Can> can)
        {
            double total = 0;
            for (int i = 0; i < can.Count; i++)
            {
                total = can[i].Cost;
            }
            return total;
        }
    }
}
