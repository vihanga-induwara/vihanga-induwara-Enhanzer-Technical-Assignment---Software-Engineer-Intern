using Microsoft.AspNetCore.Mvc;
using BookApi.Models;
using BookApi.Data;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return Ok(BookStore.GetBooks());
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = BookStore.GetBookById(id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public ActionResult<Book> AddBook(Book book)
        {
            BookStore.AddBook(book);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book book)
        {
            if (id != book.Id)
                return BadRequest();
            var existingBook = BookStore.GetBookById(id);
            if (existingBook == null)
                return NotFound();
            BookStore.UpdateBook(id, book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = BookStore.GetBookById(id);
            if (book == null)
                return NotFound();
            BookStore.DeleteBook(id);
            return NoContent();
        }
    }
}