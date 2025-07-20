using HanaHRM.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HanaHRM.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly HRMDbContext _context;

        public EmployeeController(HRMDbContext context)
        {
            _context = context;
        }

        int clientId = 10001001;
        [HttpGet("getallemployees")]
        public async Task<IActionResult> GetAllEmployees(CancellationToken ct)
        {
            
            var data = await _context.Employees.Where(e => e.IsActive == true && e.IdClient == clientId).ToListAsync(ct);
            return Ok(data);
        }

        [HttpGet("getallemployeedocuments")]
        public async Task<IActionResult> GetAllEmployeeDocuments(CancellationToken ct)
        {
            var data = await _context.EmployeeDocuments.Where(e => e.IdClient == clientId).ToListAsync(ct);
            return Ok(data);
        }
        [HttpGet("getallemployeeeducationinfo")]
        public async Task<IActionResult> GetAllEmployeeEducationInfo(CancellationToken ct)
        {
            var data = await _context.EmployeeEducationInfos.Where(e => e.IdClient == clientId).ToListAsync(ct);
            return Ok(data);
        }
        [HttpGet("getallemployeefamilyinfo")]
        public async Task<IActionResult> GetAllEmployeeFamilyInfo(CancellationToken ct)
        {
            var data = await _context.EmployeeFamilyInfos.Where(e => e.IdClient == clientId).ToListAsync(ct);
            return Ok(data);
        }

        [HttpGet("getallemployeeprofessionalcertifications")]
        public async Task<IActionResult> GetAllEmployeeProfessionalCertifications(CancellationToken ct)
        {
            var data = await _context.EmployeeProfessionalCertifications.Where(e => e.IdClient == clientId).ToListAsync(ct);
            return Ok(data);
        }


        [HttpGet("getemployeebyid")]
        public async Task<IActionResult> GetEmployeeById(int id, CancellationToken ct)
        {
            var data = await  _context.Employees.Where(e => e.IdClient == clientId).FirstOrDefaultAsync(e => e.Id == id, ct);

            return Ok(data);
        }

        [HttpPost("createemployee")]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee emp, CancellationToken ct)
        {
          
             emp.SetDate = DateTime.Now;
             await _context.Employees.AddAsync(emp, ct);
             await _context.SaveChangesAsync(ct);


            return Ok(new { message = "Employee created successfully!", emp.Id });
        }


        [HttpPut("updateemployee")]
        public async Task<IActionResult> EditEmployee([FromBody] Employee emp, CancellationToken ct)
        {
            var currentEmp = await _context.Employees.FirstOrDefaultAsync(e=>e.IdClient == emp.IdClient && e.Id== emp.Id,ct );

            if ( currentEmp == null)
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

            await _context.SaveChangesAsync(ct);

            return Ok(new { message = "Data Updated successfully" });
        }

        [HttpDelete("deleteemployeeparmanent/{idClient}/{id}")]
        public async Task<IActionResult> DeleteEmployee(int idClient, int id ,CancellationToken ct)
        {
            var empToDelete =await _context.Employees.FirstOrDefaultAsync(e => e.IdClient == idClient && e.Id == id,ct);

            if (empToDelete == null)
            {
                return NotFound(new { error = "Employee not found!\n Nothing to Delete" });
            }

            _context.Employees.Remove(empToDelete);
            _context.SaveChanges();

            return Ok(new { message = "Data deleted successfully" });
        }

        //Soft Delete using boolian flag (IsActive)
        [HttpPatch("deleteemployee/{idClient}/{id}")]
        public async Task<IActionResult> HideEmployee(int idClient, int id,CancellationToken ct)
        {
            var empToHide = await _context.Employees.FirstOrDefaultAsync(e => e.IdClient == idClient && e.Id == id, ct);
            if (empToHide == null)
            {
                return NotFound(new { error = "Employee not found!" });
            }


            empToHide.IsActive = false;

            _context.SaveChanges();

            return Ok(new { message = "Data Deleted/Hide successfully" });
        }

    }
}
