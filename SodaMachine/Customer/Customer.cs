using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Customer
    {
        //member Variables 
        public Wallet wallet;
        public Backpack backpack;
        
        //Constructor
        public Customer()
        {
            wallet = new Wallet();
            backpack = new Backpack();
        }
        //member methods
        
        public void ShowCustomersStuff(Customer customer)
        {
            string title = "\nCustomer Inventory";
            int[] sodaQty = Functions.CanListCount(backpack.can);
            int[] coinQty = Functions.CoinListCount(wallet.coin);
            UserInterface.CustomerInventoryDisplay(sodaQty, coinQty, title);
        }

    }
}
