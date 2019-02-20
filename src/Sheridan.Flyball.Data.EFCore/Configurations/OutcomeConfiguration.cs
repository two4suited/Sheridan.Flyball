using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheridan.Flyball.Core.Enumerations;

namespace Sheridan.Flyball.Data.EFCore.Configurations
{
    public class OutcomeConfiguration : IEntityTypeConfiguration<Outcome>
    {
        public void Configure(EntityTypeBuilder<Outcome> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(ct => ct.Id)
              //  .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(ct => ct.Name)
                .HasMaxLength(4)
                .IsRequired();
        }
    }
}