using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class SodaMachine
    {
        //member Variables 
        public List<Coin> register;
        public List<Can> inventory;

        //Constructor
        public SodaMachine()
        {
            register = new List<Coin>() { new Quarter(20), new Dime(10), new Nickle(20), new Penny(50) };
            inventory = new List<Can>() { new OrangeSoda(1), new RootBeer(2), new Cola(2) };
        }
        //member methods

        
    }
}
