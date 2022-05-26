namespace BookStore_Web_Shop.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Category()
        {
        }

        public Category(string name)
        {
            Name = name;
        }
        public List <Book> books { get; set; }
    }
}
