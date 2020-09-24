using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Wallet
    {
        //member Variables 
        public List<Coin> coins;
        public Card card;
        //Constructor
        public Wallet()
        {
            coins = new List<Coin>() { new Quarter(20), new Dime(10), new Nickle(20), new Penny(50) };
            card = new Card();
        }
        //member methods
    }
}
