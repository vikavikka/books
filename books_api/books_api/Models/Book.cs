using books_api.Models.Requests;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace books_api.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        // Foreign key - atsaucas uz citu tabulu (Author)
        public int AuthorId { get; set; }

        // šis ļaus izgūt User objektu no Post
        public Author Author { get; set; }
        // šis ļaus izgūt sarakstu ar Likes no Post
        public ICollection<Like> Likes { get; set; } = new List<Like>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        // lauks tiek aprēķināts automātiski, netiek glabāts datubāzē.
        [NotMapped]
        public int LikeCount => Likes?.Count ?? 0;

        public static Book From(BookRequest dto, int authorId)
        {
            return new Book
            {
                Title = dto.Title,
                AuthorId = authorId
            };
        }
    }
}
