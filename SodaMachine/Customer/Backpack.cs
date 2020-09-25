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
        OrangeSoda orangeSoda;
        RootBeer rootBeer;
        Cola cola;
        //Constructor
        public Backpack()
        {
            FillBackBack();
        }

        void FillBackBack()
        {
            cans = new List<Can>();
            orangeSoda = new OrangeSoda();
            rootBeer = new RootBeer();
            cola = new Cola();

        }
    }
    //member methods


}

