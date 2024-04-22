using Microsoft.EntityFrameworkCore;

namespace crud_dotnet_api.Data
{
    public class UserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddUserAsync(User user)
        {
            await _appDbContext.Set<User>().AddAsync(user);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUserAsync()
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
                throw new Exception("User not found");
            }
           user.Username= model.Username;
        
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsnyc(int id)
        {
            var user = await _appDbContext.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");
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
