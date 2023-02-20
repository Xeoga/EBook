using System.ComponentModel.DataAnnotations;

namespace EBook.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string PictureURL { get; set; }
        public string AuthorBio { get; set; }
        public string Data { get; set; } 

        // Relationship

        public List<Author_Book> Author_Book { get; set; }
    }
}
