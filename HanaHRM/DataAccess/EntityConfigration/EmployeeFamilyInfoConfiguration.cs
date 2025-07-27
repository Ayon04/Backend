using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HanaHRM.DataAccess.Models.Configurations
{
    public class EmployeeFamilyInfoConfiguration : IEntityTypeConfiguration<EmployeeFamilyInfo>
    {
        public void Configure(EntityTypeBuilder<EmployeeFamilyInfo> builder)
        {
            builder.Property(e => e.IdClient).HasDefaultValue(10001001);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();


            builder.HasOne(d => d.Employee).WithMany(p => p.EmployeeFamilyInfos)
           .HasForeignKey(d => new { d.IdClient, d.IdEmployee })
           .OnDelete(DeleteBehavior.ClientSetNull)
           .HasConstraintName("FK_EmployeeFamilyInfo_Employee");

            builder.HasOne(d => d.Gender)
                .WithMany(p => p.EmployeeFamilyInfos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeFamilyInfo_Gender");

            builder.HasOne(d => d.Relationship)
                .WithMany(p => p.EmployeeFamilyInfos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeFamilyInfo_Relationship");
        }
    }
}
