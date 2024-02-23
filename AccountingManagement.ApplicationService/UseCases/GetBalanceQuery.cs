using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagement.ApplicationService.UseCases
{
    public class GetBalanceQuery : IRequest<decimal>
    {
        public long UserId { get; set; }
    }
}
