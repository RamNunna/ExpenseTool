using Dapper;
using ExpenseApp.Entites;
using ExpenseApp.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApp.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IBaseConnectionFactory _connectionFactory;
        public UserRepository(IBaseConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<User> GetUserByEmailIdAsync(string emailId)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmailId", emailId);
                return SqlMapper.Query<User>(_connectionFactory.GetConnection, "Usp_GetUserByEmailId", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<User> GetUserByIdAsync(int _userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterAsync(User user)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmailId", user.EmailId);
                parameters.Add("@Password", user.Password);
                await SqlMapper.ExecuteAsync(_connectionFactory.GetConnection, "Usp_Register", parameters, null, null, System.Data.CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
