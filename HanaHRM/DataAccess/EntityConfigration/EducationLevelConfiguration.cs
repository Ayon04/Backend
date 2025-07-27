using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HanaHRM.DataAccess.Models.Configurations
{
    public class EducationLevelConfiguration : IEntityTypeConfiguration<EducationLevel>
    {
        public void Configure(EntityTypeBuilder<EducationLevel> builder)
        {
            builder.Property(e => e.IdClient).HasDefaultValue(10001001);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
        }
    }
}
