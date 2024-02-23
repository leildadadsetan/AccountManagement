using AccountingManagement.Domain.Contracts;
using AccountingManagement.Domain.Entities;
using AccountingManagement.Infrastructure.Data;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Transaction = AccountingManagement.Domain.Entities.Transaction;

namespace AccountingManagement.Infrastructure.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IMongoCollection<Transaction> _transactionCollection;

        public TransactionRepository(IMongoDbContext dbContext)
        {
            _transactionCollection = dbContext.Transactions;
        }

        public async Task<IEnumerable<Domain.Entities.Transaction>> GetTransactionsByUserIdAsync(string userId, int limit = 10)
        {
            var filter = Builders<Transaction>.Filter.Eq(x => x.UserID, userId);
            var sort = Builders<Transaction>.Sort.Descending(x => x.Timestamp);
            var transactions = await _transactionCollection.Find(filter).Sort(sort).Limit(limit).ToListAsync();
            return transactions;
        }

        public async Task AddTransactionAsync(Transaction transaction)
        {
            await _transactionCollection.InsertOneAsync(transaction);
        }

    }
}