using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Nickle : Coin
    {
        //member Variables 

        //Constructor
        public Nickle(int quantity)
            : base(quantity)
        {
            name = "Nickel";
            value = .05;
        }
        //member methods
    }
}
