using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Data.EFCore.Configurations
{
    public class TournamentConfiguration : IEntityTypeConfiguration<Tournament>
    {
        public void Configure(EntityTypeBuilder<Tournament> builder)
        {
            builder.HasMany(x => x.Divisions).WithOne().OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Teams).WithOne().OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Races).WithOne().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.RaceYear).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}