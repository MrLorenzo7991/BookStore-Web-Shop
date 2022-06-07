using BookStore_Web_Shop.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookStore_Web_Shop.Models
{
    public class SellLog
    {
        [Key]
        public int Id { get; set; } 
        public DateTime? Date { get; set; }
        [MoreThan0ValidationInt]
        public int Quantity { get; set; }
        [Required]
        public string Customer { get; set; }
        [Required]
        [MoreThan0Validation]
        public double Price { get; set; }

        public SellLog()
        {
        }
        public SellLog(DateTime date, int quantity, string customer, double price)
        {
            Date = date;
            Quantity = quantity;
            Customer = customer;
            Price = price;  
        }
        [JsonIgnore]
        public int BookId { get; set; }
        public Book? Book { get; set; }
    }
}
