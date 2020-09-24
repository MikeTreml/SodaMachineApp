using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class RootBeer:Can
    {
        //member Variables 

        //Constructor
        public RootBeer(int quantity)
            : base(quantity)
        {
            name = "Root Beer";
            cost = 0.60;
        }
        //member methods
    }
}
