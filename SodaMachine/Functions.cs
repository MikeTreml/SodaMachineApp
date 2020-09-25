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
       
    }
}
