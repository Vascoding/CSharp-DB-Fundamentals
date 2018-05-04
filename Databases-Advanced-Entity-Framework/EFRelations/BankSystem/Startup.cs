
using System.Data.Entity.Migrations;
using BankSystem.Models;

namespace BankSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class Startup
    {
        static void Main(string[] args)
        {
            BankSystemContext context = new BankSystemContext();

            CheckingAccount checkingAccount = new CheckingAccount();
            checkingAccount.Balance = 200m;
            checkingAccount.AccountNumber = "BG123";
            checkingAccount.Fee = 2.50m;
            context.CheckingAccounts.Add(checkingAccount);
            context.SaveChanges();

            SavingAccount savingAccount = new SavingAccount();
            savingAccount.Balance = 200m;
            savingAccount.AccountNumber = "BG123";
            savingAccount.InterestRate = 2.50m;
            context.SavingAccounts.Add(savingAccount);
            context.SaveChanges();

            // Deposit money into SavingAccount balance
            //SavingAccount.DepositMoney(context, "BG123", 25m);

            // Withdraw money from SavingAccount balance
            //SavingAccount.WithdrawMoney(context, "BG123", 50m);

            // Deposit money into CheckingAccount balance
            //CheckingAccount.DepositMoney(context, "BG123", 25m);

            // Withdraw money from CheckingAccount balance
            //CheckingAccount.WithdrawMoney(context, "BG123", 50m);


        }
    }
}
