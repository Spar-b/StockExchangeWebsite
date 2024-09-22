using StockExchangeWebsite.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace StockExchangeWebsite.Models
{
    public class StockMarket
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Currency { get; set; }
        public TimeSpan OpeningTime { get; set; }
        public TimeSpan ClosingTime { get; set; }
        public List<DayOfWeek> TradingDays { get; set; }
        public decimal Liquidity { get; set; }
        public decimal TransactionFee { get; set; }
        public decimal TickSize { get; set; }
        public decimal MarketCapitalization { get; set; }
        public List<OrderType> SupportedOrderTypes { get; set; }
        public int SettlementPeriod { get; set; }
        public float Volatility { get; set; }
        public string MarketIndex { get; set; }
        public int MinimumOrderSize { get; set; }
        public string RegulatoryAuthority { get; set; }
        public int MarketDepth { get; set; }
        public bool AllowsShortSelling { get; set; }
        public bool HasCircuitBreakers { get; set; }
        public decimal CircuitBreakerThreshold { get; set; }

        //Relations
        public List<StockMarketTicker> StockMarketTickers { get; set; }
    }
}
