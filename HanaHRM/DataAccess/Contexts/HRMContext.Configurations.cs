using HanaHRM.DataAccess.Models.Configurations;
using Microsoft.EntityFrameworkCore;

namespace HanaHRM.DataAccess.Models;

public partial class HRMContext
{
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        modelBuilder.ApplyConfiguration(new DesignationConfiguration());
        modelBuilder.ApplyConfiguration(new EducationExaminationConfiguration());
        modelBuilder.ApplyConfiguration(new EducationLevelConfiguration());
        modelBuilder.ApplyConfiguration(new EducationResultConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeDocumentConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeEducationInfoConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeFamilyInfoConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeProfessionalCertificationConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeTypeConfiguration());
        modelBuilder.ApplyConfiguration(new GenderConfiguration());
        modelBuilder.ApplyConfiguration(new JobTypeConfiguration());
        modelBuilder.ApplyConfiguration(new MaritalStatusConfiguration());



        RelationShipsMapping(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }
}
