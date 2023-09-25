using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attendance_Management_System.Domain.DomainEntities;


namespace Attendance_Management_System.Infrastructure.IRepositories
{
    internal interface IEmployeeRepository
    {
        void AddEmployee(Employee employee);
        IEnumerable<Employee> GetAllEmployees();
    }
}
