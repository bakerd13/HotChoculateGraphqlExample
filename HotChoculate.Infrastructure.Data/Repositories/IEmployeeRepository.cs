using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotChoculate.Infrastructure.Data.Models.EmployeeModels;

namespace HotChoculate.Infrastructure.Data.Repositories
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> GetEmployees();

        IQueryable<Employee> GetEmployee(long id);
    }
}
