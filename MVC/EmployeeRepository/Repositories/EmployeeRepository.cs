using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRepositories;

namespace Repository.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private EmployeeEntities _context = null;
        public EmployeeRepository()
        {
            this._context = new EmployeeEntities();
        }
        public EmployeeRepository(EmployeeEntities _context)
        {
            this._context = _context;
        }
        public IEnumerable<Employee> GetEmployeesByPosition(string position)
        {
            return _context.Employees.Where(emp => emp.Position == position).ToList();
        }
    }
}
