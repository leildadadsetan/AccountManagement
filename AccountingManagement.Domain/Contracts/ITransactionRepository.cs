using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AccountingManagement.Domain.Entities;
using Transaction = AccountingManagement.Domain.Entities.Transaction;

namespace AccountingManagement.Domain.Contracts
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetTransactionsByUserIdAsync(string userId, int limit = 10);
        Task AddTransactionAsync(Transaction transaction);
        // Add other methods as needed
    }
}
