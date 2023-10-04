using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance_Management_System.Domain.DomainEntities
{
    public class EmployeeDateData
    {
        public int EmployeeDateDataId { get; set; }

        // Foreign key property
        public long EmployeeId { get; set; }
        public string Date { get; set; }
        public string Value { get; set; }

      

        // Navigation property
        public Employee Employee { get; set; }

        // Additional column
        public long ExternalEmployeeId { get; set; }
    }

}
