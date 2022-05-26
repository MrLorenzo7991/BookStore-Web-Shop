namespace BookStore_Web_Shop.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UrlImage { get; set; }
        public string Description { get; set; } 
        public double Price { get; set; }
        public int Quantity { get; set; } = 0;
        public int NumberOfLikes { get; set; } = 0;

        public Book()
        {
        }

        public Book(string title, string urlImage, string description, double price, int numberOfLikes)
        {
            Title = title;
            UrlImage = urlImage;
            Description = description;
            Price = price;
            NumberOfLikes = numberOfLikes;
        }
    
    }

}
