using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HanaHRM.DataAccess.Models;

[PrimaryKey("IdClient", "Id")]
[Table("EducationExamination")]
public partial class EducationExamination
{
    [Key]
    public int IdClient { get; set; }

    [Key]
    public int Id { get; set; }

    [StringLength(250)]
    public string ? ExamName { get; set; } = null!;

    public int IdEducationLevel { get; set; }

    public bool? Status { get; set; }

    public DateTime? SetDate { get; set; }

    [StringLength(50)]
    public string? CreatedBy { get; set; }

    [ForeignKey("IdClient, IdEducationLevel")]
    [InverseProperty("EducationExaminations")]
    // public virtual EducationLevel EducationLevel { get; set; } = null!;
    public virtual EducationLevel ? EducationLevel { get; set; }



    [InverseProperty("EducationExamination")]
    public virtual ICollection<EmployeeEducationInfo> EmployeeEducationInfos { get; set; } = new List<EmployeeEducationInfo>();
}
