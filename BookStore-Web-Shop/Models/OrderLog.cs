using BookStore_Web_Shop.Validation;

namespace BookStore_Web_Shop.Models
{
    public class OrderLog
    {
        [key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [MoreThan0Validation]
        public int Quantity { get; set; }

        public OrderLog()
        {
        }
        public OrderLog(DateTime date, int quantity)
        {
            Date = date;
            Quantity = quantity;
        }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
