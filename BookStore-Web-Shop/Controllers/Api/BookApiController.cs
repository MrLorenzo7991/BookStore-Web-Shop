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
        public IActionResult Get(string? searchString)
        {
            List<Book> books = new List<Book>();
            using(BookStoreContext db = new BookStoreContext())
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
    }
}
