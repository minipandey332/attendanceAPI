using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Attendance_Management_System.Infrastructure.Repositories;
using Attendance_Management_System.Domain.DomainEntities;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;

namespace Attendance_Management_System.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeesController(EmployeeRepository employeeRepository)
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
                        var rows = worksheet.RangeUsed().RowsUsed();

                        var employees = new List<Employee>();

                        // Assuming the first row contains headers, and you know the positions of columns
                        var headerRow = rows.First();
                        var dateColumns = new List<string>();

                        // Extract dynamic date columns
                        for (int col = 5; col <= headerRow.CellsUsed().Count(); col++)
                        {
                            dateColumns.Add(headerRow.Cell(col).GetString());
                        }

                        foreach (var row in rows)
                        {
                            var employeeIdCellValue = row.Cell(2).Value;

                            if (true)
                            {
                                var employeeId = row.Cell(2).GetValue<long>();
                                var employeeName = row.Cell(3).GetValue<string>();
                                var x = row.Cell(4).GetValue<string>();

                                var employee = new Employee
                                {
                                    EmployeeId = employeeId,
                                    EmployeeName = employeeName,
                                    X = x,
                                    DateData = new List<EmployeeDateData>(),
                                    // You can add other properties here based on your Employee entity
                                };

                                // Populate dynamic date columns
                                for (int col = 5; col <= headerRow.CellsUsed().Count(); col++)
                                {
                                    var dateColumnName = dateColumns[col - 5];
                                    var cellValue = row.Cell(col).GetValue<string>();
                                    employee.DateData.Add(new EmployeeDateData
                                    {
                                        Date = dateColumnName,
                                        Value = cellValue,
                                    });
                                }

                                employees.Add(employee);
                            }
                            else
                            {
                                // Log or handle the error appropriately
                                Console.WriteLine($"Invalid EmployeeId value at row {row.RowNumber()}");
                            }
                        }

                        foreach (var employee in employees)
                        {
                            _employeeRepository.AddEmployee(employee);
                        }

                        Console.WriteLine($"Data has been successfully fetched and sent to the database.");
                        return Ok("Data has been successfully fetched and sent to the database.");
                    }
                }
            }
            catch (Exception ex)
            {
                var fullExceptionMessage = ex.ToString();
                Console.WriteLine($"An error occurred: {fullExceptionMessage}");
                return BadRequest($"An error occurred: {fullExceptionMessage}");
            }
        }
    }
}
