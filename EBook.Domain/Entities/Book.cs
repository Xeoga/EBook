using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.Domain.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public double Price { get; set; }
        public string Authors { get; set; }
        public int NrPage { get; set; }
        public DateTime DatePublishing { get; set; } = DateTime.Now;
        public string URL { get; set; }
        public Categorie BookCategorie { get; set; }

        //Relationships
        public List<Author_Book> Author_Book { get; set; }
        //PublishingHouse 
        [ForeignKey("PublishingHouseID")]
        public int PublishingHouseId { get; set; }

        public PublishingHouse PublishingHouse { get; set; }

        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }

    }
}
