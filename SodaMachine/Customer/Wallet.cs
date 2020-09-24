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
            //coins = new List<Coin>() { new Quarter(), new Dime(), new Nickle(), new Penny() };
            card = new Card();
        }
        //member methods
    }
}
