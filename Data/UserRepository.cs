using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using System.Text.RegularExpressions;

namespace crud_dotnet_api.Data
{
    public class UserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task RegisterAsync(User user)
        {
            ValidatePassword(user.Password);

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            await _appDbContext.Set<User>().AddAsync(user);
            await _appDbContext.SaveChangesAsync();
        }

        private void ValidatePassword(string password)
        {
            if (password.Length < 6)
                throw new Exception("Password must be at least 6 characters long.");

            if (!Regex.IsMatch(password, @"[A-Z]"))
                throw new Exception("Password must contain at least one uppercase letter.");

            if (!Regex.IsMatch(password, @"[a-z]"))
                throw new Exception("Password must contain at least one lowercase letter.");

            if (!Regex.IsMatch(password, @"[0-9]"))
                throw new Exception("Password must contain at least one digit.");

            if (!Regex.IsMatch(password, @"[\W_]"))
                throw new Exception("Password must contain at least one non-alphanumeric character.");
           
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _appDbContext.Users.ToListAsync();
        }
             
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _appDbContext.Users.FindAsync(id);
        }

        public async Task UpdateUserAsync(int id, User model)
        {
            var user = await _appDbContext.Users.FindAsync(id);
            if(user == null)
            {
                throw new Exception("User not found!");
            }
           user.Username= model.Username;
           user.Email = model.Email;
           user.Password = model.Password;
           await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsnyc(int id)
        {
            var user = await _appDbContext.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception("User not found!");
            }
            _appDbContext.Users.Remove(user);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _appDbContext.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
        }
    }
}
