using StockExchangeWebsite.Data.AppDbContext;
using StockExchangeWebsite.Data.Enums;
using StockExchangeWebsite.Models;

public class AppDbInitializer
{
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

            context.Database.EnsureCreated();

            // Step 1: Insert companies
            if (!context.Companies.Any())
            {
                context.Companies.AddRange(new List<Company>()
                {
                    new Company()
                    {
                        Value = 2740.80,
                        LogoURL = "https://example.com/logos/apple.png",
                        NumWorkers = 147000,
                        ContactPhone = "+1-800-MY-APPLE",
                        FoundationDate = new DateOnly(1976, 4, 1),
                        RegistrationAddress = "1 Apple Park Way, Cupertino, CA, USA",
                        Sector = Sector.Computer_and_Technology,
                        Description = "Apple Inc. is an American multinational technology company that specializes in consumer electronics, software, and online services."
                    },
                    new Company()
                    {
                        Value = 1950.20,
                        LogoURL = "https://example.com/logos/google.png",
                        NumWorkers = 156500,
                        ContactPhone = "+1-650-253-0000",
                        FoundationDate = new DateOnly(1998, 9, 4),
                        RegistrationAddress = "1600 Amphitheatre Parkway, Mountain View, CA, USA",
                        Sector = Sector.Computer_and_Technology,
                        Description = "Alphabet Inc. is the parent company of Google and several other subsidiaries, focusing on online services and technology."
                    },
                    new Company()
                    {
                        Value = 848.55,
                        LogoURL = "https://example.com/logos/tesla.png",
                        NumWorkers = 110000,
                        ContactPhone = "+1-800-613-8840",
                        FoundationDate = new DateOnly(2003, 7, 1),
                        RegistrationAddress = "3500 Deer Creek Road, Palo Alto, CA, USA",
                        Sector = Sector.Auto,
                        Description = "Tesla Inc. is an American electric vehicle and clean energy company."
                    }
                });

                context.SaveChanges();
            }

            // Step 2: Insert tickers
            if (!context.Tickers.Any())
            {
                context.Tickers.AddRange(new List<Ticker>()
                {
                    new Ticker()
                    {
                        Symbol = "AAPL",
                        CurrentValue = 150.10,
                        OpenValue = 148.20,
                        CloseValue = 149.30,
                        TradingVolume = 1000000,
                        CompanyId = context.Companies.First(c => c.LogoURL.Contains("apple")).Id
                    },
                    new Ticker()
                    {
                        Symbol = "GOOGL",
                        CurrentValue = 2800.55,
                        OpenValue = 2785.30,
                        CloseValue = 2799.40,
                        TradingVolume = 750000,
                        CompanyId = context.Companies.First(c => c.LogoURL.Contains("google")).Id
                    },
                    new Ticker()
                    {
                        Symbol = "TSLA",
                        CurrentValue = 730.50,
                        OpenValue = 720.25,
                        CloseValue = 725.00,
                        TradingVolume = 500000,
                        CompanyId = context.Companies.First(c => c.LogoURL.Contains("tesla")).Id
                    }
                });

                context.SaveChanges();
            }

            // Step 3: Insert users
            if (!context.Users.Any())
            {
                context.Users.AddRange(new List<User>()
                {
                    new User()
                    {
                        Username = "john_doe",
                        Password = "password123", // Make sure to hash passwords in production
                        Email = "john.doe@example.com"
                    },
                    new User()
                    {
                        Username = "jane_smith",
                        Password = "password456",
                        Email = "jane.smith@example.com"
                    }
                });

                context.SaveChanges();
            }

            // Step 4: Insert UserTickers
            if (!context.UserTickers.Any())
            {
                var userJohn = context.Users.First(u => u.Username == "john_doe");
                var userJane = context.Users.First(u => u.Username == "jane_smith");
                var tickerAAPL = context.Tickers.First(t => t.Symbol == "AAPL");
                var tickerGOOGL = context.Tickers.First(t => t.Symbol == "GOOGL");

                context.UserTickers.AddRange(new List<UserTicker>()
                {
                    new UserTicker()
                    {
                        UserId = userJohn.Id,
                        TickerId = tickerAAPL.Id,
                        Amount = 10
                    },
                    new UserTicker()
                    {
                        UserId = userJane.Id,
                        TickerId = tickerGOOGL.Id,
                        Amount = 15
                    }
                });

                context.SaveChanges();
            }
        }
    }
}
