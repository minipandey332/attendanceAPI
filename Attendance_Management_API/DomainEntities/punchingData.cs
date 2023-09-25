using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance_Management_System.Domain.DomainEntities
{
    internal class punchingData
    {
        [ForeignKey("Employee")] // Foreign Key
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        // Add an array for Intime, OutTime, and TotalHours
        public string[] TimeData { get; set; }
        public List<string> PunchingDate { get; set; }
    }
}
