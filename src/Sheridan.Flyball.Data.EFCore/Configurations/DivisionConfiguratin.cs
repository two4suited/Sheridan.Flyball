using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Data.EFCore.Configurations
{
    public class DivisionConfiguration : IEntityTypeConfiguration<Division>
    {
        public void Configure(EntityTypeBuilder<Division> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(10).IsRequired();
            builder.Property(x => x.BreakOutTime).IsRequired();
            builder.HasOne(x => x.RacingClass).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}