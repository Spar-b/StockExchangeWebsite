using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockExchangeWebsite.Models
{
    public class Ticker
    {
        [Key]
        public int Id { get; set; }
        public string Symbol { get; set; }
        public double CurrentValue { get; set; }
        public double OpenValue { get; set; }
        public double CloseValue { get; set; }
        public double TradingVolume { get; set; }

        //Relations
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public List<StockMarketTicker> StockMarketTickers { get; set; }
    }
}
