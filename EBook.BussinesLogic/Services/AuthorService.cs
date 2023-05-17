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
        public async Task<IEnumerable<Author>> GetAll()
        {
            var data = await _context.Authors.ToListAsync();
            return data;
        }
    }
}
