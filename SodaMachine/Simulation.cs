using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //Console.BackgroundColor = ConsoleColor.Blue;
            //Console.WriteLine(sodaMachine.register[0].name + " " + sodaMachine.register[0].Value);
            sodaMachine.register.Remove(new Dime());
            Console.WriteLine(CoinTotal(sodaMachine.register));
            //Console.WriteLine(CoinTotalA(sodaMachine.register[0]));
            
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
