using HotChoculate.Infrastructure.Data.Models.EmployeeModels;
using HotChoculate.Infrastructure.Data.Repositories;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace HotChoculate.Web.Graph
{
    [ExtendObjectType(Name = "Query")]
    public class EmployeeQueries
    {
        public IQueryable<Employee> GetEmployees(
            [Service] IEmployeeRepository employeeRepository) =>
            employeeRepository.GetEmployees();

        public IQueryable<Employee> GetEmployee(
            long id, [Service] IEmployeeRepository employeeRepository) =>
            employeeRepository.GetEmployee(id);
    }
}
