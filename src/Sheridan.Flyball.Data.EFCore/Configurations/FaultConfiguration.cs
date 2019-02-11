using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheridan.Flyball.Core.Enumerations;

namespace Sheridan.Flyball.Data.EFCore.Configurations
{
    public class FaultConfiguration : IEntityTypeConfiguration<Fault>
    {
        public void Configure(EntityTypeBuilder<Fault> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(ct => ct.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(ct => ct.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}