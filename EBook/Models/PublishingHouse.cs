using System.ComponentModel.DataAnnotations;

namespace EBook.Models
{
    public class PublishingHouse
    {
        [Key]
        public int Id { get; set; }
        public string PictureURL { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }

        public List<Book> Books { get; set; }
    }
}
