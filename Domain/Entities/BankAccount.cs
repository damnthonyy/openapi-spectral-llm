using Bank.Domain.ValueObjects;
namespace Bank.Domain.Entities
{
    public class BankAccount
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Owner { get; private set; } = string.Empty;
        public Money Balance { get; private set;}

        public List<string> History { get; private set; } = [];

        public BankAccount(string owner)
        {
            Owner = owner;
            Balance = Money.Zero("EUR");
            History.Add($"Account created for {owner}");
        }

        public void Deposit(Money amount)
        {
            Balance = Balance.Add(amount);
            History.Add($"Deposited {amount.Amount} {amount.Currency} on {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}");
        }
        
        // Withdraw money from the account
        public void Withdraw(Money amount)
        {
            if(Balance.Amount < amount.Amount)
            {
                throw new ArgumentException("Insufficient funds");
            }
            Balance = Balance.Subtract(amount);
            History.Add($"Withdrawn {amount.Amount} {amount.Currency} on {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}");
        }

    }


}