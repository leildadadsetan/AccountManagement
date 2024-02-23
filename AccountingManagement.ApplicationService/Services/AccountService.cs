using AccountingManagement.Domain.Contracts;
using AccountingManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingManagement.Domain.Entities;

namespace AccountingManagement.ApplicationService.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;

        public AccountService(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
        }

        public async Task<decimal> GetAccountBalanceAsync(string userId)
        {
            var user = await _accountRepository.GetUserById(userId);
            if (user == null)
            {
                throw new ArgumentException($"User with ID '{userId}' not found.");
            }

            return user.Balance;
        }

        public async Task<decimal> ChargeAccountAsync(string userId, decimal value)
        {
            var user = await _accountRepository.GetUserById(userId);

             if (user == null)
            {
                throw new ArgumentException($"User with ID '{userId}' not found.");
            }


            user.Balance += value;
            await _accountRepository.UpdateUser(user);

            var transaction = new Transaction
            {
                UserID = userId,
                Amount = value,
                 Timestamp = DateTime.UtcNow
            };
            await _transactionRepository.AddTransactionAsync(transaction);

            return user.Balance;
        }

        public async Task<IEnumerable<Transaction>> GetLastTransactionsAsync(string userId, int count)
        {
            return await _transactionRepository.GetTransactionsByUserIdAsync(userId, count);
        }

        Task<IEnumerable<System.Transactions.Transaction>> IAccountService.GetLastTransactionsAsync(long userId, int count)
        {
            throw new NotImplementedException();
        }
    }
}