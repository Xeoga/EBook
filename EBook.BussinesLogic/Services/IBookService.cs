using EBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.BussinesLogic.Services
{
    public interface IBookService
    {
        Task Add(Book book);
        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetById(int id);
        Task GetCategorie(int id);
        Task Delete(int id);
        Task AddCat(Categorie categorie);
        public List<Author> GetAllAuthors();
        public List<Categorie> GetCategories();
        Task Update(Book newProduct);
    }
}
