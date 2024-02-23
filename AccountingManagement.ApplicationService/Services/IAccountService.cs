using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AccountingManagement.ApplicationService.Services
{
    public interface IAccountService
    {
        Task<decimal> GetAccountBalanceAsync(string userId);
        Task<decimal> ChargeAccountAsync(string userId, decimal value);
        Task<IEnumerable<Transaction>> GetLastTransactionsAsync(long userId, int count);
    }
}
