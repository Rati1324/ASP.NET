using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.UnitOfWork;
using IRepositories;

namespace Repository.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IUnitOfWork<EmployeeEntities> unitOfWork)
            : base(unitOfWork)
        {}
        public EmployeeRepository(EmployeeEntities context)
            : base(context)
        {}

        public IEnumerable<Employee> GetEmployeesByPosition(string position)
        {
            return Context.Employees.Where(emp => emp.Position == position).ToList();
        }
    }
}
