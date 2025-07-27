using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HanaHRM.DataAccess.Models.Configurations
{
    public class EducationResultConfiguration : IEntityTypeConfiguration<EducationResult>
    {
        public void Configure(EntityTypeBuilder<EducationResult> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
        }
    }
}
