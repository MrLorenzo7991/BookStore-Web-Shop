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
    }
}
