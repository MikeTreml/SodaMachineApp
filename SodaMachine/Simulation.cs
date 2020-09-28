using System;
using System.Collections.Generic;

namespace SodaMachine
{
    class Simulation
    {
        //member Variables 
        SodaMachine sodaMachine;
        Customer customer;
        string leave = "";
        //Constructor
        public Simulation()
        {

        }
        //member methods
        public void Run()
        {
            sodaMachine = new SodaMachine();
            customer = new Customer();
            UserInterface.DisplayText("Welcome to Treml's vending service");
            do
            {
                UserInterface.ShowSodaMachineStuff(sodaMachine);
                sodaMachine.Menu();
                UserInterface.ShowCustomersStuff(customer);
                PickPaymentType();
                //Console.Clear(); //comment this for deguging for history of transactions
                UserInterface.ShowSodaMachineStuff(sodaMachine);
                UserInterface.ShowCustomersStuff(customer);
                leave = UserInterface.LeaveSodaMachine();
            } while (leave != "q");

        }
        private void PickPaymentType()
        {
            switch (UserInterface.InputVerificationNumbers(1, 2, "Please pick paymet type 1 for card 2 for coins."))
            {
                case 1:
                    ChoosingPayInput();
                    break;
                case 2:
                    ChoosingPayInput(Functions.CoinListCount(customer.wallet.coin));
                    UserInterface.SodaChoice(sodaMachine.paymentTotal());
                    CustomerSodaChoice();
                    break;
            }
        }
        private void ChoosingPayInput()
        {
            UserInterface.SodaChoice(customer.wallet.card.AvailableFunds);
            int choice = UserInterface.InputVerificationNumbers(1, 3, "Please select your drink: ") - 1;
            HandlePayment(choice, customer.wallet.card.AvailableFunds, true);
        }
        private void ChoosingPayInput(int[] coinCount)
        {
            int[] coinPayment = { 0, 0, 0, 0 };
            int lowestNumber = 0;

            coinPayment[0] = UserInterface.InputVerificationNumbers(lowestNumber, coinCount[0], "How many quater(s):");
            coinPayment[1] = UserInterface.InputVerificationNumbers(lowestNumber, coinCount[1], "How many dime(s):");
            coinPayment[2] = UserInterface.InputVerificationNumbers(lowestNumber, coinCount[2], "How many nickel(s):");
            coinPayment[3] = UserInterface.InputVerificationNumbers(lowestNumber, coinCount[3], "How many penny(s):");
            WalletToPayment(coinPayment);
        }

