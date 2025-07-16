using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HanaHRM.DataAccess.Models;

[PrimaryKey("IdClient", "Id")]
[Table("JobType")]
public partial class JobType
{
    [Key]
    public int IdClient { get; set; }

    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string JobTypeName { get; set; } = null!;

    [StringLength(50)]
    public string? JobTypeBanglaName { get; set; }

    public DateTime? SetDate { get; set; }

    [StringLength(50)]
    public string? CreatedBy { get; set; }

    [InverseProperty("JobType")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
