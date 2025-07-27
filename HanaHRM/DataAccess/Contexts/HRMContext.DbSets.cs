using Microsoft.EntityFrameworkCore;

namespace HanaHRM.DataAccess.Models;

public partial class HRMContext 
{
    public virtual DbSet<Department> Departments { get; set; }
    public virtual DbSet<Designation> Designations { get; set; }
    public virtual DbSet<EducationExamination> EducationExaminations { get; set; }
    public virtual DbSet<EducationLevel> EducationLevels { get; set; }
    public virtual DbSet<EducationResult> EducationResults { get; set; }
    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<EmployeeDocument> EmployeeDocuments { get; set; }
    public virtual DbSet<EmployeeEducationInfo> EmployeeEducationInfos { get; set; }
    public virtual DbSet<EmployeeFamilyInfo> EmployeeFamilyInfos { get; set; }
    public virtual DbSet<EmployeeProfessionalCertification> EmployeeProfessionalCertifications { get; set; }
    public virtual DbSet<EmployeeType> EmployeeTypes { get; set; }
    public virtual DbSet<Gender> Genders { get; set; }
    public virtual DbSet<JobType> JobTypes { get; set; }
    public virtual DbSet<MaritalStatus> MaritalStatuses { get; set; }
    public virtual DbSet<Relationship> Relationships { get; set; }
    public virtual DbSet<Religion> Religions { get; set; }
    public virtual DbSet<Section> Sections { get; set; }
    public virtual DbSet<WeekOff> WeekOffs { get; set; }
}
