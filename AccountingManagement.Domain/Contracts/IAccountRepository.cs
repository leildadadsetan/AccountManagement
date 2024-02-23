using AccountingManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagement.Domain.Contracts
{
    public interface IAccountRepository
    {
        Task<User> GetUserById(string userId);
        Task UpdateUser(User user);
    }
}
