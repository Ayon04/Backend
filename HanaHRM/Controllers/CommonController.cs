using HanaHRM.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("getalldepartments")]
        public async Task<IActionResult> GetAllDepartments()
        {
            var data = await _context.Departments.ToListAsync();
            return Ok(data);
        }

        [HttpGet("getalldesignations")]
        public async Task<IActionResult> GetAllDesignations()
        {
            var data = await _context.Designations.ToListAsync();
            return Ok(data);
        }


        [HttpGet("getalleducationexaminations")]
        public async Task<IActionResult> GetAllEducationExaminations()
        {
            var data = await _context.EducationExaminations.ToListAsync();
            return Ok(data);
        }

        [HttpGet("getalleducationresults")]
        public async Task<IActionResult> GetAllEducationResults()
        {
            var data = await _context.EducationResults.ToListAsync();
            return Ok(data);
        }
    

        [HttpGet("getallemployeetypes")]
        public async Task<IActionResult> GetAllEmployeeTypes()
        {
            var data = await _context.EmployeeTypes.ToListAsync();
            return Ok(data);
        }

        [HttpGet("getallgenders")]
        public async Task<IActionResult> GetAllGenders()
        {
            var data = await _context.Genders.ToListAsync();
            return Ok(data);
        }

        [HttpGet("getalljobtypes")]
        public async Task<IActionResult> GetAllJobTypes()
        {
            var data = await _context.JobTypes.ToListAsync();
            return Ok(data);
        }

        [HttpGet("getallmaritalstatuses")]
        public async Task<IActionResult> GetAllMaritalStatuses()
        {
            var data = await _context.MaritalStatuses.ToListAsync();
            return Ok(data);
        }

        [HttpGet("getallrelationships")]
        public async Task<IActionResult> GetAllRelationships()
        {
            var data =await _context.Relationships.ToListAsync();
            return Ok(data);
        }

        [HttpGet("getallreligions")]
        public async Task<IActionResult> GetAllReligions()
        {
            var data = await _context.Religions.ToListAsync();
            return Ok(data);
        }

        [HttpGet("getallsections")]
        public async Task<IActionResult> GetAllSections()
        {
            var data = await _context.Sections.ToListAsync();
            return Ok(data);
        }

        [HttpGet("getallweekoffs")]
        public async Task<IActionResult> GetAllWeekOffs()
        {
            var data = await _context.WeekOffs.ToListAsync();
            return Ok(data);
        }

    }
}
