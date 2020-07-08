using ExpenseApp.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseApp.Repository.Contracts
{
    public interface IUserRepository
    {
        Task<bool> RegisterAsync(User user);
        Task<User> GetUserByIdAsync(int _userId);
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByEmailIdAsync(string emailId);
    }
}
