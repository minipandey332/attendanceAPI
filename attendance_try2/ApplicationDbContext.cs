using attendance_try2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace attendance_try2
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
