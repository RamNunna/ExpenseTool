using System.Data;

namespace ExpenseApp.Repository.Contracts
{
    public interface IBaseConnectionFactory
    {
        IDbConnection GetConnection { get; }
        void CloseConnection();
    }
}
