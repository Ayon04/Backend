using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HanaHRM.DataAccess.Models;

[PrimaryKey("IdClient", "Id")]
[Table("EducationLevel")]
public partial class EducationLevel
{
    [Key]
    public int IdClient { get; set; }

    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    //public string EducationLevelName { get; set; } = null!;

    public string ? EducationLevelName { get; set; }

    [StringLength(250)]
    public string? Description { get; set; }

    public DateTime? SetDate { get; set; }

    [StringLength(50)]
    public string? CreatedBy { get; set; }

    [InverseProperty("EducationLevel")]
    public virtual ICollection<EducationExamination> EducationExaminations { get; set; } = new List<EducationExamination>();

    [InverseProperty("EducationLevel")]
    public virtual ICollection<EmployeeEducationInfo> EmployeeEducationInfos { get; set; } = new List<EmployeeEducationInfo>();
}
