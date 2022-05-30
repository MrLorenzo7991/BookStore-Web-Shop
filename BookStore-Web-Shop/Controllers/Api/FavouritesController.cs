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
        public IActionResult AddFavouriteBook ([FromBody] Favourites bookId)
        {
            int id = (int)bookId.BookId;
            //FavouritesBooks.favouritesBookList.Add(id);
            Book bookfind = new Book();
            using (BookStoreContext db = new BookStoreContext())
            {
                bookfind = db.Books.Find(id);
                bookfind.NumberOfLikes++;
                db.SaveChanges();
            }
            return Ok();
        }
    }
}
