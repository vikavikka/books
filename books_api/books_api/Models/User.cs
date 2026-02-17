namespace books_api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<Like> Likes { get; set; } = new List<Like>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
