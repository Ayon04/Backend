using HanaHRM.DataAccess.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HanaHRM.DTO
{
    public class EmployeeFamilyInfoDTO
    {
        public int IdClient { get; set; }
        public int Id { get; set; }

        public int IdEmployee { get; set; }

        public string Name { get; set; } = null!;

        public int IdGender { get; set; }

        public int IdRelationship { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? ContactNo { get; set; }

        public string? CurrentAddress { get; set; }

        public string? PermanentAddress { get; set; }

        public DateTime? SetDate { get; set; }

        public string? CreatedBy { get; set; }

       // public virtual Gender Gender { get; set; } = null!;

       // public virtual Relationship Relationship { get; set; } = null!;
       /* public virtual Relationship ? Relationship { get; set; }
        public virtual Gender ? Gender { get; set; } */
    }
}
