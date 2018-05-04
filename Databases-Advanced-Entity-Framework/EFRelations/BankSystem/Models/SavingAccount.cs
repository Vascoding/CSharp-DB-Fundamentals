


namespace BankSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    public class SavingAccount
    {
        [Key]
        public int Id { get; set; }

        public string AccountNumber { get; set; }

        public decimal Balance { get; set; }

        public decimal InterestRate { get; set; }


        public static void DepositMoney(BankSystemContext context, string accountNumber, decimal money)
        {
            var acc = context.SavingAccounts.First(a => a.AccountNumber == accountNumber);
            money *= acc.InterestRate;
            acc.Balance += money;
            context.SaveChanges();  
        }

        public static void WithdrawMoney(BankSystemContext context, string accountNumber, decimal money)
        {
            var acc = context.SavingAccounts.First(a => a.AccountNumber == accountNumber);
            if (acc.Balance < money)
            {
                throw new ArgumentException("There is not enough money in the account !");
            }
            acc.Balance -= money;
            context.SaveChanges();
        }
            
        
    }
}
