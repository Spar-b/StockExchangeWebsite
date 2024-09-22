using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using StockExchangeWebsite.Data.Enums;

namespace StockExchangeWebsite.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public double Value { get; set; }
        public string LogoURL { get; set; }
        public int NumWorkers { get; set; }
        public string ContactPhone {  get; set; }
        public DateOnly FoundationDate { get; set; }
        public string RegistrationAddress {  get; set; }
        public Sector Sector { get; set; }
        public string Description { get; set; }

        //Relations
        public int TickerId { get; set; }
        [ForeignKey("TickerId")]
        public Ticker Ticker { get; set; }
    }
}
