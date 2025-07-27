using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HanaHRM.DataAccess.Models.EntityConfigration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.IdClient).HasDefaultValue(10001001);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.HasAttendenceBonus).HasDefaultValue(false);
            builder.Property(e => e.HasOvertime).HasDefaultValue(false);
            builder.Property(e => e.IsActive).HasDefaultValue(true);

            builder.HasOne(d => d.Department)
                .WithMany(p => p.Employees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Department");

            builder.HasOne(d => d.Designation)
                .WithMany(p => p.Employees)
                .HasConstraintName("FK_Employee_Designation");

            builder.HasOne(d => d.EmployeeType)
                .WithMany(p => p.Employees)
                .HasConstraintName("FK_Employee_EmployeeType");

            builder.HasOne(d => d.Gender)
                .WithMany(p => p.Employees)
                .HasConstraintName("FK_Employee_Gender");

            builder.HasOne(d => d.JobType)
                .WithMany(p => p.Employees)
                .HasConstraintName("FK_Employee_JobType");

            builder.HasOne(d => d.MaritalStatus)
                .WithMany(p => p.Employees)
                .HasConstraintName("FK_Employee_MaritalStatus");

            builder.HasOne(d => d.Religion)
                .WithMany(p => p.Employees)
                .HasConstraintName("FK_Employee_Religion");

            builder.HasOne(d => d.Section)
                .WithMany(p => p.Employees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Section");

            builder.HasOne(d => d.WeekOff)
                .WithMany(p => p.Employees)
                .HasConstraintName("FK_Employee_WeekOff");
        }
    }
}
