using AccountingManagement.Domain.Entities;
using AccountingManagement.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingManagement.Infrastructure.Data;
using MongoDB.Driver;

namespace AccountingManagement.Infrastructure.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IMongoDbContext _dbContext;

        public AccountRepository(IMongoDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<User> GetUserById(string userId)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Id, userId);
            return await _dbContext.Users.Find(filter).FirstOrDefaultAsync();
        }


        public async Task UpdateUser(User user)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Id, user.Id);
            await _dbContext.Users.ReplaceOneAsync(filter, user);
        }
 
    }
}