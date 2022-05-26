namespace BookStore_Web_Shop.Models
{
    public class BooksCategories
    {
        public List<Book> Books { get; set; }
        public List<Category> Categories { get; set; }

        public BooksCategories(List<Book> books, List<Category> categories)
        {
            Books = books;
            Categories = categories;
        }
         public BooksCategories() { }
    }
}
