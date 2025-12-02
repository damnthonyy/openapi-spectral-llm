using Application.Interfaces;
using Bank.Domain.Entities;
using Application.Dtos;

namespace Bank.Application.UseCases
{
    public class AccountUseCase(IAccountRepository repository) 
    {
        private readonly IAccountRepository _repository = repository;

        // Create a new account
        public AccountResponse Create(CreateAccountRequest request)
        {
            var account = _repository.Create(request.Owner);
            _repository.Save(account);
            return Map(account);
        }

        // Get an account by id
        public AccountResponse GetById(Guid id)
        {
            var account = _repository.GetById(id);
            return Map(account);
        }

        // Deposit money into an account
        public AccountResponse Deposit(Guid id, TransactionRequest request)
        {
            var account = _repository.GetById(id);
            account.Deposit(request.Amount);
            _repository.Save(account);
            return Map(account);
        }

        // Withdraw money from an account
        public AccountResponse Withdraw(Guid id, TransactionRequest request)
        {
            var account = _repository.GetById(id);
            account.Withdraw(request.Amount);
            _repository.Save(account);
            return Map(account);
        }

        // Get an account by id
        public AccountResponse Get(Guid id)
        {
            var account = _repository.GetById(id);
            return Map(account);
        }

        // Map a BankAccount to an AccountResponse
        private static AccountResponse Map(BankAccount account)
        {
            return new AccountResponse
            {
                Id = account.Id,
                Owner = account.Owner,
                Balance = account.Balance,
            };
        }
    }
}