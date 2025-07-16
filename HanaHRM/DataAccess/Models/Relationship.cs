using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HanaHRM.DataAccess.Models;

[PrimaryKey("IdClient", "Id")]
[Table("Relationship")]
public partial class Relationship
{
    [Key]
    public int IdClient { get; set; }

    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string RelationName { get; set; } = null!;

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    public DateTime? SetDate { get; set; }

    [StringLength(50)]
    public string? CreatedBy { get; set; }

    [InverseProperty("Relationship")]
    public virtual ICollection<EmployeeFamilyInfo> EmployeeFamilyInfos { get; set; } = new List<EmployeeFamilyInfo>();
}
