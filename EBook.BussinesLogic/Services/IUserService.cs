using EBook.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.BussinesLogic.Services
{
    public interface IUserService
    {
        Task Add(ULoginData user);

        Task<ULoginData> GetById(int id);

        Task<IEnumerable<ULoginData>> GetAll();

        Task<ULoginData> Authenticate(string credential, string password);
        string GenerateToken(ULoginData request);
        Task<ULoginData> CheckEmail(string email);
    }
}
