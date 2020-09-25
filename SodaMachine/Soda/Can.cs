using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    abstract class Can
    {
        //member Variables 
        protected double cost;
        public double Cost { get { return cost; } }
        public string name;
       
        //Constructor
        public Can()
        {
            
        }
        //member methods
    }
}
