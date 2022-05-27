using BookStore_Web_Shop.Data;
using BookStore_Web_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

                //BooksCategories booksCategories = new(books,categories);

                return View("ViewAdmin",books);
            }
        }
        
        [HttpGet]
        public IActionResult Details(int id)
        {
            using(BookStoreContext db = new BookStoreContext())
            {
                Book? book = db.Books.Where(book => book.Id == id).Include(book => book.Category).FirstOrDefault();
                if (book != null)
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

                return View("AddBook",model);
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(BookCategories data)
        {
            if (!ModelState.IsValid)
            {
                using (BookStoreContext db = new BookStoreContext())
                {

                    data.Categories = db.Categories.ToList();

                    return View("AddBook",data);
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
                bookToCreate.Quantity = data.Book.Quantity;
                bookToCreate.NumberOfLikes = data.Book.NumberOfLikes;
                
                db.Books.Add(bookToCreate); 
                db.SaveChanges();
            }

            return RedirectToAction("Index");
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

        [HttpGet]
        public IActionResult Update(int id)
        {
            Book? bookToEdit = new();
            List<Category> categories = new List<Category>();

            using(BookStoreContext db = new BookStoreContext())
            {
                categories = db.Categories.ToList();
                bookToEdit = db.Books.Where(book => book.Id == id).FirstOrDefault();
            }

            if(bookToEdit != null)
            {
                BookCategories bookCategoriesToEdit = new();
                bookCategoriesToEdit.Categories = categories;
                bookCategoriesToEdit.Book = bookToEdit;
                return View("Edit", bookCategoriesToEdit);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Update(int id,BookCategories model)
        {
            if(!ModelState.IsValid)
            {
                using(BookStoreContext db = new BookStoreContext())
                {
                    model.Categories = db.Categories.ToList();
                }
                return View("Edit",model);
            }

            Book? bookToEdit = new();

            using(BookStoreContext db = new BookStoreContext())
            {
                bookToEdit = db.Books.Where(book => book.Id==id).FirstOrDefault();

                if(bookToEdit != null)
                {
                    bookToEdit.Title = model.Book.Title;
                    bookToEdit.Description = model.Book.Description;
                    bookToEdit.Price = model.Book.Price;
                    bookToEdit.CategoryId = model.Book.CategoryId;
                    bookToEdit.UrlImage = model.Book.Title;
                    bookToEdit.Quantity = model.Book.Quantity;
                    bookToEdit.NumberOfLikes = model.Book.NumberOfLikes;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }
}
