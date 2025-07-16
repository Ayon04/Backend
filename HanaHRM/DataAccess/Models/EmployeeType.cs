using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HanaHRM.DataAccess.Models;

[PrimaryKey("IdClient", "Id")]
[Table("EmployeeType")]
public partial class EmployeeType
{
    [Key]
    public int IdClient { get; set; }

    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string? TypeName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SetDate { get; set; }

    [StringLength(50)]
    public string? CreatedBy { get; set; }

    [InverseProperty("EmployeeType")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
