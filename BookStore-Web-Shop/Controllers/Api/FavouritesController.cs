using BookStore_Web_Shop.Data;
using BookStore_Web_Shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_Web_Shop.Controllers.Api
{
    [Route("Api/[controller]/[action]")]
    [ApiController]
    public class FavouritesController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddFavourtieBook ([FromBody] Favourites BookId)
        {
            using(BookStoreContext db = new BookStoreContext())
            {
                FavouritesBooks.favouritesBookList.Add(db.Books.Find(BookId.BookId));
            }
            return Ok();
        }
    }
}
