using System;
using System.Collections.Generic;

namespace SodaMachine
{
    class Simulation
    {
        //member Variables 
        public SodaMachine sodaMachine;
        public Customer customer;

        //Constructor
        public Simulation()
        {

        }
        //member methods
        public void Run()
        {
            sodaMachine = new SodaMachine();
            customer = new Customer();
            Console.BackgroundColor = ConsoleColor.Blue;
            UserInterface.DisplayText("Welcome to Treml's vending service");
            Console.BackgroundColor = ConsoleColor.Black;
            sodaMachine.ShowInventory();
            sodaMachine.Menu();
            customer.ShowInventory();
            UserInterface.CoinInput();
            ChooseCoinInput();
            customer.ShowInventory();
            Console.ReadLine();
            
        }
        public void ChooseCoinInput() 
        {
            int quarter=0, dime=0, nickel=0, penny=0;
            foreach (Coin coin in customer.wallet.coins)
            {
                if (coin.name.Contains("Quarter")) { quarter++; }
                else if (coin.name.Contains("Dime")) { dime++; }
                else if (coin.name.Contains("Nickel")) { nickel++; }
                else if (coin.name.Contains("Penny")) { penny++; }
            }
            quarter = UserInterface.InputVerificationNumbers(1, quarter, "How many quater(s):");
            dime = UserInterface.InputVerificationNumbers(1, dime, "How many dime(s):");
            nickel = UserInterface.InputVerificationNumbers(1, nickel, "How many nickel(s):");
            penny = UserInterface.InputVerificationNumbers(1, penny, "How many penny(s):");
            UserInterface.TransferCoin(customer.wallet.quarter, quarter, customer.wallet.coins,sodaMachine.payment);
            UserInterface.TransferCoin(customer.wallet.dime, dime, customer.wallet.coins, sodaMachine.payment);
            UserInterface.TransferCoin(customer.wallet.nickel, nickel, customer.wallet.coins, sodaMachine.payment);
            UserInterface.TransferCoin(customer.wallet.penny, penny, customer.wallet.coins, sodaMachine.payment);
            

        }
    }
}
