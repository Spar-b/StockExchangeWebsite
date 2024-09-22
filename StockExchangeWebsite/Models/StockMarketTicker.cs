using System.ComponentModel.DataAnnotations.Schema;

namespace StockExchangeWebsite.Models
{
    public class StockMarketTicker
    {
        public int StockMarketId { get; set; }
        public StockMarket StockMarket { get; set; }

        public int TickerId { get; set; }
        public Ticker Ticker { get; set; }
    }
}
