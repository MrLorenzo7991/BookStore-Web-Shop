namespace BookStore_Web_Shop.Models
{
    public class SellLog
    {
        public DateTime Date { get; set; }
        public int Quantity { get; set; }   
        
        public SellLog()
        {
        }
        public SellLog(DateTime date, int quantity)
        {
            Date = date;
            Quantity = quantity;
        }
    }
}
