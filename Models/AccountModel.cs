using System;

namespace bank_dio.Models
{
    public class AccountModel
    {
        private AccountTypeModel AccountType { get; set; }
        private string Name { get; set; }
        private double Balance { get; set; }
        private double Credit { get; set; }

    public AccountModel(AccountTypeModel accountTypeModel, string name, double balance, double credit)
    {
        this.AccountType = accountTypeModel;
        this.Name = name;
        this.Balance = balance;
        this.Credit = credit;
    }

    public bool Withdraw(double withdrawValue)
    {
        if (this.Credit - withdrawValue < (this.Credit *-1))
        {
        Console.WriteLine("Insufficient funds!");
        return false;
        }
        this.Balance -= withdrawValue;
        Console.WriteLine("{0}, Your current balance is: {1}", this.Name, this.Balance);
        return true;
    }

    public void Deposit(double depositValue)
    {
        this.Balance += depositValue;
        Console.WriteLine("{0}, Your current balance is: {1}", this.Name, this.Balance);
    }

    public void Transfer(double transferenceValue, AccountModel toAccount)
    {
        if (this.Withdraw(transferenceValue))
        toAccount.Deposit(transferenceValue);
    }

    public override string ToString()
    {
        string ret = "";
        ret += "Account Type: " + this.AccountType + " | ";
        ret += "Name: " + this.Name + " | ";
        ret += "Balance: " + this.Balance + " | ";
        ret += "Credit: " + this.Credit + " | ";
        return ret;
    }

    }
    
}