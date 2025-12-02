using Application.Interfaces;
using Bank.Domain.Entities;

namespace Bank.Infrastructure.Repositories
{
    public class InMemoryAccountRepository : IAccountRepository
    {
        private readonly List<BankAccount> _accounts = [];

        public BankAccount GetById(Guid id)
        {
            return _accounts.FirstOrDefault(a => a.Id == id) ?? throw new Exception("Account not found");
        }

        public BankAccount Create(string owner)
        {
            var account = new BankAccount(owner);
            return account;
        }

        public void Save(BankAccount account)
        {
            _accounts.Add(account);
        }
    }
    

}