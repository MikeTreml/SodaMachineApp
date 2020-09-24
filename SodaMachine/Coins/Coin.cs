using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    abstract class Coin
    {
        //member Variables 
        protected double value;
        public double Value { get { return value; } }
        public string name;
        public int quantity;

        //Constructor
        public Coin(int quantity)
        {
            this.quantity = quantity;
        }
        //member methods
    }
}
