using BookApi.Models;

namespace BookApi.Data
{
    public static class BookStore
    {
        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Isbn = "978-0743273565", PublicationDate = new DateTime(1925, 4, 10) }
        };

        public static List<Book> GetBooks() => books;

        public static Book? GetBookById(int id) => books.FirstOrDefault(b => b.Id == id); // Make return type nullable

        public static void AddBook(Book book)
        {
            book.Id = books.Any() ? books.Max(b => b.Id) + 1 : 1;
            books.Add(book);
        }

        public static void UpdateBook(int id, Book updatedBook)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.Isbn = updatedBook.Isbn;
                book.PublicationDate = updatedBook.PublicationDate;
            }
        }

        public static void DeleteBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                books.Remove(book);
            }
        }
    }
}