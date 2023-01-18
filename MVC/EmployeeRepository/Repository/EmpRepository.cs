using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRepository
{
    public class EmpRepository : IEmpRepository
    {
        private readonly EmployeeEntities _context;
        public EmpRepository()
        {
            _context = new EmployeeEntities();
        }
        public EmpRepository(EmployeeEntities context)
        {
            _context = context;
        }
        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }
        public Employee GetById(int EmployeeID)
        {
            return _context.Employees.Find(EmployeeID);
        }
        public void Insert(Employee employee)
        {
            _context.Employees.Add(employee);
        }
        public void Update(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
        }
        public void Delete(int EmployeeID)
        {
            Employee employee = _context.Employees.Find(EmployeeID);
            _context.Employees.Remove(employee);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
