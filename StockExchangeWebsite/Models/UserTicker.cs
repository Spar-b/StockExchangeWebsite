namespace StockExchangeWebsite.Models
{
    public class UserTicker
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int TickerId { get; set; }
        public Ticker Ticker { get; set; }

        public int Amount { get; set; }
    }
}
