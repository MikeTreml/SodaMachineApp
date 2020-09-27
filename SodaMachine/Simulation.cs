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
            UserInterface.DisplayText("Welcome to Treml's vending service");
            do
            {
                sodaMachine.ShowSodaMachineStuff();
                sodaMachine.Menu();

                customer.ShowCustomersStuff(customer);
                UserInterface.CoinInput();
                ChoosingCoinToInput();
                //Console.Clear();
                sodaMachine.ShowSodaMachineStuff();
                customer.ShowCustomersStuff(customer);
                UserInterface.SodaChoice(sodaMachine.paymentTotal());
                HandlePayment(sodaMachine.paymentTotal());


                Console.ReadLine();
            } while (true);

        }

        public void ChoosingCoinToInput()
        {

            int[] coinCount = Functions.CoinListCount(customer.wallet.coin);
            int[] coinPayment = { 0, 0, 0, 0 };
            int lowestnumber = 0;

            coinPayment[0] = UserInterface.InputVerificationNumbers(lowestnumber, coinCount[0], "How many quater(s):");
            coinPayment[1] = UserInterface.InputVerificationNumbers(lowestnumber, coinCount[1], "How many dime(s):");
            coinPayment[2] = UserInterface.InputVerificationNumbers(lowestnumber, coinCount[2], "How many nickel(s):");
            coinPayment[3] = UserInterface.InputVerificationNumbers(lowestnumber, coinCount[3], "How many penny(s):");
            Functions.TransferCoin(customer.wallet.quarter, sodaMachine.quarter, coinPayment[0], customer.wallet.coin, sodaMachine.payment);
            Functions.TransferCoin(customer.wallet.dime, sodaMachine.dime, coinPayment[1], customer.wallet.coin, sodaMachine.payment);
            Functions.TransferCoin(customer.wallet.nickel, sodaMachine.nickel, coinPayment[2], customer.wallet.coin, sodaMachine.payment);
            Functions.TransferCoin(customer.wallet.penny, sodaMachine.penny, coinPayment[3], customer.wallet.coin, sodaMachine.payment);
        }
        public bool HandlePayment(double paymentAmount)
        {
            int[] countCount = Functions.CoinListCount(sodaMachine.payment);
            int[] sodaSelect = { 0, 0, 0 };
            double[] sodaPrices = { sodaMachine.cola.Cost, sodaMachine.rootBeer.Cost, sodaMachine.orangeSoda.Cost };
            Can[] soda = { sodaMachine.cola, sodaMachine.rootBeer, sodaMachine.orangeSoda };
            int choice = UserInterface.InputVerificationNumbers(1, 3, "Please select your drink: ") - 1;
            sodaSelect[choice] = 1;
            double cost = sodaPrices[choice];

            if (cost <= paymentAmount)
            {
                Functions.TransferCoin(sodaMachine.quarter, countCount[0], sodaMachine.payment, sodaMachine.register);
                Functions.TransferCoin(sodaMachine.dime, countCount[1], sodaMachine.payment, sodaMachine.register);
                Functions.TransferCoin(sodaMachine.nickel, countCount[2], sodaMachine.payment, sodaMachine.register);
                Functions.TransferCoin(sodaMachine.penny, countCount[3], sodaMachine.payment, sodaMachine.register);
                Functions.TransferCan(sodaMachine.cola, sodaSelect[0], sodaMachine.inventory, customer.backpack.can);
                Functions.TransferCan(sodaMachine.rootBeer, sodaSelect[1], sodaMachine.inventory, customer.backpack.can);
                Functions.TransferCan(sodaMachine.orangeSoda, sodaSelect[2], sodaMachine.inventory, customer.backpack.can);
                if (cost == paymentAmount)
                {
                    Console.WriteLine("Thank you for use exact change");
                }

                if (cost < paymentAmount)
                {
                    double change = paymentAmount - cost;
                    GiveChangeBack(Math.Round(change,2));
                    Console.WriteLine("Thank you for your purchase.");
                }
            }
            else if (cost > paymentAmount)
            {

                Functions.TransferCoin(sodaMachine.quarter, customer.wallet.quarter, countCount[0], sodaMachine.payment, customer.wallet.coin);
                Functions.TransferCoin(sodaMachine.dime, customer.wallet.dime, countCount[1], sodaMachine.payment, customer.wallet.coin);
                Functions.TransferCoin(sodaMachine.nickel, customer.wallet.nickel, countCount[2], sodaMachine.payment, customer.wallet.coin);
                Functions.TransferCoin(sodaMachine.penny, customer.wallet.penny, countCount[3], sodaMachine.payment, customer.wallet.coin);
                Console.WriteLine("You did put in enough money. Your money has been returned");

            }
            return true;
        }
        public void GiveChangeBack(double refund)
        {
            double tempValueRefund;
            //int[] countCount = sodaMachine.CoinListCount();
            int[] countCountRegister = Functions.CoinListCount(sodaMachine.register);
            int quarterNumber = 0, dimeNumber = 0, nickelNumber = 0, pennyNumber = 0;

            quarterNumber = (int)Math.Floor(refund / .25);
            if (quarterNumber > countCountRegister[0]) { quarterNumber = countCountRegister[0]; }
            tempValueRefund = Math.Round(refund - quarterNumber * .25,2);

            dimeNumber = (int)Math.Floor(tempValueRefund / .1);
            if (dimeNumber > countCountRegister[1]) { dimeNumber = countCountRegister[1]; }
            tempValueRefund = Math.Round(tempValueRefund - dimeNumber * .1,2);

            nickelNumber = (int)Math.Floor(tempValueRefund / .05);
            if (nickelNumber > countCountRegister[2]) { nickelNumber = countCountRegister[2]; }
            tempValueRefund = Math.Round(tempValueRefund - nickelNumber * .05,2);

            pennyNumber = (int)Math.Floor(tempValueRefund / .01);
            if (pennyNumber > countCountRegister[3]) { pennyNumber = countCountRegister[3]; }
            tempValueRefund = Math.Round(tempValueRefund - pennyNumber * .01,2);

            if (tempValueRefund == 0) { Console.WriteLine("Refund Error "+ tempValueRefund); }


            Functions.TransferCoin(sodaMachine.quarter, customer.wallet.quarter, quarterNumber, sodaMachine.register, customer.wallet.coin);
            Functions.TransferCoin(sodaMachine.dime, customer.wallet.dime, dimeNumber, sodaMachine.register, customer.wallet.coin);
            Functions.TransferCoin(sodaMachine.nickel, customer.wallet.nickel, nickelNumber, sodaMachine.register, customer.wallet.coin);
            Functions.TransferCoin(sodaMachine.penny, customer.wallet.penny, pennyNumber, sodaMachine.register, customer.wallet.coin);
            Console.WriteLine("Your change is  "+ quarterNumber + " quaters  "+ dimeNumber + " dimes  "+ nickelNumber + " nickels  "+ pennyNumber + " penny");
            double total = quarterNumber * .25 + dimeNumber * .1 + nickelNumber * .05 + pennyNumber * .01;
            Console.WriteLine(total +" compare "+ refund);
        }
    }
}
