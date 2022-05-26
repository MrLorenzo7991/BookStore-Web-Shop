using BookStore_Web_Shop.Data;
using BookStore_Web_Shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_Web_Shop.Controllers
{
    public class BookController : Controller
    {
        [HttpGet]
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
        
        [HttpGet]
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

        [HttpGet]
        public IActionResult Create()
        {

            using (BookStoreContext db = new BookStoreContext())
            {
               
                Book book = new();
                List<Category> categories = db.Categories.ToList();

                BookCategories model = new(book, categories);

                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Create(BookCategories data)
        {
            if (!ModelState.IsValid)
            {
                using (BookStoreContext db = new BookStoreContext())
                {
                    data.Book = new Book();
                    data.Categories = data.Categories.ToList();

                    return View("Create",data);
                }
            }

            using (BookStoreContext db = new BookStoreContext())
            {
                Book bookToCreate = new();
                bookToCreate.Title = data.Book.Title;
                bookToCreate.Price = data.Book.Price;
                bookToCreate.Description = data.Book.Description;
                bookToCreate.CategoryId = data.Book.CategoryId;
                bookToCreate.UrlImage = data.Book.UrlImage;
            }

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            using(BookStoreContext db = new BookStoreContext())
            {
                Book? bookToRemove = db.Books.Find(id);
                if(bookToRemove != null)
                {
                    db.Books.Remove(bookToRemove);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Book");
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }
}
