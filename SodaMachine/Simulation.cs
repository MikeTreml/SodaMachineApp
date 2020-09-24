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
            Console.WriteLine(sodaMachine.register[0].quantity+" "+ sodaMachine.register[0].name + " " + sodaMachine.register[0].Value);
            Console.WriteLine(CoinTotal(sodaMachine.register));
            Console.WriteLine(CoinTotalA(sodaMachine.register[0]));
            Console.ReadLine();
            
        }
        public double CoinTotal(List<Coin> coin)
        {
            double total = 0;
            for (int i = 0; i < coin.Count; i++)
            {
                Console.WriteLine(coin[i].Value +" "+ coin[i].quantity);
                total += coin[i].Value* coin[i].quantity;
            }
            return total;
        }
        public double CoinTotalA(Coin coin)
        {
            double total = 0;
            for (int i = 0; i < coin.quantity; i++)
            {
                Console.WriteLine(coin.Value + " " + coin.quantity);
                total += coin.Value * coin.quantity;
            }
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
