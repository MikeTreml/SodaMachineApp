using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Customer
    {
        //member Variables 
        public Wallet wallet;
        public Backpack backpack;
        public List<Coin> payment;
        //Constructor
        public Customer()
        {
            wallet = new Wallet();
            backpack = new Backpack();
            payment = new List<Coin>();
            
        }
        //member methods

    }
}
