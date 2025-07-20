using HanaHRM.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HanaHRM.Controllers
{
    [Route("api/Common")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly HRMDbContext _context;

        public CommonController(HRMDbContext context)
        { 
            _context = context;
        }

        [HttpGet("departmentdropdown")]
        public async Task<IActionResult> GetDepartmentDropDown(int idClint,CancellationToken ct)
        {
            var data = await _context.Departments.Where(x=>x.IdClient == idClint).Select(d=> new DropDown { 
                
                value = d.Id,
                text = d.DepartName
              

            }).ToListAsync(ct);
            return Ok(data);
        }

        [HttpGet("designationdropdown")]
        public async Task<IActionResult> GetDesignationDropDown(int idClint,CancellationToken ct)
        {
            var data = await _context.Designations.Where(x => x.IdClient == idClint).Select(d=>new DropDown { 
            
                value = d.Id,
                text  = d.DesignationName

            }).ToListAsync(ct);
            return Ok(data);
        }


        [HttpGet("educationexaminationsdropdown")]
        public async Task<IActionResult> GetEducationExaminationsDropDown(int idClint,CancellationToken ct)
        {
            var data = await _context.EducationExaminations.Where(x => x.IdClient == idClint).Select(ee => new DropDown { 
                
                value = ee.Id, 
                text  = ee.ExamName 

            }).ToListAsync(ct);
            return Ok(data);
        }

        [HttpGet("educationresultsdropdown")]
        public async Task<IActionResult> GetEducationResultsDropDown(int idClint,CancellationToken ct)
        {
            var data = await _context.EducationResults.Where(x => x.IdClient == idClint).Select(er => new DropDown { 

                value = er.Id, 
                text  = er.ResultName 

            }) .ToListAsync(ct);
            return Ok(data);
        }

        [HttpGet("employeetypesdropdown")]
        public async Task<IActionResult> GetEmployeeTypesDropDown(int idClint,CancellationToken ct)
        {
            var data = await _context.EmployeeTypes.Where(x => x.IdClient == idClint).Select(et => new DropDown {
                
                
                value = et.Id, 
                text  = et.TypeName 
            
            }).ToListAsync(ct);
            return Ok(data);
        }

        [HttpGet("gendersdropdown")]
        public async Task<IActionResult> GetGendersDropDown(int idClint,CancellationToken ct)
        {
            var data = await _context.Genders.Where(x => x.IdClient == idClint).Select(g => new DropDown { 
                
                value = g.Id, 
                text  = g.GenderName 
            
            }).ToListAsync(ct);
            return Ok(data);
        }

        [HttpGet("jobtypesdropdown")]
        public async Task<IActionResult> GetJobTypesDropDown(int idClint,CancellationToken ct)
        {
            var data = await _context.JobTypes.Where(x => x.IdClient == idClint).Select(j => new DropDown { value = j.Id, text = j.JobTypeName }).ToListAsync(ct);
            return Ok(data);
        }

        [HttpGet("maritalstatusesdropdown")]
        public async Task<IActionResult> GetMaritalStatusesDropDown(int idClint,CancellationToken ct)
        {
            var data = await _context.MaritalStatuses.Where(x => x.IdClient == idClint).Select(m => new DropDown { 

                value = m.Id, 
                text  = m.MaritalStatusName 

            }).ToListAsync(ct);
            return Ok(data);
        }

        [HttpGet("relationshipdropdown")]
        public async Task<IActionResult> GetRelationshipDropDown(int idClint,CancellationToken ct)
        {
            var data = await _context.Relationships.Where(x => x.IdClient == idClint).Select(r => new DropDown {
                
                value = r.Id, 
                text  = r.RelationName 
            
            }).ToListAsync(ct);
            return Ok(data);
        }

        [HttpGet("religionsdropdown")]
        public async Task<IActionResult> GetReligionsDropDown(int idClint,CancellationToken ct)
        {
            var data = await _context.Religions.Where(x => x.IdClient == idClint).Select(rg => new DropDown { 
                
                value = rg.Id, 
                text  = rg.ReligionName    
                
            }).ToListAsync(ct);
            return Ok(data);
        }

        [HttpGet("sectionsdropdown")]
        public async Task<IActionResult> GetSectionsDropDown(int idClint,CancellationToken ct)
        {
            var data = await _context.Sections.Where(x => x.IdClient == idClint).Select(s => new DropDown { 
                
                value = s.Id,
                text  = s.SectionName 
            
            }).ToListAsync(ct);
            return Ok(data);
        }

        [HttpGet("weekoffsdropdown")]
        public async Task<IActionResult> GetWeekOffsDropDown(int idClint,CancellationToken ct)
        {
            var data = await _context.WeekOffs.Where(x => x.IdClient == idClint).Select(w => new DropDown { 
                
               value = w.Id, 
               text  = w.WeekOffDay 

            }).ToListAsync(ct);
            return Ok(data);
        }

    }
}
