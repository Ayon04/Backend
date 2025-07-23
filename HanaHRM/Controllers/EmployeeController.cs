using HanaHRM.DataAccess.Models;
using HanaHRM.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
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
        [HttpGet("allemployees")]
        public async Task<IActionResult> GetAllEmployees(CancellationToken ct)
        {
            
            var data = await _context.Employees.Where(e => e.IsActive == true && e.IdClient == clientId).ToListAsync(ct);
            return Ok(data);
        }

        [HttpGet("allemployeedocuments")]
        public async Task<IActionResult> GetAllEmployeeDocuments(CancellationToken ct)
        {
            var data = await _context.EmployeeDocuments.AsNoTracking().Where(e => e.IdClient == clientId).ToListAsync(ct);
            return Ok(data);
        }
        [HttpGet("allemployeeeducationinfo")]
        public async Task<IActionResult> GetAllEmployeeEducationInfo(CancellationToken ct)
        {
            var data = await _context.EmployeeEducationInfos.AsNoTracking().Where(e => e.IdClient == clientId).ToListAsync(ct);
            return Ok(data);
        }
        [HttpGet("allemployeefamilyinfo")]
        public async Task<IActionResult> GetAllEmployeeFamilyInfo(CancellationToken ct)
        {
            var data = await _context.EmployeeFamilyInfos.AsNoTracking().Where(e => e.IdClient == clientId).ToListAsync(ct);
            return Ok(data);
        }

        [HttpGet("allemployeeprofessionalcertifications")]
        public async Task<IActionResult> GetAllEmployeeProfessionalCertifications(CancellationToken ct)
        {
            var data = await _context.EmployeeProfessionalCertifications.AsNoTracking().Where(e => e.IdClient == clientId).ToListAsync(ct);
            return Ok(data);
        }

        //GET APIS 

        [HttpGet("allemployeedetails")]
        public async Task<IActionResult> GetAllEmployeeDetails(CancellationToken ct)
        {
         
            var employees = await _context.Employees
                .Where(e => e.IdClient == clientId)
                .Include(e => e.EmployeeDocuments)
                .Include(e => e.EmployeeEducationInfos)
                .Include(e => e.EmployeeProfessionalCertifications)
                .AsNoTracking()
                .ToListAsync(ct);

            var employeeDTOs = employees.Select(ed => new EmployeeDTO
            {
                Id = ed.Id,
                EmployeeName = ed.EmployeeName ?? "",
                EmployeeNameBangla = ed.EmployeeNameBangla ?? "",
                FatherName = ed.FatherName ?? "",
                MotherName = ed.MotherName ?? "",
                IdReportingManager = ed.IdReportingManager,
                IdJobType = ed.IdJobType,
                IdEmployeeType = ed.IdEmployeeType ?? null,
                BirthDate = ed.BirthDate ?? null,
                JoiningDate = ed.JoiningDate ?? null,
                IdGender = ed.IdGender ?? null,
                IdReligion = ed.IdReligion ?? null,
                IdDepartment = ed.IdDepartment,
                IdSection = ed.IdSection,
                IdDesignation = ed.IdDesignation ?? null,
                HasOvertime = (bool)ed.HasOvertime.GetValueOrDefault(),
                HasAttendenceBonus = (bool)ed.HasAttendenceBonus.GetValueOrDefault(),
                IdWeekOff = ed.IdWeekOff ?? null,
                Address = ed.Address ?? "",
                PresentAddress = ed.PresentAddress ?? "",
                NationalIdentificationNumber = ed.NationalIdentificationNumber ?? "",
                ContactNo = ed.ContactNo ?? "",
                IdMaritalStatus = ed.IdMaritalStatus ?? null,
                CreatedBy = ed.CreatedBy ?? "",
                EmployeeDocuments = ed.EmployeeDocuments.Select(d => new EmployeeDocumentDTO
                {
                    IdClient = d.IdClient,
                    Id = d.Id,
                    IdEmployee = d.IdEmployee,
                    DocumentName = d.DocumentName,
                    FileName = d.FileName,
                    UploadedFileExtention = d.UploadedFileExtention ?? "",
                    UploadDate = d.UploadDate,
                    SetDate = d.SetDate ?? null,
                    CreatedBy = d.CreatedBy ?? "",
                }).ToList(),

                EmployeeEducationInfos = ed.EmployeeEducationInfos.Select(edu => new EmployeeEducationInfoDTO
                {
                    IdClient = edu.IdClient,
                    Id = edu.Id,
                    IdEmployee = edu.IdEmployee,
                    IdEducationLevel = edu.IdEducationLevel,
                    IdEducationExamination = edu.IdEducationExamination,
                    IdEducationResult = edu.IdEducationResult,
                    Cgpa = edu.Cgpa ?? null,
                    ExamScale = edu.ExamScale ?? null,
                    Marks = edu.Marks ?? null,
                    Major = edu.Major ?? "",
                    PassingYear = edu.PassingYear,
                    InstituteName = edu.InstituteName,
                    IsForeignInstitute = edu.IsForeignInstitute,
                    Duration = edu.Duration ?? null,
                    Achievement = edu.Achievement,
                    SetDate = edu.SetDate,
                    CreatedBy = edu.CreatedBy,
                    EducationLevelName = edu.EducationLevel?.EducationLevelName ?? "",
                    ExaminationName = edu.EducationExamination?.ExamName ?? "",
                    ResultName = edu.EducationResult?.ResultName ?? "",
                }).ToList(),

                EmployeeProfessionalCertifications = ed.EmployeeProfessionalCertifications.Select(cert => new EmployeeProfessionalCertificationDTO
                {
                    IdClient = cert.IdClient,
                    Id = cert.Id,
                    IdEmployee = cert.IdEmployee,
                    CertificationTitle = cert.CertificationTitle,
                    CertificationInstitute = cert.CertificationInstitute,
                    InstituteLocation = cert.InstituteLocation,
                    FromDate = cert.FromDate,
                    ToDate = cert.ToDate ?? null,
                    SetDate = cert.SetDate ?? null,
                    CreatedBy = cert.CreatedBy ?? null,
                }).ToList()
            }).ToList();

            return Ok(employeeDTOs);
        }


        [HttpGet("{Idclient}/{id}")]
        public async Task<IActionResult> GetEmployeeById(int Idclient,int id ,CancellationToken ct)
        {

            var employees = await _context.Employees
                .Where(e => e.IdClient == clientId && e.Id == id)
                .Include(e => e.EmployeeDocuments)
                .Include(e => e.EmployeeEducationInfos)
                .Include(e => e.EmployeeProfessionalCertifications)
                .AsNoTracking()
                .ToListAsync(ct);

            var employeeDTOs = employees.Select(ed => new EmployeeDTO
            {
                Id = ed.Id,
                EmployeeName = ed.EmployeeName ?? "",
                EmployeeNameBangla = ed.EmployeeNameBangla ?? "",
                FatherName = ed.FatherName ?? "",
                MotherName = ed.MotherName ?? "",
                IdReportingManager = ed.IdReportingManager,
                IdJobType = ed.IdJobType,
                IdEmployeeType = ed.IdEmployeeType ?? null,
                BirthDate = ed.BirthDate ?? null,
                JoiningDate = ed.JoiningDate ?? null,
                IdGender = ed.IdGender ?? null,
                IdReligion = ed.IdReligion ?? null,
                IdDepartment = ed.IdDepartment,
                IdSection = ed.IdSection,
                IdDesignation = ed.IdDesignation ?? null,
                HasOvertime = (bool)ed.HasOvertime.GetValueOrDefault(),
                HasAttendenceBonus = (bool)ed.HasAttendenceBonus.GetValueOrDefault(),
                IdWeekOff = ed.IdWeekOff ?? null,
                Address = ed.Address ?? "",
                PresentAddress = ed.PresentAddress ?? "",
                NationalIdentificationNumber = ed.NationalIdentificationNumber ?? "",
                ContactNo = ed.ContactNo ?? "",
                IdMaritalStatus = ed.IdMaritalStatus ?? null,
                CreatedBy = ed.CreatedBy ?? "",
                EmployeeDocuments = ed.EmployeeDocuments.Select(d => new EmployeeDocumentDTO
                {
                    IdClient = d.IdClient,
                    Id = d.Id,
                    IdEmployee = d.IdEmployee,
                    DocumentName = d.DocumentName,
                    FileName = d.FileName,
                    UploadedFileExtention = d.UploadedFileExtention ?? "",
                    UploadDate = d.UploadDate,
                    SetDate = d.SetDate ?? null,
                    CreatedBy = d.CreatedBy ?? "",
                }).ToList(),

                EmployeeEducationInfos = ed.EmployeeEducationInfos.Select(edu => new EmployeeEducationInfoDTO
                {
                    IdClient = edu.IdClient,
                    Id = edu.Id,
                    IdEmployee = edu.IdEmployee,
                    IdEducationLevel = edu.IdEducationLevel,
                    IdEducationExamination = edu.IdEducationExamination,
                    IdEducationResult = edu.IdEducationResult,
                    Cgpa = edu.Cgpa ?? null,
                    ExamScale = edu.ExamScale ?? null,
                    Marks = edu.Marks ?? null,
                    Major = edu.Major ?? "",
                    PassingYear = edu.PassingYear,
                    InstituteName = edu.InstituteName,
                    IsForeignInstitute = edu.IsForeignInstitute,
                    Duration = edu.Duration ?? null,
                    Achievement = edu.Achievement,
                    SetDate = edu.SetDate,
                    CreatedBy = edu.CreatedBy,
                    EducationLevelName = edu.EducationLevel?.EducationLevelName ?? "",
                    ExaminationName = edu.EducationExamination?.ExamName ?? "",
                    ResultName = edu.EducationResult?.ResultName ?? "",
                }).ToList(),

                EmployeeProfessionalCertifications = ed.EmployeeProfessionalCertifications.Select(cert => new EmployeeProfessionalCertificationDTO
                {
                    IdClient = cert.IdClient,
                    Id = cert.Id,
                    IdEmployee = cert.IdEmployee,
                    CertificationTitle = cert.CertificationTitle,
                    CertificationInstitute = cert.CertificationInstitute,
                    InstituteLocation = cert.InstituteLocation,
                    FromDate = cert.FromDate,
                    ToDate = cert.ToDate ?? null,
                    SetDate = cert.SetDate ?? null,
                    CreatedBy = cert.CreatedBy ?? null,
                }).ToList()
            }).ToList();



            return Ok(employeeDTOs);
        }


           [HttpPost("create")]
            public async Task<IActionResult> CreateEmployee([FromForm] EmployeeDTO empDto, CancellationToken ct)
            {
            async Task<byte[]?> ConvertFileToByteArrayAsync(IFormFile? file)

            {

                if (file == null || file.Length == 0)

                    return null;

                using var memoryStream = new MemoryStream();

                await file.CopyToAsync(memoryStream);

                return memoryStream.ToArray();

            }

            var emp = new Employee
            {
                    EmployeeName = empDto.EmployeeName ,
                    EmployeeNameBangla = empDto.EmployeeNameBangla,
                    EmployeeImage = await ConvertFileToByteArrayAsync(empDto.EmpImg),
                    FatherName = empDto.FatherName,
                    MotherName = empDto.MotherName,
                    IdDepartment = empDto.IdDepartment,
                    IdSection = empDto.IdSection,
                    IdDesignation = empDto.IdDesignation,
                    IdGender = empDto.IdGender,
                    IdReligion = empDto.IdReligion,
                    IdJobType = empDto.IdJobType,
                    IdEmployeeType = empDto.IdEmployeeType,
                    IdMaritalStatus = empDto.IdMaritalStatus,
                    IdWeekOff = empDto.IdWeekOff,
                    HasOvertime = empDto.HasOvertime,
                    HasAttendenceBonus = empDto.HasAttendenceBonus,
                    Address = empDto.Address,
                    PresentAddress = empDto.PresentAddress,
                    NationalIdentificationNumber = empDto.NationalIdentificationNumber,
                    ContactNo = empDto.ContactNo,
                    JoiningDate = empDto.JoiningDate,
                    BirthDate = empDto.BirthDate,
                    SetDate = DateTime.Now,
                    EmployeeDocuments = new List<EmployeeDocument>(),


                EmployeeEducationInfos = empDto.EmployeeEducationInfos.Select(edu => new EmployeeEducationInfo
                 {
                        IdClient = edu.IdClient,
                        IdEducationLevel = edu.IdEducationLevel,
                        IdEducationExamination = edu.IdEducationExamination,
                        IdEducationResult = edu.IdEducationResult,
                        Cgpa = edu.Cgpa,
                        ExamScale = edu.ExamScale,
                        Marks = edu.Marks,
                        Major = edu.Major,
                        PassingYear = edu.PassingYear,
                        InstituteName = edu.InstituteName,
                        IsForeignInstitute = edu.IsForeignInstitute,
                        Duration = edu.Duration ?? default,
                        Achievement = edu.Achievement,
                        SetDate = DateTime.Now
                    }).ToList(),
               
                EmployeeProfessionalCertifications = empDto.EmployeeProfessionalCertifications.Select(cert => new EmployeeProfessionalCertification
                {
                    IdClient = cert.IdClient,
                    CertificationTitle = cert.CertificationTitle,
                    CertificationInstitute = cert.CertificationInstitute,
                    InstituteLocation = cert.InstituteLocation,
                    FromDate = cert.FromDate,
                    ToDate = cert.ToDate,
                    SetDate = DateTime.Now
                }).ToList(),
            };


            foreach (var doc in empDto.EmployeeDocuments)
            {
                var uploadedBytes = await ConvertFileToByteArrayAsync(doc.DocumentFile);
                var extension = Path.GetExtension(doc.DocumentFile?.FileName);
                emp.EmployeeDocuments.Add(new EmployeeDocument
                {
                    IdClient = doc.IdClient,
                    DocumentName = doc.DocumentName,
                    FileName = doc.FileName,
                    UploadDate = doc.UploadDate,
                    UploadedFileExtention = extension,
                    UploadedFile = uploadedBytes,
                    SetDate = DateTime.Now
                });
            }

            await _context.Employees.AddAsync(emp, ct);
            await _context.SaveChangesAsync(ct);
            return Ok(new { message = "Employee created successfully!", emp.Id });
            }


        private string GetMimeType(byte[] data)
        {
            if (data == null || data.Length == 0)
                return "application/octet-stream";

            var signatures = new (byte[] signature, string mime)[]
            {
            (new byte[] { 0xFF, 0xD8 }, "image/jpeg"),
            (new byte[] { 0x89, 0x50, 0x4E, 0x47 }, "image/png"),
            (new byte[] { 0x47, 0x49, 0x46 }, "image/gif"),
            (new byte[] { 0x42, 0x4D }, "image/bmp"),
            (new byte[] { 0x49, 0x49, 0x2A, 0x00 }, "image/tiff"),
            (new byte[] { 0x4D, 0x4D, 0x00, 0x2A }, "image/tiff"),
            (new byte[] { 0x25, 0x50, 0x44, 0x46 }, "application/pdf"),
            (new byte[] { 0x50, 0x4B, 0x03, 0x04 }, "application/zip"),
            (new byte[] { 0x52, 0x61, 0x72, 0x21 }, "application/x-rar-compressed"),
            (new byte[] { 0x37, 0x7A, 0xBC, 0xAF, 0x27, 0x1C }, "application/x-7z-compressed"),
            (new byte[] { 0x00, 0x00, 0x01, 0x00 }, "image/x-icon"),
            (new byte[] { 0x00, 0x00, 0x02, 0x00 }, "image/x-icon")
            };

            foreach (var (signature, mime) in signatures)
            {
                if (data.Length >= signature.Length && data.AsSpan(0, signature.Length).SequenceEqual(signature))
                    return mime;
            }

            return "application/octet-stream";
        }


       /* [HttpGet("image/{IdClient}/{id}")]
        public async Task<IActionResult> GetEmployeeImage(int IdClient,int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(ed => ed.IdClient == IdClient && ed.Id == id);

            if (employee == null || employee.EmployeeImage == null)
                return NotFound("Image not found");

            var mimeType = GetMimeType(employee.EmployeeImage);

            return File(employee.EmployeeImage, mimeType);
        }*/

        [HttpGet("document/{IdClient}/{id}")]
        public async Task<IActionResult> GetEmployeeDocument(int IdClient, int id)
        {
            var employeeDocumnet = await _context.EmployeeDocuments.FirstOrDefaultAsync(ed => ed.IdClient == IdClient && ed.IdEmployee == id);

            if (employeeDocumnet == null || employeeDocumnet.UploadedFile == null)
                return NotFound("Document not found");

            var mimeType = GetMimeType(employeeDocumnet.UploadedFile);

            return File(employeeDocumnet.UploadedFile, mimeType);
        }


        [HttpPut("update/{idClient}/{id}")]
        public async Task<int> UpdateAsync([FromBody] EmployeeDTO employee, int idClient, int id ,CancellationToken cancellationToken)
        {
            if (employee == null)
                throw new Exception($"data not found: {nameof(employee)}");

       

            var existingEmployee = await _context.Employees
                .Include(e => e.EmployeeDocuments)
                .Include(e => e.EmployeeEducationInfos)
                .Include(e => e.EmployeeProfessionalCertifications)
                .FirstOrDefaultAsync(e => e.IdClient == idClient && e.Id == id, cancellationToken);

            if (existingEmployee == null) return 0;

            existingEmployee.EmployeeName = employee.EmployeeName ?? existingEmployee.EmployeeName;
            existingEmployee.EmployeeNameBangla = employee.EmployeeNameBangla ?? existingEmployee.EmployeeNameBangla;
            existingEmployee.FatherName = employee.FatherName ?? existingEmployee.FatherName;
            existingEmployee.MotherName = employee.MotherName ?? existingEmployee.MotherName;
            existingEmployee.IdDepartment = employee.IdDepartment;
            existingEmployee.IdSection = employee.IdSection;
            existingEmployee.BirthDate = employee.BirthDate ?? existingEmployee.BirthDate;
            existingEmployee.Address = employee.Address ?? existingEmployee.Address;
            existingEmployee.PresentAddress = employee.PresentAddress ?? existingEmployee.PresentAddress;
            existingEmployee.NationalIdentificationNumber = employee.NationalIdentificationNumber ?? existingEmployee.NationalIdentificationNumber;
            existingEmployee.ContactNo = employee.ContactNo ?? existingEmployee.ContactNo;
            existingEmployee.IsActive = employee.IsActive ?? existingEmployee.IsActive;
            existingEmployee.SetDate = DateTime.Now;


            //delete obsolete data

            var deletedEmployeeDocumentList = existingEmployee.EmployeeDocuments
                .Where(ed => ed.IdClient == ed.IdClient && !employee.EmployeeDocuments.Any(d => d.IdClient == ed.IdClient && d.Id == ed.Id))
                .ToList();
            if (deletedEmployeeDocumentList != null)
            {
                _context.EmployeeDocuments.RemoveRange(deletedEmployeeDocumentList);
            }


            var deletedEmployeeEducationInfoList = existingEmployee.EmployeeEducationInfos
                .Where(eei => eei.IdClient == eei.IdClient && !employee.EmployeeEducationInfos.Any(ei => ei.IdClient == eei.IdClient && ei.Id == eei.Id))
                .ToList();
            if (deletedEmployeeEducationInfoList != null)
            {
                _context.EmployeeEducationInfos.RemoveRange(deletedEmployeeEducationInfoList);
            }

            var deletedCertificationList = existingEmployee.EmployeeProfessionalCertifications
                .Where(epc => epc.IdClient == epc.IdClient && !employee.EmployeeProfessionalCertifications.Any(c => c.IdClient == epc.IdClient && c.Id == epc.Id))
                .ToList();

            if (deletedCertificationList != null)
            {
                _context.EmployeeProfessionalCertifications.RemoveRange(deletedCertificationList);
            }


            foreach (var item in employee.EmployeeDocuments)
            {
                var existingEntry = existingEmployee.EmployeeDocuments.FirstOrDefault(ed => ed.IdClient == item.IdClient && ed.Id == item.Id);
                if (existingEntry != null)
                {
                    existingEntry.DocumentName = item.DocumentName;
                    existingEntry.FileName = item.FileName;
                    existingEntry.UploadDate = item.UploadDate;
                    existingEntry.UploadedFileExtention = item.UploadedFileExtention;
                    existingEntry.SetDate = DateTime.UtcNow;
                }
                else
                {
                    var newEmployeeDocument = new EmployeeDocument()
                    {
                        IdClient = item.IdClient,
                        IdEmployee = existingEmployee.Id,
                        DocumentName = item.DocumentName,
                        FileName = item.FileName,
                        UploadDate = item.UploadDate,
                        UploadedFileExtention = item.UploadedFileExtention,
                        SetDate = DateTime.UtcNow
                    };

                    existingEmployee.EmployeeDocuments.Add(newEmployeeDocument);
                }
            }


            foreach (var item in employee.EmployeeEducationInfos)
            {
                var existingEntry = existingEmployee.EmployeeEducationInfos.FirstOrDefault(ei => ei.IdClient == item.IdClient && ei.Id == item.Id);
                if (existingEntry != null)
                {
                    existingEntry.IdEducationLevel = item.IdEducationLevel;
                    existingEntry.IdEducationExamination = item.IdEducationExamination;
                    existingEntry.IdEducationResult = item.IdEducationResult;
                    existingEntry.Cgpa = item.Cgpa;
                    existingEntry.Marks = item.Marks;
                    existingEntry.PassingYear = item.PassingYear;
                    existingEntry.InstituteName = item.InstituteName;
                    existingEntry.Major = item.Major;
                    existingEntry.IsForeignInstitute = item.IsForeignInstitute;
                    existingEntry.Duration = item.Duration;
                    existingEntry.Achievement = item.Achievement;
                    existingEntry.SetDate = DateTime.Now;
                }
                else
                {
                    var newEmployeeEducationInfo = new EmployeeEducationInfo()
                    {
                        IdClient = item.IdClient,
                        IdEmployee = existingEmployee.Id,
                        IdEducationLevel = item.IdEducationLevel,
                        IdEducationExamination = item.IdEducationExamination,
                        IdEducationResult = item.IdEducationResult,
                        Cgpa = item.Cgpa,
                        Marks = item.Marks,
                        PassingYear = item.PassingYear,
                        InstituteName = item.InstituteName,
                        Major = item.Major,
                        IsForeignInstitute = item.IsForeignInstitute,
                        Duration = item.Duration,
                        Achievement = item.Achievement,
                        SetDate = DateTime.UtcNow
                    };

                    existingEmployee.EmployeeEducationInfos.Add(newEmployeeEducationInfo);
                }
            }


            foreach (var item in employee.EmployeeProfessionalCertifications)
            {
                var existingEntry = existingEmployee.EmployeeProfessionalCertifications.FirstOrDefault(ei => ei.IdClient == item.IdClient && ei.Id == item.Id);
                if (existingEntry != null)
                {
                    existingEntry.CertificationTitle = item.CertificationTitle;
                    existingEntry.CertificationInstitute = item.CertificationInstitute;
                    existingEntry.InstituteLocation = item.InstituteLocation;
                    existingEntry.FromDate = item.FromDate;
                    existingEntry.ToDate = item.ToDate;
                    existingEntry.SetDate = DateTime.Now;
                }
                else
                {
                    var newCertification = new EmployeeProfessionalCertification
                    {
                        IdClient = item.IdClient,
                        IdEmployee = existingEmployee.Id,
                        CertificationTitle = item.CertificationTitle,
                        CertificationInstitute = item.CertificationInstitute,
                        InstituteLocation = item.InstituteLocation,
                        FromDate = item.FromDate,
                        ToDate = item.ToDate,
                        SetDate = DateTime.Now
                    };
                    existingEmployee.EmployeeProfessionalCertifications.Add(newCertification);
                }
            }

            var result = await _context.SaveChangesAsync();

            return result;
        }


        [HttpDelete("delete/{idClient}/{id}")]
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
        [HttpPatch("delete/{idClient}/{id}")]
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
