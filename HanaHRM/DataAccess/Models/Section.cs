using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HanaHRM.DataAccess.Models;

[PrimaryKey("IdClient", "Id")]
[Table("Section")]
[Index("IdClient", "IdDepartment", "SectionName", Name = "UNQ_Section", IsUnique = true)]
public partial class Section
{
    [Key]
    public int IdClient { get; set; }

    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string SectionName { get; set; } = null!;

    [StringLength(100)]
    public string? SectionNameBangla { get; set; }

    [StringLength(50)]
    public string ShortName { get; set; } = null!;

    public int? IdDepartment { get; set; }

    public DateTime? SetDate { get; set; }

    [StringLength(50)]
    public string? CreatedBy { get; set; }

    [ForeignKey("IdClient, IdDepartment")]
    [InverseProperty("Sections")]
    public virtual Department? Department { get; set; }

    [InverseProperty("Section")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
