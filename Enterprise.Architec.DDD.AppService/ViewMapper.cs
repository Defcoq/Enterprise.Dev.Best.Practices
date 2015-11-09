using Enterprise.Architec.DDD.AppService.ViewModels;
using Enterprise.Architecture.DDD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Architec.DDD.AppService
{
    public class ViewMapper
    {
        public static TransactionView CreateTransactionViewFrom(Transaction tran)
        {
            return new TransactionView
            {
                Deposit = tran.Deposit.ToString("C"),
                Withdrawal = tran.Withdrawal.ToString("C"),
                Reference = tran.Reference,
                Date = tran.Date
            };
        }

        public static BankAccountView CreateBankAccountViewFrom(BankAccount acc)
        {
            return new BankAccountView
            {
                AccountNo = acc.AccountNo,
                Balance = acc.Balance.ToString("C"),
                CustomerRef = acc.CustomerRef,
                Transactions = new List<TransactionView>()
            };
        }
    }
}
