using BookStore_Web_Shop.Validation;
using System.ComponentModel.DataAnnotations;

namespace BookStore_Web_Shop.Models
{
    public class OrderLog
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Required]
        [MoreThan0Validation]
        public int Quantity { get; set; }
        [Required]
        [NotEmpty]
        public string Supplier { get; set; }
        [Required]
        [MoreThan0Validation]
        public double Price { get; set; }

        public OrderLog()
        {
        }
        public OrderLog(DateTime date, int quantity, string supplier, double price)
        {
            Date = date;
            Quantity = quantity;
            Supplier = supplier;
            Price = price;
        }

        public int BookId { get; set; }
        public Book? Book { get; set; }
    }
}
