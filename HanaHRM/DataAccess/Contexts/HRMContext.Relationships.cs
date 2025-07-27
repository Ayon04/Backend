using Microsoft.EntityFrameworkCore;

namespace HanaHRM.DataAccess.Models;

public partial class HRMContext
{
    private void RelationShipsMapping(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.Property(e => e.IdClient).HasDefaultValue(10001001);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Designation>(entity =>
        {
            entity.Property(e => e.IdClient).HasDefaultValue(10001001);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<EducationExamination>(entity =>
        {
            entity.Property(e => e.IdClient).HasDefaultValue(10001001);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.EducationLevel).WithMany(p => p.EducationExaminations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EducationExamination_EducationLevel");
        });

        modelBuilder.Entity<EducationLevel>(entity =>
        {
            entity.Property(e => e.IdClient).HasDefaultValue(10001001);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<EducationResult>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.IdClient).HasDefaultValue(10001001);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.HasAttendenceBonus).HasDefaultValue(false);
            entity.Property(e => e.HasOvertime).HasDefaultValue(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Department");

            entity.HasOne(d => d.Designation).WithMany(p => p.Employees).HasConstraintName("FK_Employee_Designation");

            entity.HasOne(d => d.EmployeeType).WithMany(p => p.Employees).HasConstraintName("FK_Employee_EmployeeType");

            entity.HasOne(d => d.Gender).WithMany(p => p.Employees).HasConstraintName("FK_Employee_Gender");

            entity.HasOne(d => d.JobType).WithMany(p => p.Employees).HasConstraintName("FK_Employee_JobType");

            entity.HasOne(d => d.MaritalStatus).WithMany(p => p.Employees).HasConstraintName("FK_Employee_MaritalStatus");

            entity.HasOne(d => d.Religion).WithMany(p => p.Employees).HasConstraintName("FK_Employee_Religion");

            entity.HasOne(d => d.Section).WithMany(p => p.Employees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Section");

            entity.HasOne(d => d.WeekOff).WithMany(p => p.Employees).HasConstraintName("FK_Employee_WeekOff");
        });

        modelBuilder.Entity<EmployeeDocument>(entity =>
        {
            entity.Property(e => e.IdClient).HasDefaultValue(10001001);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeDocuments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeDocument_Employee");
        });

        modelBuilder.Entity<EmployeeEducationInfo>(entity =>
        {
            entity.Property(e => e.IdClient).HasDefaultValue(10001001);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.EducationExamination).WithMany(p => p.EmployeeEducationInfos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeEducationInfo_EducationExamination");

            entity.HasOne(d => d.EducationLevel).WithMany(p => p.EmployeeEducationInfos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeEducationInfo_EducationLevel");

            entity.HasOne(d => d.EducationResult).WithMany(p => p.EmployeeEducationInfos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeEducationInfo_EducationResult");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeEducationInfos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeEducationInfo_Employee");
        });

        modelBuilder.Entity<EmployeeFamilyInfo>(entity =>
        {
            entity.Property(e => e.IdClient).HasDefaultValue(10001001);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeFamilyInfos)
                  .HasForeignKey(d => new { d.IdClient, d.IdEmployee })
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_EmployeeFamilyInfo_Employee");

            entity.HasOne(d => d.Gender).WithMany(p => p.EmployeeFamilyInfos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeFamilyInfo_Gender");

            entity.HasOne(d => d.Relationship).WithMany(p => p.EmployeeFamilyInfos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeFamilyInfo_Relationship");
        });

        modelBuilder.Entity<EmployeeProfessionalCertification>(entity =>
        {
            entity.Property(e => e.IdClient).HasDefaultValue(10001001);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeProfessionalCertifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeProfessionalCertification_Employee");
        });

        modelBuilder.Entity<EmployeeType>(entity =>
        {
            entity.Property(e => e.IdClient).HasDefaultValue(10001001);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.Property(e => e.IdClient).HasDefaultValue(10001001);
        });

        modelBuilder.Entity<JobType>(entity =>
        {
            entity.Property(e => e.IdClient).HasDefaultValue(10001001);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<MaritalStatus>(entity =>
        {
            entity.Property(e => e.IdClient).HasDefaultValue(10001001);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Relationship>(entity =>
        {
            entity.Property(e => e.IdClient).HasDefaultValue(10001001);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Religion>(entity =>
        {
            entity.Property(e => e.IdClient).HasDefaultValue(10001001);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.Property(e => e.IdClient).HasDefaultValue(10001001);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Department).WithMany(p => p.Sections).HasConstraintName("FK_Section_Department");
        });

        modelBuilder.Entity<WeekOff>(entity =>
        {
            entity.Property(e => e.IdClient).HasDefaultValue(10001001);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

    }
}
