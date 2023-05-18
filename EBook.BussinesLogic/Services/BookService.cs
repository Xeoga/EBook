using EBook.Domain;
using EBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.BussinesLogic.Services
{
    public class BookService : IBookService
    {
        private readonly EBookAppContext _context;
        public BookService(EBookAppContext context)
        {
            _context = context;
        }

        public async Task Add(Book book)
        {
            //Categorie category = GetCategorie(book.BookCategorie);
            //book.BookCategorie = GetCategorie()
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            var data = await _context.Books.ToListAsync();
            return data;
        }

        public Task GetCategorie(int id)
        {
            throw new NotImplementedException();
        }

        //public async Task GetCategorie(int id)
        //{
        //return await _context.Categories.FirstOrDefaultAsync(id);
        //}
    }
}