        private void CustomerSodaChoice()
        {
            int[] coinCount = Functions.CoinListCount(sodaMachine.payment);
            int[] sodaCount = Functions.CanListCount(sodaMachine.inventory);
            int choice = UserInterface.InputVerificationNumbers(1, 3, "Please select your drink: ") - 1;
            double paymentAmount = Math.Round(sodaMachine.paymentTotal(), 2);

            if (sodaCount[choice] > 0)
            {
                HandlePayment(choice, paymentAmount, false);
            }
            else
            {
                Console.WriteLine("Sorry your choice is out of stock. " + paymentAmount + " will be refunded");
                PaymentToWallet(coinCount);
            }

        }
        private void HandlePayment(int choice, double paymentAmount, bool card)
        {
            int[] coinPayment = Functions.CoinListCount(sodaMachine.payment);
            int[] sodaSelect = { 0, 0, 0 };

            double[] sodaPrices = { sodaMachine.cola.Cost, sodaMachine.rootBeer.Cost, sodaMachine.orangeSoda.Cost };
            Can[] soda = { sodaMachine.cola, sodaMachine.rootBeer, sodaMachine.orangeSoda };

            sodaSelect[choice] = 1;
            double cost = sodaPrices[choice];
            if(card)
            {
                if (paymentAmount > sodaPrices[choice])
                {
                    //go through with purchase
                    CardToCard(sodaPrices[choice]);
                    InventoryToBackPack(sodaSelect);
                }
                else
                {
                    Console.WriteLine("Your cars was declined");
                }
            }
            else if (cost <= paymentAmount)
            {
                if (cost == paymentAmount)
                {
                    PaymentToRegister(coinPayment);
                    InventoryToBackPack(sodaSelect);
                    Console.WriteLine("Thank you for use exact change");
                }

                if (cost < paymentAmount)
                {
                    double changeAmount = Math.Round(paymentAmount - cost);
                    int[] coinRefund = CalculateChange(Math.Round(changeAmount, 2));
                    double totalAvailableCoins = coinRefund[0] * sodaMachine.quarter.Value + coinRefund[1] * sodaMachine.dime.Value + coinRefund[2] * sodaMachine.nickel.Value + coinRefund[3] * sodaMachine.penny.Value;
                    if (changeAmount == totalAvailableCoins)
                    {
                        PaymentToRegister(coinPayment);
                        InventoryToBackPack(sodaSelect);
                        RegisterToWallet(coinRefund);
                        Console.WriteLine("Thank you for your purchase.");
                    }
                    else
                    {
                        PaymentToWallet(coinPayment);
                        Console.WriteLine("Sorry. Unable to provide change for your selection.");
                    }
                }
            }
            else if (cost > paymentAmount)
            {

                PaymentToWallet(coinPayment);
                Console.WriteLine("You did put in enough money. Your money has been returned");

            }

        }
        private int[] CalculateChange(double refund)
        {
            double tempValueRefund;
            //int[] countCount = sodaMachine.CoinListCount();
            int[] countCountRegister = Functions.CoinListCount(sodaMachine.register);
            int[] coins = { 0, 0, 0, 0 };

            coins[0] = (int)Math.Floor(refund / sodaMachine.quarter.Value);
            if (coins[0] > countCountRegister[0]) { coins[0] = countCountRegister[0]; }
            tempValueRefund = Math.Round(refund - coins[0] * sodaMachine.quarter.Value, 2);

            coins[1] = (int)Math.Floor(tempValueRefund / sodaMachine.dime.Value);
            if (coins[1] > countCountRegister[1]) { coins[1] = countCountRegister[1]; }
            tempValueRefund = Math.Round(tempValueRefund - coins[1] * sodaMachine.dime.Value, 2);

            coins[2] = (int)Math.Floor(tempValueRefund / sodaMachine.nickel.Value);
            if (coins[2] > countCountRegister[2]) { coins[2] = countCountRegister[2]; }
            tempValueRefund = Math.Round(tempValueRefund - coins[2] * sodaMachine.nickel.Value, 2);

            coins[3] = (int)Math.Floor(tempValueRefund / sodaMachine.penny.Value);
            if (coins[3] > countCountRegister[3]) { coins[3] = countCountRegister[3]; }
            tempValueRefund = Math.Round(tempValueRefund - coins[3] * sodaMachine.penny.Value, 2);

            if (tempValueRefund != 0) { Console.WriteLine("Refund Error " + tempValueRefund); }
            return coins;
        }
        private void InventoryToBackPack(int[] soda)
        {
            Functions.TransferCan(sodaMachine.cola, soda[0], sodaMachine.inventory, customer.backpack.can);
            Functions.TransferCan(sodaMachine.rootBeer, soda[1], sodaMachine.inventory, customer.backpack.can);
            Functions.TransferCan(sodaMachine.orangeSoda, soda[2], sodaMachine.inventory, customer.backpack.can);
        }
        private void WalletToPayment(int[] coins)
        {
            Functions.TransferCoin(customer.wallet.quarter, sodaMachine.quarter, coins[0], customer.wallet.coin, sodaMachine.payment);
            Functions.TransferCoin(customer.wallet.dime, sodaMachine.dime, coins[1], customer.wallet.coin, sodaMachine.payment);
            Functions.TransferCoin(customer.wallet.nickel, sodaMachine.nickel, coins[2], customer.wallet.coin, sodaMachine.payment);
            Functions.TransferCoin(customer.wallet.penny, sodaMachine.penny, coins[3], customer.wallet.coin, sodaMachine.payment);
        }
        private void PaymentToRegister(int[] coins)
        {
            Functions.TransferCoin(sodaMachine.quarter, coins[0], sodaMachine.payment, sodaMachine.register);
            Functions.TransferCoin(sodaMachine.dime, coins[1], sodaMachine.payment, sodaMachine.register);
            Functions.TransferCoin(sodaMachine.nickel, coins[2], sodaMachine.payment, sodaMachine.register);
            Functions.TransferCoin(sodaMachine.penny, coins[3], sodaMachine.payment, sodaMachine.register);
        }
        private void RegisterToWallet(int[] coins)
        {
            Functions.TransferCoin(sodaMachine.quarter, customer.wallet.quarter, coins[0], sodaMachine.register, customer.wallet.coin);
            Functions.TransferCoin(sodaMachine.dime, customer.wallet.dime, coins[1], sodaMachine.register, customer.wallet.coin);
            Functions.TransferCoin(sodaMachine.nickel, customer.wallet.nickel, coins[2], sodaMachine.register, customer.wallet.coin);
            Functions.TransferCoin(sodaMachine.penny, customer.wallet.penny, coins[3], sodaMachine.register, customer.wallet.coin);

        }
        private void PaymentToWallet(int[] coins)
        {
            Functions.TransferCoin(sodaMachine.quarter, customer.wallet.quarter, coins[0], sodaMachine.payment, customer.wallet.coin);
            Functions.TransferCoin(sodaMachine.dime, customer.wallet.dime, coins[1], sodaMachine.payment, customer.wallet.coin);
            Functions.TransferCoin(sodaMachine.nickel, customer.wallet.nickel, coins[2], sodaMachine.payment, customer.wallet.coin);
            Functions.TransferCoin(sodaMachine.penny, customer.wallet.penny, coins[3], sodaMachine.payment, customer.wallet.coin);
        }
        private void CardToCard(double price)
        {
            Functions.TransferCard(customer.wallet.card, sodaMachine.card, price);
        }
    }
}
