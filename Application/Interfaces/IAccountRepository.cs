using Bank.Domain.Entities;

namespace Application.Interfaces
{
    public interface IAccountRepository
    {
        BankAccount GetById(Guid id);
        BankAccount Create(string owner);
        void Save(BankAccount account);
    }
}