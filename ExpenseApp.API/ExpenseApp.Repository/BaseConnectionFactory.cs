using ExpenseApp.Entites;
using ExpenseApp.Repository.Contracts;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace ExpenseApp.Repository
{
    public class BaseConnectionFactory : IBaseConnectionFactory
    {
        private IDbConnection _connection;
        private readonly IOptions<ConnectionStrings> _configs;

        public BaseConnectionFactory(IOptions<ConnectionStrings> Configs)
        {
            _configs = Configs;
        }

        public IDbConnection GetConnection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(_configs.Value.DbConnectionString);
                }
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                return _connection;
            }
        }

        public void CloseConnection()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}
