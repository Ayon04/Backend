using HanaHRM.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HanaHRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly HRMDbContext _context;

        public EmployeeController(HRMDbContext context)
        {
            _context = context;
        }

        [HttpPost("createemployee")]
        public IActionResult CreateEmployee([FromBody] Employee emp)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            emp.SetDate = DateTime.Now;
            _context.Employees.Add(emp);
            _context.SaveChanges();
        

            return Ok(new { message = "Employee created successfully!", emp.Id });
        }


        [HttpPut("updateemployee")]
        public IActionResult EditEmployee([FromBody] Employee emp)
        {
            var currentEmp = _context.Employees.Find(emp.IdClient, emp.Id);

            if (currentEmp.Id != emp.Id || currentEmp == null)
            {
                return NotFound(new { error = "Employee not found!" });
            }

            currentEmp.EmployeeName = emp.EmployeeName;
            currentEmp.EmployeeNameBangla = emp.EmployeeNameBangla;
            currentEmp.FatherName = emp.FatherName;
            currentEmp.MotherName = emp.MotherName;
            currentEmp.BirthDate = emp.BirthDate;
            currentEmp.JoiningDate = emp.JoiningDate;
            currentEmp.IdSection = emp.IdSection;
            currentEmp.IdDepartment = emp.IdDepartment;
            currentEmp.HasAttendenceBonus = emp.HasAttendenceBonus;
            currentEmp.Address = emp.Address;
            currentEmp.PresentAddress = emp.PresentAddress;
            currentEmp.NationalIdentificationNumber = emp.NationalIdentificationNumber;
            currentEmp.ContactNo = emp.ContactNo;

            _context.SaveChanges();

            return Ok(new { message = "Data Updated successfully" });
        }

        [HttpDelete("deleteemployeeparmanent/{idClient}/{id}")]
         public IActionResult DeleteEmployee(int idClient, int id)
         {
             var empToDelete = _context.Employees.Find(idClient, id);

            if (empToDelete == null)
            {
                return NotFound(new { error = "Employee not found!\n Nothing to Delete" });
            }

            _context.Employees.Remove(empToDelete);
             _context.SaveChanges();

             return Ok(new { message = "Data deleted successfully" });
         }

        //Soft Delete using boolian flag (IsActive)

        [HttpPatch("deleteemployee")]
        public IActionResult HideEmployee([FromBody] Employee emp)
        {
            var empToHide = _context.Employees.Find(emp.IdClient, emp.Id);

            if (empToHide.Id != emp.Id || empToHide == null)
            {
                return NotFound(new { error = "Employee not found!" });
            }


            empToHide.IsActive = false;

            _context.SaveChanges();

            return Ok(new { message = "Data Deleted/Hide successfully" });
        }

    }
}
