using AccountingManagement.ApplicationService.Models;
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
    public class GetTransactionsQueryHandler : IRequestHandler<GetTransactionsQuery, List<TransactionModel>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ITransactionService _transactionService;

        public GetTransactionsQueryHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public async Task<List<TransactionModel>> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _transactionService.GetTransactionsByUserIdAsync(request.UserId);

            var transactionDTOs = transactions.Select(transaction => new TransactionModel
            {
                Id = transaction.UserID,
                Amount = transaction.Amount,
                Timestamp = transaction.Timestamp
            }).ToList();

            return transactionDTOs;
        }
    }
}