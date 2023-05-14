using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.Domain.Entities
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
