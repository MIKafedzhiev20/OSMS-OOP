namespace DAL
{
    public interface IDiscount
    {
        decimal ApplyDiscount(decimal amount);
    }

    public class PercentageDiscount : IDiscount
    {
        private readonly decimal _percentage;

        public PercentageDiscount(decimal percentage)
        {
            _percentage = percentage;
        }

        public decimal ApplyDiscount(decimal amount)
        {
            return amount - (amount * _percentage / 100);
        }
    }

    public class FixedDiscount : IDiscount
    {
        private readonly decimal _fixedAmount;

        public FixedDiscount(decimal fixedAmount)
        {
            _fixedAmount = fixedAmount;
        }

        public decimal ApplyDiscount(decimal amount)
        {
            return amount - _fixedAmount;
        }
    }
}
