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

        public void ShowInventory()
        {
            int cola = 0, rootBeer = 0, orangeSoda = 0, quarter = 0, dime = 0, nickel = 0, penny = 0;
            string title = "\nCustomer Inventory";
            foreach (Can can in backpack.cans)
            {
                if (can.name.Contains("Cola")) { cola++; }
                else if (can.name.Contains("Root Beer")) { rootBeer++; }
                else if (can.name.Contains("Orange Soda")) { orangeSoda++; }
            }
            foreach (Coin coin in wallet.coins)
            {
                if (coin.name.Contains("Quarter")) { quarter++; }
                else if (coin.name.Contains("Dime")) { dime++; }
                else if (coin.name.Contains("Nickel")) { nickel++; }
                else if (coin.name.Contains("Penny")) { penny++; }
            }
            UserInterface.InventoryDisplay(cola, rootBeer, orangeSoda, quarter, dime, nickel, penny,title);
        }
    }
}
