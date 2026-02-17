namespace books_api.Models
{
    public class Like
    {
        public int Id { get; set; }

        // divas FOREIGN KEY
        public int UserId { get; set; }
        public int BookId { get; set; }

        public User User { get; set; }
        public Book Book { get; set; }
    }
}
