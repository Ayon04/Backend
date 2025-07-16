using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HanaHRM.DataAccess.Models;

[PrimaryKey("IdClient", "Id")]
[Table("Designation")]
public partial class Designation
{
    [Key]
    public int IdClient { get; set; }

    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string DesignationName { get; set; } = null!;

    [StringLength(100)]
    public string? DesignationNameBangla { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? SetDate { get; set; }

    [StringLength(50)]
    public string? CreatedBy { get; set; }

    [InverseProperty("Designation")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
