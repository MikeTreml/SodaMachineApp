using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Backpack
    {
        //member Variables 
        public List<Can> cans;
        //Constructor
        public Backpack()
        {
            cans = new List<Can>() { new OrangeSoda(0), new RootBeer(0), new Cola(0) };
        }
    }
    //member methods
}

