using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HanaHRM.DataAccess.Models.Configurations
{
    public class EducationExaminationConfiguration : IEntityTypeConfiguration<EducationExamination>
    {
        public void Configure(EntityTypeBuilder<EducationExamination> builder)
        {
            builder.Property(e => e.IdClient).HasDefaultValue(10001001);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.HasOne(d => d.EducationLevel)
                .WithMany(p => p.EducationExaminations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EducationExamination_EducationLevel");
        }
    }
}
