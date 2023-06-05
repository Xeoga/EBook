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
    public class CategorieService : ICategorieService
    {
        private readonly EBookAppContext _context;
        public CategorieService(EBookAppContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Categorie>> GetAll()
        {
            var data = await _context.Categories.ToListAsync();
            return data;
        }

    }
}
