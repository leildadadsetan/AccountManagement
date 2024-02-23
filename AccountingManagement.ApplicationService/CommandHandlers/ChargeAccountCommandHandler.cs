using AccountingManagement.ApplicationService.Commands;
using AccountingManagement.ApplicationService.Services;
using AccountingManagement.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagement.ApplicationService.CommandHandlers
{
    public class ChargeAccountCommandHandler : IRequestHandler<ChargeAccountCommand, decimal>
    {
        private readonly IAccountService  _accountService;

        public ChargeAccountCommandHandler(IAccountService userService)
        {
            _accountService = userService;
        }
        public async Task<decimal> Handle(ChargeAccountCommand request, CancellationToken cancellationToken)
        {
            return await _accountService.ChargeAccountAsync(request.UserId, request.Amount);

        }
    }
}
