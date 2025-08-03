using HanaHRM.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HanaHRM.Controllers
{
    [Route("api/common")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly HRMContext _context;

        public CommonController(HRMContext context)
        { 
            _context = context;
        }

        [HttpGet("departmentdropdown")]
        public async Task<IActionResult> GetDepartmentDropDown([FromQuery] int idClient, CancellationToken ct)
        {
            var data = await _context.Departments.Where(x=>x.IdClient == idClient).Select(d=> new DropDown {

                value = d.Id,
                text = d.DepartName
              
            }).ToListAsync(ct);
            return Ok(data);
        }

        [HttpGet("designationdropdown")]
        public async Task<IActionResult> GetDesignationDropDown([FromQuery]  int idClient,CancellationToken ct)
        {
            var data = await _context.Designations.Where(x => x.IdClient == idClient).Select(d=>new DropDown { 
            
                value = d.Id,
                text  = d.DesignationName

            }).ToListAsync(ct);
            return Ok(data);
        }


        [HttpGet("educationexaminationsdropdown")]
        public async Task<IActionResult> GetEducationExaminationsDropDown( [FromQuery] int idClient,CancellationToken ct)
        {
            var data = await _context.EducationExaminations.Where(x => x.IdClient == idClient).Select(ee => new DropDown { 
                
                value = ee.Id, 
                text  = ee.ExamName 

            }).ToListAsync(ct);
            return Ok(data);
        }

        [HttpGet("educationresultsdropdown")]
        public async Task<IActionResult> GetEducationResultsDropDown([FromQuery] int idClient,CancellationToken ct)
        {
            var data = await _context.EducationResults.Where(x => x.IdClient == idClient).Select(er => new DropDown { 

                value = er.Id, 
                text  = er.ResultName 

            }) .ToListAsync(ct);
            return Ok(data);
        }

        [HttpGet("employeetypesdropdown")]
        public async Task<IActionResult> GetEmployeeTypesDropDown([FromQuery] int idClient,CancellationToken ct)
        {
            var data = await _context.EmployeeTypes.Where(x => x.IdClient == idClient).Select(et => new DropDown {
                
                
                value = et.Id, 
                text  = et.TypeName 
            
            }).ToListAsync(ct);
            return Ok(data);
        }

        [HttpGet("gendersdropdown")]
        public async Task<IActionResult> GetGendersDropDown([FromQuery] int idClient,CancellationToken ct)
        {
            var data = await _context.Genders.Where(x => x.IdClient == idClient).Select(g => new DropDown { 
                
                value = g.Id, 
                text  = g.GenderName 
            
            }).ToListAsync(ct);
            return Ok(data);
        }

        [HttpGet("jobtypesdropdown")]
        public async Task<IActionResult> GetJobTypesDropDown([FromQuery] int idClient,CancellationToken ct)
        {
            var data = await _context.JobTypes.Where(x => x.IdClient == idClient).Select(j => new DropDown { value = j.Id, text = j.JobTypeName }).ToListAsync(ct);
            return Ok(data);
        }

        [HttpGet("maritalstatusesdropdown")]
        public async Task<IActionResult> GetMaritalStatusesDropDown([FromQuery] int idClient,CancellationToken ct)
        {
            var data = await _context.MaritalStatuses.Where(x => x.IdClient == idClient).Select(m => new DropDown { 

                value = m.Id, 
                text  = m.MaritalStatusName 

            }).ToListAsync(ct);
            return Ok(data);
        }

        [HttpGet("relationshipdropdown")]
        public async Task<IActionResult> GetRelationshipDropDown([FromQuery] int idClient,CancellationToken ct)
        {
            var data = await _context.Relationships.Where(x => x.IdClient == idClient).Select(r => new DropDown {
                
                value = r.Id, 
                text  = r.RelationName 
            
            }).ToListAsync(ct);
            return Ok(data);
        }

        [HttpGet("religionsdropdown")]
        public async Task<IActionResult> GetReligionsDropDown([FromQuery] int idClient,CancellationToken ct)
        {
            var data = await _context.Religions.Where(x => x.IdClient == idClient).Select(rg => new DropDown { 
                
                value = rg.Id, 
                text  = rg.ReligionName    
                
            }).ToListAsync(ct);
            return Ok(data);
        }

        [HttpGet("sectionsdropdown")]
        public async Task<IActionResult> GetSectionsDropDown([FromQuery] int idClient,CancellationToken ct)
        {
            var data = await _context.Sections.Where(x => x.IdClient == idClient).Select(s => new DropDown { 
                
                value = s.Id,
                text  = s.SectionName 
            
            }).ToListAsync(ct);
            return Ok(data);
        }

        [HttpGet("weekoffsdropdown")]
        public async Task<IActionResult> GetWeekOffsDropDown([FromQuery] int idClient,CancellationToken ct)
        {
            var data = await _context.WeekOffs.Where(x => x.IdClient == idClient).Select(w => new DropDown { 
                
               value = w.Id, 
               text  = w.WeekOffDay 

            }).ToListAsync(ct);
            return Ok(data);
        }

        [HttpGet("educationlevel")]
        public async Task<IActionResult> GetEducationLevelDropDown([FromQuery] int idClient, CancellationToken ct)
        {
            var data = await _context.EducationLevels.Where(x => x.IdClient == idClient).Select(w => new DropDown
            {

                value = w.Id,
                text = w.EducationLevelName

            }).ToListAsync(ct);
            return Ok(data);
        }

        [HttpGet("educationexamination")]
        public async Task<IActionResult> GetEducationExamDropDown([FromQuery] int idClient, CancellationToken ct)
        {
            var data = await _context.EducationExaminations.Where(x => x.IdClient == idClient).Select(w => new DropDown
            {

                value = w.Id,
                text = w.ExamName

            }).ToListAsync(ct);
            return Ok(data);
        }

        [HttpGet("educationresult")]
        public async Task<IActionResult> GetEducationResult([FromQuery] int idClient, CancellationToken ct)
        {
            var data = await _context.EducationResults.Where(x => x.IdClient == idClient).Select(w => new DropDown
            {

                value = w.Id,
                text = w.ResultName

            }).ToListAsync(ct);
            return Ok(data);
        }

    }
}
