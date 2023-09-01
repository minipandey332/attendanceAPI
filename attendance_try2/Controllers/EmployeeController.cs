using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using ClosedXML.Excel; // Import the ClosedXML namespace
using attendance_try2.Models;
using attendance_try2.Repository;

namespace attendance_try2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeController(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost("upload")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UploadEmployees(IFormFile file)
        {
            try
            {
                if (file == null || file.Length <= 0)
                {
                    return BadRequest("No file uploaded.");
                }

                using (var memoryStream = new MemoryStream())
                {
                    file.CopyTo(memoryStream);
                     
                    using (var workbook = new XLWorkbook(memoryStream))
                    {
                        var worksheet = workbook.Worksheet(1);
                        var rows = worksheet.RangeUsed().RowsUsed().Skip(1); // Skip header

                        var employees = new List<Employee>();

                        foreach (var row in rows)
                        {
                            var employeeId = row.Cell(1).GetValue<int>();
                            var employeeName = row.Cell(2).GetValue<string>();

                            employees.Add(new Employee
                            {
                               // EmployeeId = employeeId,
                                EmployeeName = employeeName
                            });
                        }

                        foreach (var employee in employees)
                        {
                            _employeeRepository.AddEmployee(employee);
                        }

                        return Ok("Data has been successfully fetch & send to Database.");
                    }
                }
            }
            catch (Exception ex)
            {
               var fullExceptionMessage = ex.ToString();
    return BadRequest($"An error occurred: {fullExceptionMessage}");
            }
        }


        [HttpGet("read")]
        public IActionResult ReadEmployeesFromExcel()
        {
            try
            {
                using (var workbook = new XLWorkbook("C:\\Users\\p1357950\\Desktop\\Attendance\\sample-data-2.xlsx")) // Replace with the actual path
                {
                    var worksheet = workbook.Worksheet(1);
                    var rows = worksheet.RangeUsed().RowsUsed().Skip(1); // Skip header

                    var employees = new List<Employee>();

                    foreach (var row in rows)
                    {
                        var employeeId = row.Cell(1).GetValue<int>();
                        var employeeName = row.Cell(2).GetValue<string>();

                        employees.Add(new Employee
                        {
                            EmployeeId = employeeId,
                            EmployeeName = employeeName
                        });
                    }

                    return Ok(employees);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

    }
}
