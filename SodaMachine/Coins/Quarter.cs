using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Quarter : Coin
    {
        //member Variables 

        //Constructor
        public Quarter(int quantity)
            : base(quantity)
        {
            name = "Quarter";
            value = .25;
        }
        //member methods
    }
}
