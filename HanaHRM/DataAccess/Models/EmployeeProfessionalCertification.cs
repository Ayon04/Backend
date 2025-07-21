using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HanaHRM.DataAccess.Models;

[PrimaryKey("IdClient", "Id")]
[Table("EmployeeProfessionalCertification")]
[Index("IdClient", "IdEmployee", "CertificationTitle", "FromDate", Name = "UNQ_EmployeeProfessionalCertification", IsUnique = true)]
public partial class EmployeeProfessionalCertification
{
    [Key]
    public int IdClient { get; set; }

    [Key]
    public int Id { get; set; }

    public int IdEmployee { get; set; }

    [StringLength(255)]
    public string CertificationTitle { get; set; } = null!;

    [StringLength(250)]
    public string CertificationInstitute { get; set; } = null!;

    [StringLength(250)]
    public string InstituteLocation { get; set; } = null!;

    public DateTime FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public DateTime? SetDate { get; set; }

    [StringLength(50)]
    public string? CreatedBy { get; set; }

    [ForeignKey("IdClient, IdEmployee")]
    [InverseProperty("EmployeeProfessionalCertifications")]
    public virtual Employee Employee { get; set; } = null!;
  //public virtual Employee ? Employee { get; set; }


}
