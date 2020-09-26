using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class SodaMachine
    {
        //member Variables 
        public List<Coin> register;
        public List<Can> inventory;
        public List<Coin> payment;
        public Quarter quarter;
        public Dime dime;
        public Nickel nickel;
        public Penny penny;
        public OrangeSoda orangeSoda;
        public RootBeer rootBeer;
        public Cola cola;

        //Constructor
        public SodaMachine()
        {
            inventory = new List<Can>();
            register = new List<Coin>();
            payment = new List<Coin>();
            fillSodaMachine();
        }
        //member methods
        public void fillSodaMachine()
        {
            quarter = new Quarter();
            dime = new Dime();
            nickel = new Nickel();
            penny = new Penny();
            orangeSoda = new OrangeSoda();
            rootBeer = new RootBeer();
            cola = new Cola();
            Functions.CreateCans(cola, 5,inventory);
            Functions.CreateCans(orangeSoda, 9, inventory);
            Functions.CreateCans(rootBeer, 1,inventory);

            Functions.CreateCoins(quarter, 20, register);//20
            Functions.CreateCoins(dime, 10, register);//10
            Functions.CreateCoins(nickel, 20, register);//20
            Functions.CreateCoins(penny, 50, register);//50
        }

        public void ReturnMoney()
        {

        }
        public double CustomerPaymentAmount()
        {
            double paymentAmount = 0;
            foreach (Coin coin in payment)
            {
                if (coin.name.Contains("Quarter")) { paymentAmount += quarter.Value; }
                else if (coin.name.Contains("Dime")) { paymentAmount += dime.Value; }
                else if (coin.name.Contains("Nickel")) { paymentAmount += nickel.Value; }
                else if (coin.name.Contains("Penny")) { paymentAmount += penny.Value; }
            }
            return paymentAmount;
        }
        public bool HandlePayment(double paymentAmount)
        {
            double[] sodaPrices = {cola.Cost, rootBeer.Cost,orangeSoda.Cost};
            Can[] soda = { cola, rootBeer, orangeSoda };
            int choice = UserInterface.InputVerificationNumbers(1, 3, "Please select your drink: ") - 1;
            double cost = sodaPrices[choice];
            if (cost == paymentAmount) 
            { 
                
                //Transfer soda to backack 
            }
            else if ( cost < paymentAmount) 
            {
                Functions.TransferCoin()
                //transfer payment to vending machine
                //Transfer soda to backack 
                //refund payment cost difference
            }
            else if (cost>paymentAmount)
            {
                //transfer paymnet back to wallet
                
            }


            return true;
        }

        public void ShowSodaMachineInventory(SodaMachine sodaMachine)
        {
            //soda 0 cola, 1 rootbeer, 2 orangesoda
            int[] sodaQty = { 0, 0, 0 };
            int[] coinQty = { 0, 0, 0, 0 };

            string title = "The Soda Machine inventory";
            foreach (Can can in sodaMachine.inventory)
            {
                //sodaQty Array 0 cola, 1 rootbeer, 2 orangesoda
                if (can.name.Contains("Cola")) { sodaQty[0]++; }
                else if (can.name.Contains("Root Beer")) { sodaQty[1]++; }
                else if (can.name.Contains("Orange Soda")) { sodaQty[2]++; }
            }

            foreach (Coin coin in sodaMachine.register)
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
