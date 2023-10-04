using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance_Management_System.Domain.DomainEntities
{
    public class Employee
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public long EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string X { get; set; }

        // Navigation property for related date data
        public List<EmployeeDateData> DateData { get; set; }
 

}
}
