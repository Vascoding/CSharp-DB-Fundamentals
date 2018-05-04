


namespace BankSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    public class CheckingAccount
    {
        [Key]
        public int Id { get; set; }

        public string AccountNumber { get; set; }

        public decimal Balance { get; set; }

        public decimal Fee { get; set; }

        public static void DepositMoney(BankSystemContext context, string accountNumber, decimal money)
        {
            var acc = context.CheckingAccounts.First(a => a.AccountNumber == accountNumber);
           
            acc.Balance += money;
            context.SaveChanges();
        }

        public static void WithdrawMoney(BankSystemContext context, string accountNumber, decimal money)
        {
            var acc = context.CheckingAccounts.First(a => a.AccountNumber == accountNumber);
            var total = money - acc.Fee;
            if (acc.Balance < total)
            {
                throw new ArgumentException("There is not enough money in the account !");
            }
            
            acc.Balance -= total;
            context.SaveChanges();
        }
    }
}
