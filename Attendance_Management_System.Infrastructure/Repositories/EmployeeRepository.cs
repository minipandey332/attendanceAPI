using Attendance_Management_System.Domain.DomainEntities;
using Attendance_Management_System.Infrastructure.Data;
using Attendance_Management_System.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance_Management_System.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddEmployee(Employee employee)
        {
            Console.WriteLine(".................", employee.EmployeeName);
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }


        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

     
    }
}

