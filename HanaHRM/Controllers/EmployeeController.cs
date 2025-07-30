using HanaHRM.DataAccess.Models;
using HanaHRM.DTO;
using HanaHRM.ListDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace HanaHRM.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController(HRMContext _context) : ControllerBase
    {
        [HttpGet]

        public async Task<IActionResult> GetEmployeeList([FromQuery] int idClient, CancellationToken cancellationToken) { 
                 
            var empList = await _context.Employees
                .AsNoTracking()
                .Where(e => e.IdClient == idClient && e.IsActive == true)
                .Select(ed => new EmployeeListDTO {
                    Id = ed.Id,
                    EmployeeName = ed.EmployeeName ?? "",
                    Designation = ed.Designation.DesignationName ?? "",
                }).ToListAsync();

            return Ok(empList);

        }

        /*public async Task<IActionResult> GetAllEmployeeDetails([FromQuery] int idClient,CancellationToken cancellationToken)
        {
            var employeeDTOs = await _context.Employees
                .AsNoTracking()
                .Where(e => e.IdClient == idClient && e.IsActive == true)
                .Select(ed => new EmployeeDTO
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
                DepartmentName = ed.Department.DepartName ?? "",
                Designation = ed.Designation.DesignationName ?? "",
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
                    EducationLevelName = edu.EducationLevel.EducationLevelName ?? "",
                    ExaminationName = edu.EducationExamination.ExamName ?? "",
                    ResultName = edu.EducationResult.ResultName ?? "",
                }).ToList(),

                    EmployeeFamilyInfos = ed.EmployeeFamilyInfos.Select(cert => new EmployeeFamilyInfoDTO
                    {
                        IdClient = cert.IdClient,
                        Id = cert.Id,
                        Name = cert.Name,
                        IdGender = cert.IdGender,
                        IdRelationship = cert.IdRelationship,
                        DateOfBirth = cert.DateOfBirth,
                        ContactNo = cert.ContactNo,
                        CurrentAddress = cert.CurrentAddress,
                        PermanentAddress = cert.PermanentAddress,
                        SetDate = DateTime.Now,

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
            }).ToListAsync();

            return Ok(employeeDTOs);
        }
*/

        [HttpGet("getemployeebyid")]
        public async Task<IActionResult> GetEmployeeById([FromQuery] int Idclient,[FromQuery] int id ,CancellationToken cancellationToken)
        {
            var employeeDTOs = await _context.Employees
                .AsNoTracking()
                .Where(e => e.IdClient == Idclient && e.Id == id)
                .Select(ed => new EmployeeDTO
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
                Designation = ed.Designation.DesignationName ?? "",
                ReligionName = ed.Religion.ReligionName,
                DepartmentName = ed.Department.DepartName,
                MaritalStatusName = ed.MaritalStatus.MaritalStatusName,
                    
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
                    EducationLevelName = edu.EducationLevel.EducationLevelName ?? "",
                    ExaminationName = edu.EducationExamination.ExamName ?? "",
                    ResultName = edu.EducationResult.ResultName ?? "",
                }).ToList(),

                    EmployeeFamilyInfos = ed.EmployeeFamilyInfos.Select(cert => new EmployeeFamilyInfoDTO
                    {
                        IdClient = cert.IdClient,
                        Id = cert.Id,
                        Name = cert.Name,
                        IdGender = cert.IdGender,
                        IdRelationship = cert.IdRelationship,
                        DateOfBirth = cert.DateOfBirth,
                        ContactNo = cert.ContactNo,
                        CurrentAddress = cert.CurrentAddress,
                        PermanentAddress = cert.PermanentAddress,
                        SetDate = DateTime.Now,

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
            }).ToListAsync(cancellationToken);
            return Ok(employeeDTOs);
        }

        private async Task<byte[]?> ConvertFileToByteArrayAsync(IFormFile? file)
        {
            if (file == null || file.Length == 0)

                return null;

            using var memoryStream = new MemoryStream();

            await file.CopyToAsync(memoryStream);

            return memoryStream.ToArray();

        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromForm] EmployeeDTO empDto, CancellationToken cancellationToken)
        {
          
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

                EmployeeFamilyInfos = empDto.EmployeeFamilyInfos.Select(cert => new EmployeeFamilyInfo
                {
                    IdClient = cert.IdClient,
                    Name = cert.Name,
                    IdGender = cert.IdGender,
                    IdRelationship = cert.IdRelationship,
                    DateOfBirth = cert.DateOfBirth,
                    ContactNo = cert.ContactNo,
                    CurrentAddress = cert.CurrentAddress,
                    PermanentAddress = cert.PermanentAddress,
                    SetDate = DateTime.Now,

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
            await _context.Employees.AddAsync(emp, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
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
            (new byte[] { 0x25, 0x50, 0x44, 0x46 }, "application/pdf"),
            (new byte[] { 0x00, 0x00, 0x01, 0x00 }, "image/x-icon"),
            (new byte[] { 0x50, 0x4B, 0x03, 0x04 }, "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
            };

            foreach (var (signature, mime) in signatures)
            {
                if (data.Length >= signature.Length && data.AsSpan(0, signature.Length).SequenceEqual(signature))
                    return mime;
            }

            return "application/octet-stream";
        }


        [HttpGet("employeeimage")]
        public async Task<IActionResult> GetEmployeeImage([FromQuery]int IdClient,[FromQuery]int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(ed => ed.IdClient == IdClient && ed.Id == id);

            if (employee == null || employee.EmployeeImage == null)
                return NotFound("Image not found");

            var mimeType = GetMimeType(employee.EmployeeImage);

            return File(employee.EmployeeImage, mimeType);
        }

        [HttpGet("employeedocument")]
        public async Task<IActionResult> GetEmployeeDocument([FromQuery] int IdClient, [FromQuery] int id)
        {
            var employeeDocumnet = await _context.EmployeeDocuments.FirstOrDefaultAsync(ed => ed.IdClient == IdClient && ed.IdEmployee == id);

            if (employeeDocumnet == null || employeeDocumnet.UploadedFile == null)
                return NotFound("Document not found");

            var mimeType = GetMimeType(employeeDocumnet.UploadedFile);

            return File(employeeDocumnet.UploadedFile, mimeType);
        }


        [HttpPut]
        public async Task<int> UpdateAsync([FromForm] EmployeeDTO employee,CancellationToken cancellationToken)
        {
            if (employee == null)
                throw new Exception($"data not found: {nameof(employee)}");

            var idClient = employee.IdClient;
            var id = employee.Id;

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
                .Where(ed => ed.IdClient == idClient && !employee.EmployeeDocuments.Any(d => d.IdClient == ed.IdClient && d.Id == ed.Id))
                .ToList();
            if (deletedEmployeeDocumentList.Any())
            {
                _context.EmployeeDocuments.RemoveRange(deletedEmployeeDocumentList);
            }


            var deletedEmployeeEducationInfoList = existingEmployee.EmployeeEducationInfos
                .Where(eei => eei.IdClient ==idClient && !employee.EmployeeEducationInfos.Any(ei => ei.IdClient == eei.IdClient && ei.Id == eei.Id))
                .ToList();
            if (deletedEmployeeEducationInfoList.Any())
            {
                _context.EmployeeEducationInfos.RemoveRange(deletedEmployeeEducationInfoList);
            }

            var deletedCertificationList = existingEmployee.EmployeeProfessionalCertifications
                .Where(epc => epc.IdClient == idClient && !employee.EmployeeProfessionalCertifications.Any(c => c.IdClient == epc.IdClient && c.Id == epc.Id))
                .ToList();

            if (deletedCertificationList.Any())
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

            foreach (var item in employee.EmployeeFamilyInfos)
            {
                var existingEntry = existingEmployee.EmployeeFamilyInfos.FirstOrDefault(ei => ei.IdClient == item.IdClient && ei.Id == item.Id);
                if (existingEntry != null)
                {
                    existingEntry.Name = item.Name;
                    existingEntry.IdGender = item.IdGender;
                    existingEntry.IdRelationship = item.IdRelationship;
                    existingEntry.SetDate = DateTime.Now;


                }
                else
                {
                    var familyinfos = new EmployeeFamilyInfo
                    {
                        IdClient = item.IdClient,
                        IdEmployee = existingEmployee.Id,
                        Name = item.Name,
                        IdGender = item.IdGender,
                        IdRelationship = item.IdRelationship,

                        SetDate = DateTime.Now
                    };
                    existingEmployee.EmployeeFamilyInfos.Add(familyinfos);
                }
            }

            var result = await _context.SaveChangesAsync();

            return result;
        }


        [HttpPatch("{idClient}/{id}")]
        public async Task<IActionResult> HideEmployee([FromRoute] int idClient, [FromRoute] int id,CancellationToken cancellationToken)
        {
            var empToHide = await _context.Employees.FirstOrDefaultAsync(e => e.IdClient == idClient && e.Id == id, cancellationToken);
            if (empToHide == null)
            {
                return NotFound(new { error = "Employee not found!" });
            }


            empToHide.IsActive = false;

             await _context.SaveChangesAsync(cancellationToken);

            return Ok(new { message = "Data Deleted successfully" });
        }

    }
}
