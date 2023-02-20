using EBook.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBook.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public double Price { get; set; }
        public string Authors{ get; set; }
        public int NrPage { get; set; }
        public DateTime DatePublishing { get; set; }
        public string URL { get; set; }
        public BookCategorie BookCategorie { get; set; }

        //Relationships
        public List<Author_Book> Author_Book { get; set; }
        //PublishingHouse 
        public int PublishingHouseId { get; set; }
        [ForeignKey("PublishingHouseID")]
        public PublishingHouse PublishingHouse { get; set; }
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public PublishingHouse Author { get; set; }
    }
}
