using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.Domain.Entities
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
