using BookStore_Web_Shop.Data;
using BookStore_Web_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore_Web_Shop.Controllers.Api
{
    [Route("Api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
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
                    books = db.Books.Where(book => book.Title.Contains(searchString)).ToList();
                }
                return Ok(books);
            }
        }
    }
}
