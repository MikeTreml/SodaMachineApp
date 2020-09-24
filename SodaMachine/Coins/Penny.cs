using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Penny : Coin
    {
        //member Variables 

        //Constructor
        public Penny(int quantity)
            : base(quantity)
        {
            name = "Penny";
            value = .01;
        }
        //member methods
    }
}
