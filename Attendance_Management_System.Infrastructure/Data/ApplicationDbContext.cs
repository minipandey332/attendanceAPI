using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attendance_Management_System.Domain.DomainEntities;
using Microsoft.EntityFrameworkCore;



namespace Attendance_Management_System.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Replace "Your_Connection_String_Here" with your actual connection string
                string connectionString = "Data Source=NCSIND9050D4ZC0\\SQLEXPRESS; Initial Catalog=Attendance_Application; Integrated Security=true;";

                optionsBuilder.UseSqlServer(connectionString, sqlServerOptions =>
                {
                    sqlServerOptions.MigrationsAssembly("Attendance_Management_System.Application");
                });
            }
        }



        //public DbSet<Employee> Employees { get; set; }
        //public DbSet<punchingData> punchingRecord { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Define PunchingRecord as a keyless entity
        //    modelBuilder.Entity<punchingData>().HasNoKey();
        //}

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeDateData> EmployeeDateData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure primary keys, relationships, and other configurations here
            modelBuilder.Entity<Employee>()
                .HasKey(e => e.EmployeeId);

            modelBuilder.Entity<EmployeeDateData>()
                .HasKey(dd => dd.EmployeeDateDataId);

            // Configure the relationship between Employee and EmployeeDateData
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.DateData)
                .WithOne(dd => dd.Employee)
                .HasForeignKey(dd => dd.EmployeeId);
        }

    }
}
