using AccountingManagement.ApplicationService.Commands;
using AccountingManagement.ApplicationService.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccountingManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId}/balance")]
        public async Task<IActionResult> GetBalance(string userId)
        {
            var query = new GetBalanceQuery(userId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("{userId}/charge")]
        public async Task<IActionResult> ChargeAccount(string userId, [FromBody] ChargeAccountCommand command)
        {
            command.UserId = userId;
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{userId}/transactions")]
        public async Task<IActionResult> GetTransactions(string userId)
        {
            var query = new GetTransactionsQuery(userId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}