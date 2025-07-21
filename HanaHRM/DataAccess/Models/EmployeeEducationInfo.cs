using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HanaHRM.DataAccess.Models;

[PrimaryKey("IdClient", "Id")]
[Table("EmployeeEducationInfo")]
[Index("IdClient", "IdEmployee", "IdEducationLevel", "IdEducationExamination", Name = "UNQ_EmployeeEducationInfo", IsUnique = true)]
public partial class EmployeeEducationInfo
{
    [Key]
    public int IdClient { get; set; }

    [Key]
    public int Id { get; set; }

    public int IdEmployee { get; set; }

    public int IdEducationLevel { get; set; }

    public int IdEducationExamination { get; set; }

    public int IdEducationResult { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal? Cgpa { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal? ExamScale { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal? Marks { get; set; }

    [StringLength(50)]
    public string Major { get; set; } = null!;

    [Column(TypeName = "numeric(18, 2)")]
    public decimal PassingYear { get; set; }

    [StringLength(250)]
    public string InstituteName { get; set; } = null!;

    public bool IsForeignInstitute { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal? Duration { get; set; }

    public string? Achievement { get; set; }

    public DateTime? SetDate { get; set; }

    [StringLength(50)]
    public string? CreatedBy { get; set; }

    [ForeignKey("IdClient, IdEducationExamination")]
    [InverseProperty("EmployeeEducationInfos")]
    public virtual EducationExamination EducationExamination { get; set; } = null!;

    [ForeignKey("IdClient, IdEducationLevel")]
    [InverseProperty("EmployeeEducationInfos")]
    public virtual EducationLevel EducationLevel { get; set; } = null!;

    [ForeignKey("IdClient, IdEducationResult")]
    [InverseProperty("EmployeeEducationInfos")]
    public virtual EducationResult EducationResult { get; set; } = null!;

    [ForeignKey("IdClient, IdEmployee")]
    [InverseProperty("EmployeeEducationInfos")]
    public virtual Employee Employee { get; set; } = null!;
    //public virtual Employee ? Employee { get; set; }
}
