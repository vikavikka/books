namespace books_api.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BookId { get; set; }

        public ICollection<Books> Books { get; set; } = new List<Books>();
    }
}