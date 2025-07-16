using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HanaHRM.DataAccess.Models;

[PrimaryKey("IdClient", "Id")]
[Table("Department")]
public partial class Department
{
    [Key]
    public int IdClient { get; set; }

    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string DepartName { get; set; } = null!;

    [StringLength(100)]
    public string? DepartNameBangla { get; set; }

    public DateTime? SetDate { get; set; }

    [StringLength(50)]
    public string? CreatedBy { get; set; }

    [InverseProperty("Department")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    [InverseProperty("Department")]
    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
}
