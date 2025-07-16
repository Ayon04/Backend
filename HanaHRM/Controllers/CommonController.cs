using HanaHRM.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace HanaHRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly HRMDbContext _context;

        public CommonController(HRMDbContext context)
        {
            _context = context;
        }

        [HttpGet("getalleducationexaminations")]
        public IActionResult GetAllEducationExaminations()
        {
            var data = _context.EducationExaminations.ToList();
            return Ok(data);
        }

        [HttpGet("getalleducationresults")]
        public IActionResult GetAllEducationResults()
        {
            var data = _context.EducationResults.ToList();
            return Ok(data);
        }

        [HttpGet("getallemployees")]
        public IActionResult GetAllEmployees()
        {
            var data = _context.Employees.Where(e=>e.IsActive == true).ToList();
            return Ok(data);
        }

        [HttpGet("getemployeebyid/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var data = _context.Employees.FirstOrDefault(e => e.Id == id);

            return Ok(data);
        }

        [HttpGet("getallemployeedocuments")]
        public IActionResult GetAllEmployeeDocuments()
        {
            var data = _context.EmployeeDocuments.ToList();
            return Ok(data);
        }

        [HttpGet("getallemployeeeducationinfo")]
        public IActionResult GetAllEmployeeEducationInfo()
        {
            var data = _context.EmployeeEducationInfos.ToList();
            return Ok(data);
        }

        [HttpGet("getallemployeefamilyinfo")]
        public IActionResult GetAllEmployeeFamilyInfo()
        {
            var data = _context.EmployeeFamilyInfos.ToList();
            return Ok(data);
        }

        [HttpGet("getallemployeeprofessionalcertifications")]
        public IActionResult GetAllEmployeeProfessionalCertifications()
        {
            var data = _context.EmployeeProfessionalCertifications.ToList();
            return Ok(data);
        }

        [HttpGet("getallemployeetypes")]
        public IActionResult GetAllEmployeeTypes()
        {
            var data = _context.EmployeeTypes.ToList();
            return Ok(data);
        }

        [HttpGet("getallgenders")]
        public IActionResult GetAllGenders()
        {
            var data = _context.Genders.ToList();
            return Ok(data);
        }

        [HttpGet("getalljobtypes")]
        public IActionResult GetAllJobTypes()
        {
            var data = _context.JobTypes.ToList();
            return Ok(data);
        }

        [HttpGet("getallmaritalstatuses")]
        public IActionResult GetAllMaritalStatuses()
        {
            var data = _context.MaritalStatuses.ToList();
            return Ok(data);
        }

        [HttpGet("getallrelationships")]
        public IActionResult GetAllRelationships()
        {
            var data = _context.Relationships.ToList();
            return Ok(data);
        }

        [HttpGet("getallreligions")]
        public IActionResult GetAllReligions()
        {
            var data = _context.Religions.ToList();
            return Ok(data);
        }

        [HttpGet("getallsections")]
        public IActionResult GetAllSections()
        {
            var data = _context.Sections.ToList();
            return Ok(data);
        }

        [HttpGet("getallweekoffs")]
        public IActionResult GetAllWeekOffs()
        {
            var data = _context.WeekOffs.ToList();
            return Ok(data);
        }


    }
}
