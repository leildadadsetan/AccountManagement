using AccountingManagement.ApplicationService.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagement.ApplicationService.UseCases
{
    public class GetTransactionsQuery : IRequest<List<TransactionModel>>
    {
        public long UserId { get; set; }
    }
}
