using AppInterface = Application.Interfaces;
using Bank.Domain.Entities;
using Application.Dtos;
using Bank.Domain.ValueObjects;

namespace Bank.Application.UseCases
{
    public class AccountUseCase(AppInterface.IAccountRepository repository) 
    {
        private readonly AppInterface.IAccountRepository _repository = repository;

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
            account.Deposit(Money.Create(request.Amount, account.Balance.Currency));
            _repository.Save(account);
            return Map(account);
        }

        // Withdraw money from an account
        public AccountResponse Withdraw(Guid id, TransactionRequest request)
        {
            var account = _repository.GetById(id);
            account.Withdraw(Money.Create(request.Amount, account.Balance.Currency));
            _repository.Save(account);
            return Map(account);
        }

        // Map a BankAccount to an AccountResponse
        private static AccountResponse Map(BankAccount account)
        {
            return new AccountResponse
            {
                Id = account.Id,
                Owner = account.Owner,
                Balance = account.Balance.Amount,
                History = account.History,
            };
        }
    }
}