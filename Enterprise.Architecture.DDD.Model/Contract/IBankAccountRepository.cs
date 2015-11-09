using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Architecture.DDD.Model.Contract
{
    public interface IBankAccountRepository
    {
        void Add(BankAccount bankAccount);
        void Save(BankAccount bankAccount);
        IEnumerable<BankAccount> FindAll();
        BankAccount FindBy(Guid AccountId);
    }
}
