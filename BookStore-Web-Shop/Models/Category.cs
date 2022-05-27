using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookStore_Web_Shop.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage ="Il nome della categoria non può superare i 50 caratteri")]
        public string Name { get; set; }

        public Category()
        {
        }

        public Category(string name)
        {
            Name = name;
        }
        [JsonIgnore]
        public List <Book> books { get; set; }
    }
}
