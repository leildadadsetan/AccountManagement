using AccountingManagement.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AccountingManagement.Domain.Entities;
using Transaction = AccountingManagement.Domain.Entities.Transaction;

namespace AccountingManagement.ApplicationService.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByUserIdAsync(string userId, int limit = 10)
        {
            return await _transactionRepository.GetTransactionsByUserIdAsync(userId, limit);
        }

        //public async Task AddTransactionAsync(Transaction transaction)
        //{
        //    await _transactionRepository.AddTransactionAsync(transaction);
        //}

    }
}