using ExpenseApp.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApp.Business.Contracts
{
    public interface IUserManager
    {
        Task<bool> Register(User user);
        Task<User> GetUserById(int _userId);
        Task<List<User>> GetUsers();
        Task<User> AuthenticateUser(string username, string password);
    }
}
