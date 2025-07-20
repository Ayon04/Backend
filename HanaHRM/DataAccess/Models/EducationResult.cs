using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HanaHRM.DataAccess.Models;

[PrimaryKey("IdClient", "Id")]
[Table("EducationResult")]
public partial class EducationResult
{
    [Key]
    public int IdClient { get; set; }

    [Key]
    public int Id { get; set; }

    [StringLength(250)]
    //public string ResultName { get; set; } = null!;

    public string ? ResultName { get; set; }
    [StringLength(250)]
    public string? Description { get; set; }

    public DateTime? SetDate { get; set; }

    [StringLength(50)]
    public string? CreatedBy { get; set; }

    [InverseProperty("EducationResult")]
    public virtual ICollection<EmployeeEducationInfo> EmployeeEducationInfos { get; set; } = new List<EmployeeEducationInfo>();
}
