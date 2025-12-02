using Microsoft.AspNetCore.Mvc;
using Bank.Application.UseCases;
using Application.Dtos;

namespace Bank.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController(AccountUseCase useCase) : ControllerBase
    {
        private readonly AccountUseCase _useCase = useCase;

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateAccountRequest request)
        {
            return Ok(_useCase.Create(request));
        }

        [HttpPost("{id}/deposit")]
        public IActionResult Deposit(Guid id, [FromBody] TransactionRequest request)
        {
            return Ok(_useCase.Deposit(id, request));
        }
        
        [HttpPost("{id}/withdraw")]
        public IActionResult Withdraw(Guid id, [FromBody] TransactionRequest request)
        {
            return Ok(_useCase.Withdraw(id, request));
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_useCase.Get(id));
        }
    }
}