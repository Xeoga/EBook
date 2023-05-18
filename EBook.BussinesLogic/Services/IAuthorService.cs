using EBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.BussinesLogic.Services
{
    public interface IAuthorService
    {
        Task AddAuthor(Author author);
        Task<IEnumerable<Author>> GetAll();
        
    }
}
