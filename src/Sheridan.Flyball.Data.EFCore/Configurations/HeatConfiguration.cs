using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Data.EFCore.Configurations
{
    public class HeatConfiguration : IEntityTypeConfiguration<Heat>
    {
        public void Configure(EntityTypeBuilder<Heat> builder)
        {
            builder.HasMany(x => x.Lineup).WithOne().OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.DogRuns).WithOne().IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Lineup).WithOne().IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Outcome).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}