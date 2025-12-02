namespace Application.Dtos
{
    public class AccountResponse
    {
        public Guid Id { get; set; }
        public string Owner { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public List<string> History { get; set; } = [];
    }
}