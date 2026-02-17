namespace books_api.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        // divas FOREIGN KEY
        public int UserId { get; set; }
        public int BookId { get; set; }

        public User User { get; set; }
        public Books Book { get; set; }
    }
}
