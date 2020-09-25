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
        Quarter quarter;
        Dime dime;
        Nickel nickle;
        Penny penny;

        //Constructor
        public Wallet()
        {
            FillWallet();
            coins = new List<Coin>();
            card = new Card();
           
        }
        void FillWallet() 
        {
            card = new Card();
            quarter = new Quarter();
            dime = new Dime();
            nickle = new Nickel();
            penny = new Penny();
            AddCoins(quarter, 20);
            AddCoins(dime, 200);
            AddCoins(nickle, 50);
            AddCoins(penny, 20);
        }
        //member methods
        public void AddCoins(Coin coin, int number)
        {
            for (int i = 0; i < number; i++)
            {
                coins.Add(coin);
            }
        }
        public void RemoveCoin(Coin coin, int number)
        {
            for (int i = 0; i < number; i++)
            {
                coins.Remove(coin);
            }
        }
    }
}
