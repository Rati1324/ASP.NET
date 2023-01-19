using Repositories.IRepositories;
using Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class EmployeesRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeesRepository(IUnitOfWork<CRUDDBEntities> unitOfWork)
            : base(unitOfWork)
        {}
        public EmployeesRepository(CRUDDBEntities context)
            : base(context)
        {}
        IEnumerable<Employee> IEmployeeRepository.GetEmployeesByPosition(string position)
        {
            return Context.Employees.Where(emp => emp.Position == position).ToList();
        }
    }
}
