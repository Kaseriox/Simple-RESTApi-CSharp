using Database.Data;
using Microsoft.EntityFrameworkCore;

namespace Articles.API.Repository.User;
using Database.Models;
public class UserRepository : GenericRepository<User> , IUserRepository
{
    public UserRepository(ArticleContext articleContext) : base(articleContext)
    {
    }

    public async Task<List<User>> GetUsers()
    {
        return await GetAll().ToListAsync();
    }
    
}