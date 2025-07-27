using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HanaHRM.DataAccess.Models.Configurations
{
    public class EmployeeProfessionalCertificationConfiguration : IEntityTypeConfiguration<EmployeeProfessionalCertification>
    {
        public void Configure(EntityTypeBuilder<EmployeeProfessionalCertification> builder)
        {
            builder.Property(e => e.IdClient).HasDefaultValue(10001001);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.HasOne(d => d.Employee)
                .WithMany(p => p.EmployeeProfessionalCertifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeProfessionalCertification_Employee");
        }
    }
}
