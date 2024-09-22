using System.ComponentModel.DataAnnotations;

namespace StockExchangeWebsite.Models
{
    public class Ticker
    {
        [Key]
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Symbol { get; set; }
        public double CurrentValue { get; set; }
        public double OpenValue { get; set; }
        public double CloseValue { get; set; }
        public double TradingVolume { get; set; }
    }
}
