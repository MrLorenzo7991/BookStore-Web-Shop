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
                    books = db.Books.Where(book => book.Title.Contains(searchString)).Include(book => book.Category).ToList();
                }
                List<Book> books2 = new List<Book>();
                for (int i = 0; i < 30; i++)
                {
                    books2.Add(books[i]);
                }
                return Ok(books2);
            }
        }
    }
}
