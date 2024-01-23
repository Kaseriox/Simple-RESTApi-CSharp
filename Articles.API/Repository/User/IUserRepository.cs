namespace Articles.API.Repository.User;
using Database.Models;
public interface IUserRepository : IGenericRepository<User>
{
    Task<List<User>> GetUsers();
}