using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Card
    {
        //member Variables 
        protected double availableFunds;
        public double AvailableFunds 
        { 
            get 
            { 
                return availableFunds; 
            }
            set
            {
                availableFunds = value;
            }
        }
        //Constructor
        public Card()
        {
            
        }
        //member methods
    }
}
