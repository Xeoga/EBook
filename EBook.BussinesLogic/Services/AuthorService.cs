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
    public class AuthorService : IAuthorService
    {
        private readonly EBookAppContext _context;
        public AuthorService(EBookAppContext context)
        {
            _context = context;
        }
        public async Task AddAuthor(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            var data = await _context.Authors.ToListAsync();
            return data;
        }
        public async Task<Author> GetById(int id)
        {
            var productDetails = await _context.Authors
                .FirstOrDefaultAsync(m => m.Id == id);

            return productDetails;
        }
        public async Task Delete(int id)
        {
            var product = await _context.Authors.FindAsync(id);
            if (product != null)
            {
                var existingConnect = _context.Authors.Where(m => m.Id == id).ToList();
                _context.Authors.RemoveRange(existingConnect);

                _context.Authors.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
