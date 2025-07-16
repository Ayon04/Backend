using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HanaHRM.DataAccess.Models;

public partial class HRMDbContext : DbContext
{
    public HRMDbContext()
    {
    }

    public HRMDbContext(DbContextOptions<HRMDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Designation> Designations { get; set; }

    public virtual DbSet<EducationExamination> EducationExaminations { get; set; }

    public virtual DbSet<EducationLevel> EducationLevels { get; set; }

    public virtual DbSet<EducationResult> EducationResults { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeDocument> EmployeeDocuments { get; set; }

    public virtual DbSet<EmployeeEducationInfo> EmployeeEducationInfos { get; set; }

    public virtual DbSet<EmployeeFamilyInfo> EmployeeFamilyInfos { get; set; }

    public virtual DbSet<EmployeeProfessionalCertification> EmployeeProfessionalCertifications { get; set; }

    public virtual DbSet<EmployeeType> EmployeeTypes { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<JobType> JobTypes { get; set; }

    public virtual DbSet<MaritalStatus> MaritalStatuses { get; set; }

    public virtual DbSet<Relationship> Relationships { get; set; }

    public virtual DbSet<Religion> Religions { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<WeekOff> WeekOffs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.70.89;Database=HANA-HRM;User Id=SA;Password=Sa@123456;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
