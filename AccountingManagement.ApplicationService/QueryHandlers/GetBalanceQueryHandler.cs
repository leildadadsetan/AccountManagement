using AccountingManagement.ApplicationService.Queries;
using AccountingManagement.ApplicationService.Services;
using AccountingManagement.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagement.ApplicationService.QueryHandlers
{
    public class GetBalanceQueryHandler : IRequestHandler<GetBalanceQuery, decimal>
    {
        private readonly IAccountService _accountService;
        public GetBalanceQueryHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<decimal> Handle(GetBalanceQuery request, CancellationToken cancellationToken)
        {
            return await _accountService.GetAccountBalanceAsync(request.UserId);

        }
    }
   
}
