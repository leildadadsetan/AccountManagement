using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagement.ApplicationService.Queries
{
    public class GetBalanceQuery : IRequest<decimal>
    {
        public string UserId { get; }

        public GetBalanceQuery(string userId)
        {
            UserId = userId;
        }
    }
}
