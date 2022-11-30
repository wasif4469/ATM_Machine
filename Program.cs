using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM_Machine
{
    public class CardHolder
    {
        string firstName;
        string lastName;
        int pin;
        string cardNum;
        double balance;

        public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
        {
            this.cardNum = cardNum;
            this.pin = pin;
            this.firstName = firstName;
            this.lastName = lastName;
            this.balance = balance;
        }
        public string getfirstName()
        {
            return firstName;
        }
        public string getlastName()
        {
            return lastName;
        }
        public int getPin()
        {
            return pin;
        }
        public string getCardNum()
        {
            return cardNum;
        }
        public double getBalance()
        {
            return balance;
        }

        public void setFirstName(string newFirstName)
        {
            firstName = newFirstName;
        }
        public void setLastName(string newLastName)
        {
            lastName = newLastName;
        }
        public void setPin(int newPin)
        {
            pin = newPin;
        }

        public void setCardNum(string newCardNum)
        {
            cardNum = newCardNum;
        }
        public void setBalance(double newBalance)
        {
            balance = newBalance;
        }
        public static void printOptions()

        {
            Console.WriteLine("1. Deposit.");
            Console.WriteLine("2. Withdrawl.");
            Console.WriteLine("3. Show Balance.");
            Console.WriteLine("4. Exit.");
            Console.WriteLine("\n");
        }

        public static void deposit(CardHolder currentUser)
        {
            Console.WriteLine("Please Enter the amount of $$ you want to deposit: ");
            double Deposit = double.Parse(Console.ReadLine());
            currentUser.setBalance(Deposit + currentUser.getBalance());
            Console.WriteLine("Thank You for depositing your new balance is: " + currentUser.getBalance());
        }
        public static void withdrawl(CardHolder currentUser)
        {
            Console.WriteLine("Please Enter the amount to withdraw: ");
            double Withdrawl = double.Parse(Console.ReadLine());
            if (currentUser.getBalance() < Withdrawl)
            {
                Console.Write("Sorry Insufficient Balance: ");
                Console.WriteLine(currentUser.getBalance());
            }
            else
            {
                Console.WriteLine("Thank You for withdrawing, your new balance is: " + (currentUser.getBalance() - Withdrawl));
            }
        }

        public static void userBalance(CardHolder currentUser)
        {
            Console.WriteLine("Your account Balance is: " + currentUser.getBalance());
        }

        public static void Main(string[] args)
        {

            List<CardHolder> cardHolders = new List<CardHolder>();
            cardHolders.Add(new CardHolder("4929181116658913", 1234, "Wasif", "Nazir",800.23));
            cardHolders.Add(new CardHolder("4532304478499358", 6754, "Muhammad", "Mudassir", 900.46));
            cardHolders.Add(new CardHolder("4716724955122793", 0897, "Muhammad", "Osama",  1200.78));
            cardHolders.Add(new CardHolder("4556542661920687", 5546, "Muhammad", "Arsalan", 1000.23));
            cardHolders.Add(new CardHolder("4485079125525824", 3320, "Muhammad", "Hammad", 600.76));

            Console.WriteLine("Welcome to Simple_ATM");
            //Console.WriteLine("\n");
            Console.WriteLine("Please enter your debit Card Number");
            //Console.WriteLine("\n");
            CardHolder currentUser;
            string debitCardNum = "";

            while (true)
            {
                try
                {
                    debitCardNum = Console.ReadLine();
                    currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                    if (currentUser != null) { break; }
                    else { Console.WriteLine("Please Enter a Valid Card Number: "); }
                }
                catch
                {
                    { Console.WriteLine("Please Enter a Valid Card Number: "); }
                }
            }
            Console.WriteLine("Please Enter you ATM Pin");
            int userPin;
            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                    //Console.WriteLine(currentUser.getPin());
                    //userPin = currentUser.setPin(userPin);
                    if (currentUser.getPin() == userPin)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please Enter a valid Pin: ");
                    }
                }
                catch
                {
                    { Console.WriteLine("Please Enter a Valid Pin: "); }
                }
            }
            Console.WriteLine("\n");
            Console.WriteLine("Welcome " + currentUser.getfirstName() + " " + currentUser.getlastName());
            int options = 0;
            do
            {
                printOptions();
                try
                {
                    options = int.Parse(Console.ReadLine());
                }
                catch { }
                if (options == 1) { deposit(currentUser); }
                else if (options == 2) { withdrawl(currentUser); }
                else if (options == 3) { userBalance(currentUser); }
                else if (options == 4) { break; }
                else { options = 0; }
            }
            while (options != 4);
            {
                Console.WriteLine("Thank You have a Nice Day :)");

            }

        }
    }

    }


