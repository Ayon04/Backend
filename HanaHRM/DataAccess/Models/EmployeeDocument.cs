using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HanaHRM.DataAccess.Models;

[PrimaryKey("IdClient", "Id")]
[Table("EmployeeDocument")]
[Index("IdClient", "IdEmployee", "FileName", "UploadedFileExtention", Name = "UNQ_EmployeeDocument", IsUnique = true)]
public partial class EmployeeDocument
{
    [Key]
    public int IdClient { get; set; }

    [Key]
    public int Id { get; set; }

    public int IdEmployee { get; set; }

    [StringLength(200)]
    public string DocumentName { get; set; } = null!;

    [StringLength(100)]
    public string FileName { get; set; } = null!;

    public DateTime UploadDate { get; set; }

    [StringLength(10)]
    public string? UploadedFileExtention { get; set; }

    public byte[]? UploadedFile { get; set; }

    public DateTime? SetDate { get; set; }

    [StringLength(50)]
    public string? CreatedBy { get; set; }

    [ForeignKey("IdClient, IdEmployee")]
    [InverseProperty("EmployeeDocuments")]
    public virtual Employee Employee { get; set; } = null!;
    //public virtual Employee ? Employee { get; set; }
}
