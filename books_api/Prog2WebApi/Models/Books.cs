using books_api.Models.Requests;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace books_api.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        // Foreign key - atsaucas uz citu tabulu (Authors)
        public int AuthorId { get; set; }

        // šis ļaus izgūt User objektu no Post
        public Author Author { get; set; }
        // šis ļaus izgūt sarakstu ar Likes no Post
        public ICollection<Like> Likes { get; set; } = new List<Like>();
        public ICollection<Reviews> Reviews { get; set; } = new List<Reviews>();

        // lauks tiek aprēķināts automātiski, netiek glabāts datubāzē.
        [NotMapped]
        public int LikeCount => Likes?.Count ?? 0;

        public static Book From(BookRequest dto, int authorId)
        {
            return new Books
            {
                Title = dto.Title,
                AuthorId = authorId
            };
        }
    }
}
