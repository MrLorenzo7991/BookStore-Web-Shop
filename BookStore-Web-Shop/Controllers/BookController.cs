using BookStore_Web_Shop.Data;
using BookStore_Web_Shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_Web_Shop.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            using(BookStoreContext db = new BookStoreContext())
            {
                List<Book> books = db.Books.ToList();
                List<Category> categories = db.Categories.ToList();

                BooksCategories booksCategories = new(books,categories);

                return View("ViewAdmin",booksCategories);
            }
        }

        public IActionResult Details(int id)
        {
            using(BookStoreContext db = new BookStoreContext())
            {
                Book book = db.Books.Find(id);

                if(book != null)
                {
                    return View(book);
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }
}
