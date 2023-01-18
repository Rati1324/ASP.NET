using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRepository
{
    public interface IEmpRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int EmployeeID);
        void Insert(Employee employee);
        void Update(Employee employee);
        void Delete(int EmployeeID);
        void Save();
    }
}
