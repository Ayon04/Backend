using HanaHRM.DataAccess.Models.Configurations;
using Microsoft.EntityFrameworkCore;

namespace HanaHRM.DataAccess.Models;

public partial class HRMContext
{
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new DepartmentConfiguration());


        RelationShipsMapping(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }
}
