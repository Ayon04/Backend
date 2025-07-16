using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HanaHRM.DataAccess.Models;

[PrimaryKey("IdClient", "Id")]
[Table("Religion")]
public partial class Religion
{
    [Key]
    public int IdClient { get; set; }

    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string ReligionName { get; set; } = null!;

    public DateTime? SetDate { get; set; }

    [StringLength(50)]
    public string? CreatedBy { get; set; }

    [InverseProperty("Religion")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
