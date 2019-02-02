using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Data.EFCore.Configurations
{
    public class HeatConfiguration : IEntityTypeConfiguration<Heat>
    {
        public void Configure(EntityTypeBuilder<Heat> builder)
        {
            builder.HasMany(x => x.Lineup).WithOne();
            builder.HasMany(x => x.DogRuns).WithOne();
            builder.HasOne(x => x.Outcome).WithMany();
        }
    }
}