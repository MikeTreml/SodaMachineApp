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
            int[] sodaQty = { 0, 0, 0 };
            int[] coinQty = { 0, 0, 0, 0 };

            string title = "\nCustomer Inventory";
            foreach (Can can in customer.backpack.cans)
            {
                //sodaQty Array 0 cola, 1 rootbeer, 2 orangesoda
                if (can.name.Contains("Cola")) { sodaQty[0]++; }
                else if (can.name.Contains("Root Beer")) { sodaQty[1]++; }
                else if (can.name.Contains("Orange Soda")) { sodaQty[2]++; }
            }
            foreach (Coin coin in customer.wallet.coins)
            {
                //coinQty Array 0 quarter, 1 dime, 2 nickel, 3 penny
                if (coin.name.Contains("Quarter")) { coinQty[0]++; }
                else if (coin.name.Contains("Dime")) { coinQty[1]++; }
                else if (coin.name.Contains("Nickel")) { coinQty[2]++; }
                else if (coin.name.Contains("Penny")) { coinQty[3]++; }
            }
            UserInterface.InventoryDisplay(sodaQty, coinQty, title);
            
            
        }

    }
}
