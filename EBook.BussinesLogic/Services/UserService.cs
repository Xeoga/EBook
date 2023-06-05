using EBook.Domain;
using EBook.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            string hashPass = HashPassword(user.Password);
            var newUser = new ULoginData()
            {
                Credential = user.Credential,
                Password = hashPass,
                LoginIp = user.LoginIp,
            };

            await _context.User.AddAsync(newUser);
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
        private string HashPassword(string password)
        {
            SHA256 hash = SHA256.Create();
            var passwordBytes = Encoding.Default.GetBytes(password);
            var hashedPassword = hash.ComputeHash(passwordBytes);

            return Convert.ToHexString(hashedPassword);
        }

    }

}
