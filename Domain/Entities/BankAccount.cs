namespace Bank.Domain.Entities
{
    public class BankAccount
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Owner { get; private set; } = string.Empty;
        public decimal Balance { get; private set;}

        public List<string> History { get; private set; } = [];

        public BankAccount(string owner)
        {
            Owner = owner;
            Balance = 0;
            History.Add($"Account created for {owner}");
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0){
                new ArgumentException("Amount must be greater than 0");
            }
            Balance += amount;
            History.Add($"Deposited {amount} on {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}");
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0){
                new ArgumentException("Amount must be greater than 0");
            }
            if (amount > Balance){
                new ArgumentException("Insufficient funds");
            }
            Balance -= amount;
            History.Add($"Withdrawn {amount} on {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}");
        }

    }


}