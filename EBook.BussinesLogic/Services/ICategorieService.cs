using EBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.BussinesLogic.Services
{
    public interface ICategorieService
    {
        Task<IEnumerable<Categorie>> GetAll();
    }
}
