using System;
using System.Collections.Generic;
using System.Linq;
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
        public Nickel nickle;
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
            nickle = new Nickel();
            penny = new Penny();
            orangeSoda = new OrangeSoda();
            rootBeer = new RootBeer();
            cola = new Cola();
            AddCans(cola, 5);
            AddCans(orangeSoda, 9);
            AddCans(rootBeer, 1);

            AddCoin(quarter, 20);
            AddCoin(dime, 10);
            AddCoin(nickle, 20);
            AddCoin(penny, 50);
        }

        public void AddCans(Can soda, int number, List<Can> to)
        {
            for (int i = 0; i < number; i++)
            {
                to.Add(soda);
            }
        }
        public void RemoveCans(Can soda, int number,List<Can> from)
        {
            for (int i = 0; i < number; i++)
            {
                from.Remove(soda);
            }
        }
        public void transferCans(Can soda, int number, List<Can> from, List<Can> to)
        {
            for (int i = 0; i < number; i++)
            {
                from.Remove(soda);
                to.Remove(soda);
            }
        }


        public void AddCoin(Coin coin, int number, List<Coin> to)
        {
            for (int i = 0; i < number; i++)
            {
                to.Add(coin);
            }
        }
        public void RemoveCoin(Coin coin, int number, List<Coin> from)
        {
            for (int i = 0; i < number; i++)
            {
                from.Remove(coin);
            }
        }
        public void TransferCoin(Coin coin, int number,List<Coin> from, List<Coin>to)
        {
            for (int i = 0; i < number; i++)
            {
                from.Remove(coin);
                to.Add(coin);
            }
        }
        public void ShowInventory()
        {
            int cola = 0, rootBeer = 0, orangeSoda = 0, quarter = 0, dime = 0, nickel = 0, penny = 0;
            string title = "The Soda Machine inventory";
            foreach (Can can in inventory)
            {
                if (can.name.Contains("Cola")) { cola++; }
                else if (can.name.Contains("Root Beer")) { rootBeer++; }
                else if (can.name.Contains("Orange Soda")) { orangeSoda++; }
            }
            foreach (Coin coin in register)
            {
                if (coin.name.Contains("Quarter")) { quarter++; }
                else if (coin.name.Contains("Dime")) { dime++; }
                else if (coin.name.Contains("Nickel")) { nickel++; }
                else if (coin.name.Contains("Penny")) { penny++; }
            }
            UserInterface.InventoryDisplay(cola, rootBeer, orangeSoda, quarter, dime, nickel, penny,title);
        }
        public void Menu()
        {
            Console.WriteLine("\n   ************************");
            Console.WriteLine("   *  Cola        $" + cola.Cost);
            Console.WriteLine("   *  Root Beer   $" + rootBeer.Cost);
            Console.WriteLine("   *  Orange Soda $" + orangeSoda.Cost);
            Console.WriteLine("   ************************");
        }
    }
}
