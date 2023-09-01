using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace attendance_try2.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // This attribute specifies auto-increment behavior
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }
}
