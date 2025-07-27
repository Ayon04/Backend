using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HanaHRM.DataAccess.Models;

[PrimaryKey("IdClient", "Id")]
[Table("Employee")]
public partial class Employee
{
    [Key]
    public int IdClient { get; set; }

    [Key]
    public int Id { get; set; }

    [StringLength(250)]
    public string? EmployeeName { get; set; }

    [StringLength(250)]
    public string? EmployeeNameBangla { get; set; }

    public byte[]? EmployeeImage { get; set; }

    [StringLength(250)]
    public string? FatherName { get; set; }

    [StringLength(250)]
    public string? MotherName { get; set; }

    public int? IdReportingManager { get; set; }

    public int? IdJobType { get; set; }

    public int? IdEmployeeType { get; set; }

    public DateTime? BirthDate { get; set; }

    public DateTime? JoiningDate { get; set; }

    public int? IdGender { get; set; }

    public int? IdReligion { get; set; }

    public int IdDepartment { get; set; }

    public int IdSection { get; set; }

    public int? IdDesignation { get; set; }

    public bool? HasOvertime { get; set; }

    public bool? HasAttendenceBonus { get; set; }

    public int? IdWeekOff { get; set; }

    [StringLength(250)]
    public string? Address { get; set; }

    [StringLength(250)]
    public string? PresentAddress { get; set; }

    [StringLength(30)]
    public string? NationalIdentificationNumber { get; set; }

    [StringLength(250)]
    public string? ContactNo { get; set; }

    public int? IdMaritalStatus { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? SetDate { get; set; }

    [StringLength(50)]
    public string? CreatedBy { get; set; }

    [ForeignKey("IdClient, IdDepartment")]
    [InverseProperty("Employees")]
    // public virtual Department Department { get; set; } = null!;

    public virtual Department? Department { get; set; }

    [ForeignKey("IdClient, IdDesignation")]
    [InverseProperty("Employees")]
    public virtual Designation? Designation { get; set; }

    [InverseProperty("Employee")]
    public virtual ICollection<EmployeeDocument> EmployeeDocuments { get; set; } = new List<EmployeeDocument>();

    [InverseProperty("Employee")]
    public virtual ICollection<EmployeeEducationInfo> EmployeeEducationInfos { get; set; } = new List<EmployeeEducationInfo>();

    [InverseProperty("Employee")]
    public virtual ICollection<EmployeeProfessionalCertification> EmployeeProfessionalCertifications { get; set; } = new List<EmployeeProfessionalCertification>();

    [InverseProperty("Employee")]
    public virtual ICollection<EmployeeFamilyInfo> EmployeeFamilyInfos { get; set; } = new List<EmployeeFamilyInfo>();

    [ForeignKey("IdClient, IdEmployeeType")]
    [InverseProperty("Employees")]
    public virtual EmployeeType? EmployeeType { get; set; }

    [ForeignKey("IdClient, IdGender")]
    [InverseProperty("Employees")]
    public virtual Gender? Gender { get; set; }

    [ForeignKey("IdClient, IdJobType")]
    [InverseProperty("Employees")]
    public virtual JobType? JobType { get; set; }

    [ForeignKey("IdClient, IdMaritalStatus")]
    [InverseProperty("Employees")]
    public virtual MaritalStatus? MaritalStatus { get; set; }

    [ForeignKey("IdClient, IdReligion")]
    [InverseProperty("Employees")]
    public virtual Religion? Religion { get; set; }

    [ForeignKey("IdClient, IdSection")]
    [InverseProperty("Employees")]
    //public virtual Section Section { get; set; } = null!;
    public virtual Section? Section { get; set; }


    [ForeignKey("IdClient, IdWeekOff")]
    [InverseProperty("Employees")]  
    public virtual WeekOff? WeekOff { get; set; }
}
