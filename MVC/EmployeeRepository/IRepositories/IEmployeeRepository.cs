using Repository;
using Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    { 
        IEnumerable<Employee> GetEmployeesByPosition(string position);
    }
}
