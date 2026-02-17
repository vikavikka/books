namespace books_api.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Foreign key - atsaucas uz citu tabulu (Book)
        public string BookId { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}