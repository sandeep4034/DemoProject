using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public interface IEmployeeRepository
    {

        List<Employee> GetEmployees();

        int InsertEmployee(Employee employee);

        void UpdateEmployee(Employee employee);
    }
}
