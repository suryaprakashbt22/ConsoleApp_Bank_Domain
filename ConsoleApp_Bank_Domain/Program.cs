using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Bank_Domain
{
    internal class Program
    {
        public delegate void banking();
        static void Main(string[] args)
        {
            Account customer = new Account("SP", 121, 30);
            
            bool Loop = true;
            while (Loop)
            {
                Console.WriteLine("\t1.Withdraw\n\t2.Deposit\n\t3.View Balance\n\t4.Exit");
                Console.WriteLine("Enter your Choice::");
                int ch= int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        Console.WriteLine("Enter Amount to be withdrawn");
                        int amt= int.Parse(Console.ReadLine());
                        customer.withdrawBal(amt);
                        break;

                    case 2:
                        Console.WriteLine("Enter Amount to be deposited");
                        int amt1 = int.Parse(Console.ReadLine());
                        customer.depositBal(amt1);
                        Console.WriteLine("Updated");
                        break;

                    case 3:
                        customer.Display();
                        break;
                    case 4:
                        Loop = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Selection");
                        break;

                }
            }
        }
        public class Account
        {
            public int accountNo, balance;
            string customerName;
            
            public Account(string customerName, int accountNo, int balance)
            {
                this.accountNo = accountNo;
                this.balance = balance;
                this.customerName = customerName;
            }
            
            public event banking UnderBalance;
            public event banking BalanceZero;
            public void withdrawBal(int amount) 
            {
                //(amount <= this.balance) ? this.balance -= amount : UnderBalance();
                if (this.balance == 0)
                {
                    BalanceZero();
                }
                if (amount <= this.balance)
                {
                    this.balance-=amount;
                }
                else
                {
                    UnderBalance();
                }
            }
            public void depositBal(int amount)
            {
                this.balance += amount;
            }
            public void Display()
            {
                Console.WriteLine("Customer Name: {0}", customerName);
                Console.WriteLine("Account Number: {0}", accountNo);
                Console.WriteLine("Balance: {0}", balance);
            }

        }
    }
}

