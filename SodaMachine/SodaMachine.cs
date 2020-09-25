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
        public Quarter quarter;
        Dime dime;
        Nickel nickle;
        Penny penny;
        OrangeSoda orangeSoda;
        RootBeer rootBeer;
        Cola cola;

        //Constructor
        public SodaMachine()
        {
            inventory = new List<Can>();
            register = new List<Coin>();
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
            AddCans(orangeSoda, 10);
            AddCans(rootBeer, 1);

            AddCoins(quarter, 20);
            AddCoins(dime, 10);
            AddCoins(nickle, 20);
            AddCoins(penny, 50);
        }

        public void AddCans(Can soda, int number)
        {
            for (int i = 0; i < number; i++)
            {
                inventory.Add(soda);
            }
        }
        public void RemoveCans(Can soda, int number)
        {
            for (int i = 0; i < number; i++)
            {
                inventory.Remove(soda);
            }
        }
        public void AddCoins(Coin coin, int number)
        {
            for (int i = 0; i < number; i++)
            {
                register.Add(coin);
            }
        }
        public void RemoveCoin(Coin coin, int number)
        {
            for (int i = 0; i < number; i++)
            {
                register.Remove(coin);
            }
        }
        public void ShowInventory()
        {
            int cola = 0, rootBeer = 0, orangeSoda = 0, quarter = 0, dime = 0, nickel = 0, penny = 0;
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
            UserInterface.DisplaySodaInventory(cola, rootBeer, orangeSoda, quarter, dime, nickel, penny);
        }
    }
}
