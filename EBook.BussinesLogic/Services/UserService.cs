using EBook.Domain;
using EBook.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;


namespace EBook.BussinesLogic.Services
{
    public class UserService : IUserService
    {
        private const string TokenSecret = "asflags;lasdTestKey";
        private static readonly TimeSpan TokenLifeTime = TimeSpan.FromHours(1);
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
        public async Task<ULoginData> Authenticate(string credential, string password)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Credential == credential);
            if (user != null)
            {
                var hashedPassword = HashPassword(password);
                if (hashedPassword == user.Password)
                {
                    // Parola este corectă
                    return user;
                }
            }
            // Autentificare eșuată
            return null;
        }

        public string GenerateToken(ULoginData request)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(TokenSecret);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Sub, request.LoginIp),
                new(JwtRegisteredClaimNames.Email, request.Credential),
                new("userId", request.Id.ToString()),
                new("Role", request.Level.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(TokenLifeTime),
                Issuer = "",
                Audience = "",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);
            return jwt;
        }
        public async Task<ULoginData> CheckEmail(string email)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Credential == email);
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
