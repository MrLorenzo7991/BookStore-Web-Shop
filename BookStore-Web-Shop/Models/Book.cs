using BookStore_Web_Shop.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        public string Author { get; set; }
        [Required]
        [Url]
        public string UrlImage { get; set; }
        
        [Required]
        [Column(TypeName="text")]
        public string Description { get; set; }
        
        [Required]
        [MoreThan0Validation]
        public double Price { get; set; }
       
        [Required]
      
        public int Quantity { get; set; }
      
        public int NumberOfLikes { get; set; } 

        public Book()
        {
        }

        public Book(string title, string author ,string urlImage, string description, double price, int numberOfLikes)
        {
            Title = title;
            Author = author;
            UrlImage = urlImage;
            Description = description;
            Price = price;
            NumberOfLikes = numberOfLikes;
            Quantity = 0;
            NumberOfLikes = 0;
        }
        //1-n category
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        //1-n Order
        [JsonIgnore]
        public List<OrderLog>? OrderLogs { get; set; }
        //1-n Sell
        [JsonIgnore]
        public List<SellLog>? SellLogs { get; set; }
    }

}
