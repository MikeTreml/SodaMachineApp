using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Cola:Can
    {
        //member Variables 

        //Constructor
        public Cola(int quantity)
            : base(quantity)
        {
            name = "Cola";
            cost = 0.35;
        }
        //member methods
    }
}
