using System.ComponentModel.DataAnnotations;

namespace BookStore_Web_Shop.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
       
        [Required]
        [MaxLength(70, ErrorMessage = "Il titolo può essere massimo 70 caratteri")]
        public string Title { get; set; }
        
        [Required]
        public string UrlImage { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public double Price { get; set; }
       
        [Required]
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
        
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

}
