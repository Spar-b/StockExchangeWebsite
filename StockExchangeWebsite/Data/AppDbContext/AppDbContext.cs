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

            modelBuilder.Entity<Company>().HasOne(c => c.Ticker).WithOne(t => t.Company).HasForeignKey<Company>(c => c.TickerId);
            modelBuilder.Entity<Ticker>().HasOne(t => t.Company).WithOne(c => c.Ticker).HasForeignKey<Ticker>(t => t.CompanyId);
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
