namespace BookStore_Web_Shop.Models
{
    public class BookCategories
    {
        public Book Book { get; set; }
        public List<Category> Categories { get; set; }

        public BookCategories(Book book, List<Category> categories)
        {
            Book = book;
            Categories = categories;
        }
        public BookCategories() { }
    }
}
