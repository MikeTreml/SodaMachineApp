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
        public List<Can> can;
        public OrangeSoda orangeSoda;
        public RootBeer rootBeer;
        public Cola cola;
        //Constructor
        public Backpack()
        {
            FillBackBack();
        }

        void FillBackBack()
        {
            can = new List<Can>();
            orangeSoda = new OrangeSoda();
            rootBeer = new RootBeer();
            cola = new Cola();

        }


    }
    //member methods



}

