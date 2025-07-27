using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HanaHRM.DataAccess.Models.Configurations
{
    public class EmployeeEducationInfoConfiguration : IEntityTypeConfiguration<EmployeeEducationInfo>
    {
        public void Configure(EntityTypeBuilder<EmployeeEducationInfo> builder)
        {
            builder.Property(e => e.IdClient).HasDefaultValue(10001001);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.HasOne(d => d.EducationExamination)
                .WithMany(p => p.EmployeeEducationInfos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeEducationInfo_EducationExamination");

            builder.HasOne(d => d.EducationLevel)
                .WithMany(p => p.EmployeeEducationInfos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeEducationInfo_EducationLevel");

            builder.HasOne(d => d.EducationResult)
                .WithMany(p => p.EmployeeEducationInfos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeEducationInfo_EducationResult");

            builder.HasOne(d => d.Employee)
                .WithMany(p => p.EmployeeEducationInfos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeEducationInfo_Employee");
        }
    }
}
