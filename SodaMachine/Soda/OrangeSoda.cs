using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class OrangeSoda : Can
    {
        //member Variables 

        //Constructor
        public OrangeSoda(int quantity)
            : base(quantity)
        {
            name = "Orange Soda";
            cost = 0.06;
        }
        //member methods
    }
}
