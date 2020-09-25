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
        
    }
}
