using System;
using System.Text;
using System.Collections.Generic;



public class Program
{
    static void Main(string[] args)
    {
        //BankAccount bc = new BankAccount();
        //bc.Id = 1;
        ////bc.Balance = 15;
        ////Console.WriteLine($"Account {bc.Id}, balance {bc.Balance}");
        //bc.Deposit(15);
        //bc.Withdraw(10);
        //Console.WriteLine(bc);
        Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();
        var @params = Console.ReadLine();
        while (@params != "End")
        {
            var tokens = @params.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var command = tokens[0];
            int accountId = int.Parse(tokens[1]);
            decimal amount = 0;
            switch (command)
            {
                case "Deposit":
                    amount = decimal.Parse(tokens[2]);
                    if (!accounts.ContainsKey(accountId))
                    {
                        Console.WriteLine("Account does not exist");
                    }
                    else
                    {
                        accounts[accountId].Deposit(amount);
                    }
                    break;
                case "Withdraw":
                    amount = decimal.Parse(tokens[2]);
                    if (!accounts.ContainsKey(accountId))
                    {
                        Console.WriteLine("Account does not exist");
                    }
                    else
                    {
                        if (accounts[accountId].Balance < amount)
                        {
                            Console.WriteLine("Insufficient balance");
                        }
                        else
                        {
                            accounts[accountId].Withdraw(amount);
                        }
                    }
                    break;

                case "Create":
                    if (!accounts.ContainsKey(accountId))
                    {
                        var bc = new BankAccount();
                        bc.Id = accountId;
                        accounts.Add(accountId, bc);
                    }
                    else
                    {
                        Console.WriteLine("Account already exists");
                    }
                    break;
                case "Print":
                    if (!accounts.ContainsKey(accountId))
                    {
                        Console.WriteLine("Account does not exist");
                    }
                    else
                    {
                        Console.WriteLine(accounts[accountId].ToString());
                    }
                    break;
                default:
                    break;
            }
            @params = Console.ReadLine();
        }
    }
}