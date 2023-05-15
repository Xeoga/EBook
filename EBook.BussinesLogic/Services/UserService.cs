using EBook.Domain;
using EBook.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.BussinesLogic.Services
{
    public class UserService : IUserService
    {
        private readonly EBookAppContext _context;
        public UserService(EBookAppContext context)
        {
            _context = context;
        }

        public async Task Add(ULoginData user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<ULoginData>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ULoginData> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }

}
