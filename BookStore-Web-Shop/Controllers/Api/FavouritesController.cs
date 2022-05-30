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
        public IActionResult AddFavouriteBook ([FromBody] int id)
        {
            Book bookfind = new Book();
            using (BookStoreContext db = new BookStoreContext())
            {
                bookfind = db.Books.Find(id);
                bookfind.NumberOfLikes++;
            }
            return Ok();
        }
    }
}
