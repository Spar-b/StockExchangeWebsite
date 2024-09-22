using Microsoft.EntityFrameworkCore;
using StockExchangeWebsite.Models;

namespace StockExchangeWebsite.Data.AppDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockMarketTicker>().HasKey(smt => new
            {
                smt.StockMarketId,
                smt.TickerId
            });

            modelBuilder.Entity<StockMarketTicker>().HasOne(sm => sm.StockMarket).WithMany(smt => smt.StockMarketTickers).HasForeignKey(sm => sm.StockMarketId);
            modelBuilder.Entity<StockMarketTicker>().HasOne(t => t.Ticker).WithMany(smt => smt.StockMarketTickers).HasForeignKey(t => t.TickerId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Ticker> Tickers { get; set; }
        public DbSet<Company> Companies { get; set; }

        public DbSet<StockMarket> StockMarkets { get; set; }
        public DbSet<StockMarketTicker> StockMarketTickers { get; set; }
    }
}
