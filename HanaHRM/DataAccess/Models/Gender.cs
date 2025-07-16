using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HanaHRM.DataAccess.Models;

[PrimaryKey("IdClient", "Id")]
[Table("Gender")]
public partial class Gender
{
    [Key]
    public int IdClient { get; set; }

    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? GenderName { get; set; }

    public DateTime? SetDate { get; set; }

    [StringLength(50)]
    public string? CreatedBy { get; set; }

    [InverseProperty("Gender")]
    public virtual ICollection<EmployeeFamilyInfo> EmployeeFamilyInfos { get; set; } = new List<EmployeeFamilyInfo>();

    [InverseProperty("Gender")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
