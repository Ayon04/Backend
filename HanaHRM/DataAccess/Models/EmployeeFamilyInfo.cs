using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HanaHRM.DataAccess.Models;

[PrimaryKey("IdClient", "Id")]
[Table("EmployeeFamilyInfo")]
[Index("IdClient", "IdEmployee", "Name", Name = "UNQ_EmployeeFamilyInfo", IsUnique = true)]
public partial class EmployeeFamilyInfo
{
    [Key]
    public int IdClient { get; set; }

    [Key]
    public int Id { get; set; }

    public int IdEmployee { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    public int IdGender { get; set; }

    public int IdRelationship { get; set; }

    public DateTime? DateOfBirth { get; set; }

    [StringLength(50)]
    public string? ContactNo { get; set; }

    [StringLength(500)]
    public string? CurrentAddress { get; set; }

    [StringLength(500)]
    public string? PermanentAddress { get; set; }

    public DateTime? SetDate { get; set; }

    [StringLength(50)]
    public string? CreatedBy { get; set; }

    [ForeignKey("IdClient, IdGender")]
    [InverseProperty("EmployeeFamilyInfos")]
    public virtual Gender Gender { get; set; } = null!;

    [ForeignKey("IdClient, IdRelationship")]
    [InverseProperty("EmployeeFamilyInfos")]
    //public virtual Relationship Relationship { get; set; } = null!;
    public virtual Relationship ? Relationship { get; set; }
    public virtual Employee Employee { get; set; } = null!;


}
