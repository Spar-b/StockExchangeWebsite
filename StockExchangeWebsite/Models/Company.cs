using System.ComponentModel.DataAnnotations;

namespace StockExchangeWebsite.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public int TickerId { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public int NumWorkers { get; set; }
        public string ContactPhone {  get; set; }
        public DateOnly FoundationDate { get; set; }
        public string RegistrationAddress {  get; set; }
        public string Description { get; set; }

    }
}
