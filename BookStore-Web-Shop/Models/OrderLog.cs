namespace BookStore_Web_Shop.Models
{
    public class OrderLog
    {
        public DateTime Date { get; set; }
        public int Quantity { get; set; }

        public OrderLog()
        {
        }
        public OrderLog(DateTime date, int quantity)
        {
            Date = date;
            Quantity = quantity;
        }
    }
}
