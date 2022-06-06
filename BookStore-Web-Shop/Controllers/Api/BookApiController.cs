using BookStore_Web_Shop.Data;
using BookStore_Web_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore_Web_Shop.Controllers.Api
{
    [Route("Api/[controller]/[action]")]
    [ApiController]
    public class BookApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string? category , string? searchString)
        {
            List<Book> books = new List<Book>();
            using(BookStoreContext db = new BookStoreContext())
            {
                if (category != "Seleziona una categoria" && !String.IsNullOrEmpty(category))
                {
                    books = db.Books.Where(book => book.Category.Name == category).ToList();
                }
                else
                {
                    if (searchString == null)
                    {
                        books = db.Books.Include(book => book.Category).ToList();
                    }
                    else
                    {
                        books = db.Books.Where(book => book.Title.Contains(searchString) ||
                                               book.Author.Contains(searchString)
                                               ).Include(book => book.Category).ToList();
                    }
                }
                
                return Ok(books);
            }
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            Book book = null;
            using (BookStoreContext db = new BookStoreContext())
            {
                book = db.Books.Where(book => book.Id == id).Include(book => book.Category).FirstOrDefault();
            }
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult BuyBook(SellData data)
        {
            if(!ModelState.IsValid)
                return BadRequest("Il form non è stato completato con successo.");

            Book? bookToSell;
            using (BookStoreContext db = new BookStoreContext())
            {
                bookToSell = db.Books.Where(book => book.Id == data.BookId).FirstOrDefault();
            }

            if (bookToSell != null)
            {
                using (BookStoreContext db = new BookStoreContext())
                {

                    bookToSell = db.Books.Where(book => book.Id == data.BookId).FirstOrDefault();
                    bookToSell.Quantity -= data.Quantity;
                   
                    SellLog sellLog = new(DateTime.Now, data.Quantity, data.Customer, data.Quantity*bookToSell.Price);
                    sellLog.BookId = data.BookId;
                    db.SellLog.Add(sellLog);
                    db.SaveChanges();
                }
                return Ok("Aqcuisto conscluso con ");
            }
            else
            {
                return BadRequest("Qualcosa è andato storto, il libro non è presente.");
            }
        }

        [HttpGet]
        public IActionResult BestSellers()
        {
            using(BookStoreContext db = new BookStoreContext())
            {
                List<SellLog> sellLogs = db.SellLog.Include(selllog=>selllog.Book).Include(selllog=>selllog.Book.Category).ToList();

                var obj = db.SellLog.Include(selllog => selllog.Book)
                    .Where(x => x.Date > DateTime.Now.AddDays(-30))
                    .GroupBy(x => new { x.BookId, x.Book.Author, x.Book.Title , x.Book.UrlImage})
                    .Select(x => new { Book = x.Key, Sum = x.Sum(item => item.Quantity) })
                    .OrderByDescending(x => x.Sum).ToList();


                //New crea un oggetto anonimo, non capisco come fa, ma ha 2 interi come attributi,
                //forse creando un modello del genere si potrebbe usare, per JS funziona perchè quello non fa domando ma volevo fare il calcolo qui
                return Ok(obj);
            }
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            List<Category> categories = new List<Category>();
            using(BookStoreContext db = new BookStoreContext())
            {
                categories = db.Categories.ToList();
            }
            return Ok(categories);
        }
    }
}
