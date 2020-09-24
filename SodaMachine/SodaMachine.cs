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
        Quarter quarter;
        Dime dime;
        Nickle nickle;
        Penny penny;
        OrangeSoda orangeSoda;
        RootBeer rootBeer;
        Cola cola;

        //Constructor
        public SodaMachine()
        {
            quarter = new Quarter();
            inventory = new List<Can>();
            AddCans(new Cola(1), 15);
            AddCans(new OrangeSoda(1), 15);
            AddCans(new RootBeer(1), 15);

            register = new List<Coin>();
            AddCoins(quarter, 2);
            RemoveCoin(quarter, 1);
            AddCoins(new Dime(), 2);
            AddCoins(new Nickle(), 2);
            AddCoins(new Penny(), 5);
            //RemoveCoin(register.Remove(Quarter), 1);
           
            //register1 = new List<Coin>() { new Quarter(), new Dime(), new Nickle(), new Penny() };
            //inventory1 = new List<Can>() { new OrangeSoda(1), new RootBeer(2), new Cola(2) };

        }
        //member methods
        public void RemoveCoin(Coin coin, int number)
        {
            register.Remove(coin);
           

        }
        public void AddCans(Can soda, int number)
        {
            for (int i = 0; i < number; i++)
            {
                inventory.Add(soda);
            }
        }
        public void AddCoins(Coin coin, int number)
        {
            for (int i = 0; i < number; i++)
            {
                register.Add(coin);
            }
        }
    }
}
