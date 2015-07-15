using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
namespace DAL
{
    public class EmployeeRepository: IEmployeeRepository
    {
        public EmployeeRepository()
        {

        }

        public List<Employee> GetEmployees()
        {
            //var empList = new List<Employee>
            //{

            //    new Employee
            //    {
            //        Id = 1,
            //        Name = "Emp1"
            //    } ,

            //    new Employee
            //    {
            //        Id = 2,
            //        Name = "Emp2"
            //    } ,
            //    new Employee
            //    {
            //        Id = 3,
            //        Name = "Emp3"
            //    } ,
            //};
            //return empList;

            demoDbContext context = new demoDbContext();

            return context.employees.Select(emp => new Employee()
            {
                Id = emp.Id,
                Name = emp.Name
            }).ToList();

        }

        public int InsertEmployee (Employee employee)
        {
            demoDbContext context = new demoDbContext();
            context.employees.Add(new EmployeeEntity()
            {
                Id = employee.Id,
                Name = employee.Name
            });
            context.SaveChanges();
            
            return employee.Id;
        }

        public async void BulkInsertAsync(List<Employee> employees)
        {
            demoDbContext context = new demoDbContext();
            await Task.Run(() => BulkInsert(employees, context));
            context.SaveChanges();
        }

        public void BulkInsert(List<Employee> employees, demoDbContext context)
        {
            employees.ForEach(c => context.employees.Add(new EmployeeEntity()
            {
                Id = c.Id,
                Name = c.Name
            }));
        }
    }
}
