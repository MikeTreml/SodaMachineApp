using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Wallet
    {
        //member Variables 
        public List<Coin> coins;
        public Card card;
        public Quarter quarter;
        public Dime dime;
        public Nickel nickel;
        public Penny penny;

        //Constructor
        public Wallet()
        {
            
            coins = new List<Coin>();
            card = new Card();
            FillWallet();
        }
        void FillWallet() 
        {
            card = new Card();
            quarter = new Quarter();
            dime = new Dime();
            nickel = new Nickel();
            penny = new Penny();
            Functions.CreateCoins(quarter, 9,coins);
            Functions.CreateCoins(dime, 17, coins);
            Functions.CreateCoins(nickel, 8, coins);
            Functions.CreateCoins(penny, 83, coins);
        }
        //member methods
        
        
    }
}
