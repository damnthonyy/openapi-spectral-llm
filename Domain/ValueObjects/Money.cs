namespace Bank.Domain.ValueObjects
{
    public record Money(decimal Amount, string Currency)
    {
        public static Money Create(decimal amount, string currency ="EUR")
        {
            if (amount <= 0)
            {
                throw new ArgumentException("amount must be greater than 0");
            }
            if(string.IsNullOrEmpty(currency))
            {
                throw new ArgumentException("currency is required");
            }
            return new Money(amount, currency);
    
        }
        public static Money Zero(string currency ="EUR")
        {
            if(string.IsNullOrEmpty(currency))
            {
                throw new ArgumentException("currency is required");
            }
            return new Money(decimal.Zero, currency);
        }
        public Money Add(Money other)
        {
            if(Currency != other.Currency)
            {
                throw new ArgumentException("currencies must be the same");
            }
            return new Money(Amount + other.Amount, Currency);
        }
        public Money Subtract(Money other)
        {
            if(Currency != other.Currency)
            {
                throw new ArgumentException("currencies must be the same");
            }
            return new Money(Amount - other.Amount, Currency);
        }

        public bool IsPositive()
        {
            return Amount > 0;
        }
    }
}