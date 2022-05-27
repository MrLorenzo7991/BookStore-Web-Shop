using BookStore_Web_Shop.Validation;
using System.ComponentModel.DataAnnotations;

namespace BookStore_Web_Shop.Models
{
    public class SellLog
    {
        [Key]
        public string Id { get; set; } 
        public DateTime Date { get; set; }
        [MoreThan0Validation]
        public int Quantity { get; set; }
        [Required]
        public string Customer { get; set; }
        
        public SellLog()
        {
        }
        public SellLog(DateTime date, int quantity, string customer)
        {
            Date = date;
            Quantity = quantity;
            Customer = Customer;
        }
        
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
