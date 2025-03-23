using Microsoft.AspNetCore.Mvc;
using BookService.Models;

namespace BookService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private static readonly List<Book> books = new()
        {
            new Book { Id = 1, Title = "Clean Code", Price = 29.99M },
            new Book { Id = 2, Title = "The Pragmatic Programmer", Price = 35.50M },
            new Book { Id = 3, Title = "C# in Depth", Price = 40.00M }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound();
            return Ok(book);
        }
    }
}
