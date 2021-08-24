using HotChoculate.Infrastructure.Core.Interfaces;
using HotChoculate.Infrastructure.Data.Models.Common;
using HotChoculate.Infrastructure.Data.Models.EmployeeModels;
using Dapper;
using System.Linq;

namespace HotChoculate.Infrastructure.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IMainDataBaseProvider _provider;
        public EmployeeRepository(IMainDataBaseProvider provider)
        {
            _provider = provider;
        }

        public IQueryable<Employee> GetEmployees()
        {
            var sql = "SELECT * FROM Employee" +
                "left join Title on EmployeeTitleUniqueNumber = TitleUniqueNumber";
            using (var connection = _provider.GetConnection())
            {
                var result = connection.Query<Employee, Title, Employee>(sql,
                    (employee, title) =>
                    {
                        employee.Title = title;
                        return employee;
                    },
                    splitOn: "EmployeeTitleUniqueNumber");
                return result.AsQueryable();
            }
        }

        public IQueryable<Employee> GetEmployee(long id)
        {
            var sql = "SELECT * FROM Employee where EmployeeID = @Id";
            using (var connection = _provider.GetConnection())
            {
                var result = connection.Query<Employee>(sql, new { @Id = id });
                return result.AsQueryable();
            }
        }
    }
}
