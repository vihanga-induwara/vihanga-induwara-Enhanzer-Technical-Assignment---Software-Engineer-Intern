namespace BookApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; } // Make nullable
        public string? Author { get; set; } // Make nullable
        public string? Isbn { get; set; } // Make nullable
        public DateTime PublicationDate { get; set; }
    }
}