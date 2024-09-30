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
        public double Liquidity { get; set; }
        public double TransactionFee { get; set; }
        public double TickSize { get; set; }
        public double MarketCapitalization { get; set; }
        public List<OrderType> SupportedOrderTypes { get; set; }
        public int SettlementPeriod { get; set; }
        public float Volatility { get; set; }
        public string MarketIndex { get; set; }
        public int MinimumOrderSize { get; set; }
        public string RegulatoryAuthority { get; set; }
        public int MarketDepth { get; set; }
        public bool AllowsShortSelling { get; set; }
        public bool HasCircuitBreakers { get; set; }
        public double CircuitBreakerThreshold { get; set; }

        //Relations
        public List<StockMarketTicker> StockMarketTickers { get; set; }
    }
}
