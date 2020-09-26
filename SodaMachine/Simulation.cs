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
            double payment = 0;
            sodaMachine = new SodaMachine();
            customer = new Customer();
            Console.BackgroundColor = ConsoleColor.Blue;
            UserInterface.DisplayText("Welcome to Treml's vending service");
            Console.BackgroundColor = ConsoleColor.Black;
            sodaMachine.ShowSodaMachineInventory(sodaMachine);
            UserInterface.Menu(sodaMachine);
            customer.ShowCustomersStuff(customer);
            UserInterface.CoinInput();
            ChoosingCoinToInput();
            payment = sodaMachine.CustomerPaymentAmount();
            UserInterface.SodaChoice(payment);
            sodaMachine.HandlePayment(payment);
           

            Console.ReadLine();
        }
        public void ChoosingCoinToInput() 
        {
            int numberOfQuarter=0, numberOfdime = 0, numberOfnickel = 0, numberOfpenny = 0;
            int lowestnumber = 1;
            foreach (Coin coin in customer.wallet.coins)
            {
                if (coin.name.Contains("Quarter")) { numberOfQuarter++; }
                else if (coin.name.Contains("Dime")) { numberOfdime++; }
                else if (coin.name.Contains("Nickel")) { numberOfnickel++; }
                else if (coin.name.Contains("Penny")) { numberOfpenny++; }
            }
            numberOfQuarter = UserInterface.InputVerificationNumbers(lowestnumber, numberOfQuarter, "How many quater(s):");
            numberOfdime = UserInterface.InputVerificationNumbers(lowestnumber, numberOfdime, "How many dime(s):");
            numberOfnickel = UserInterface.InputVerificationNumbers(lowestnumber, numberOfnickel, "How many nickel(s):");
            numberOfpenny = UserInterface.InputVerificationNumbers(lowestnumber, numberOfpenny, "How many penny(s):");
            Functions.TransferCoin(customer.wallet.quarter, numberOfQuarter, customer.wallet.coins,sodaMachine.payment);
            Functions.TransferCoin(customer.wallet.dime, numberOfdime, customer.wallet.coins, sodaMachine.payment);
            Functions.TransferCoin(customer.wallet.nickel, numberOfnickel, customer.wallet.coins, sodaMachine.payment);
            Functions.TransferCoin(customer.wallet.penny, numberOfpenny, customer.wallet.coins, sodaMachine.payment);
        }
    }
}
