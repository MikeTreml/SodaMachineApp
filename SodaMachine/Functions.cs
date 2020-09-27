using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    static class Functions
    {

        public static void TransferCoin(Coin coin, int number, List<Coin> from, List<Coin> to)
        {
            for (int i = 0; i < number; i++)
            {
                from.Remove(coin);
                to.Add(coin);
            }
        }
        // need to overload this method. I can send it Sodamachine.coins to wallet. but if i am pulling wallet.coins i am never 
        //pulling the Sodamachine.coins. so i need to got through one extra step and add in the coin type for wallet and sodamachine
        public static void TransferCoin(Coin coinFrom, Coin coinTo, int number, List<Coin> from, List<Coin> to)
        {
            for (int i = 0; i < number; i++)
            {
                from.Remove(coinFrom);
                to.Add(coinTo);
            }
        }
        public static void TransferCan(Can can, int number, List<Can> from, List<Can> to)
        {
            for (int i = 0; i < number; i++)
            {
                from.Remove(can);
                to.Add(can);
            }
        }

        // should only be to create items for starting values
        public static void CreateCans(Can soda, int number, List<Can> to)
        {
            for (int i = 0; i < number; i++)
            {
                to.Add(soda);
            }
        }
        public static void CreateCoins(Coin coin, int number, List<Coin> to)
        {
            for (int i = 0; i < number; i++)
            {
                to.Add(coin);
            }
        }
        public static int[] CoinListCount(List<Coin> coinList)
        {
            int[] coinQty = { 0, 0, 0, 0 };
            foreach (Coin coin in coinList)
            {
                //coinQty Array 0 quarter, 1 dime, 2 nickel, 3 penny
                if (coin.name.Contains("Quarter")) { coinQty[0]++; }
                else if (coin.name.Contains("Dime")) { coinQty[1]++; }
                else if (coin.name.Contains("Nickel")) { coinQty[2]++; }
                else if (coin.name.Contains("Penny")) { coinQty[3]++; }
            }
            return coinQty;
        }
        public static int[] CanListCount(List<Can> canList)
        {
            int[] sodaQty = { 0, 0, 0 };
            foreach (Can can in canList)
            {
                //sodaQty Array 0 cola, 1 rootbeer, 2 orangesoda
                if (can.name.Contains("Cola")) { sodaQty[0]++; }
                else if (can.name.Contains("Root Beer")) { sodaQty[1]++; }
                else if (can.name.Contains("Orange Soda")) { sodaQty[2]++; }
            }
            return sodaQty;
        }
       
    }

}
