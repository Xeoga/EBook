
using System.ComponentModel.DataAnnotations;

namespace EBook.Domain.Entities
{
    public class Categorie
    {
        [Key]
        public int Id { get; set; }
        public string Logo { get; set; }
        public string NameCategorie { get; set; }
        public string Description { get; set; }

        // Relationship

        public List<Book> Books { get; set; }
    }
}
