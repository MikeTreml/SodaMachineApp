using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Dime : Coin
    {
        //member Variables 

        //Constructor
        public Dime(int quantity)
            : base(quantity)
        {
            name = "Dime";
            value = .10;
            
        }
        //member methods

    }
}
