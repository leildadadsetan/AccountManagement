using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagement.ApplicationService.UseCases
{
    public class ChargeAccountCommand : IRequest<decimal>
    {
        public long UserId { get; set; }
        public decimal Amount { get; set; }
    }
}
