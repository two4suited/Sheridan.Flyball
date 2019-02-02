using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Data.EFCore.Configurations
{
    public class TeamConfiguration :IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            //builder.HasMany(x => x.Races).WithOne();
            builder.HasMany(x => x.Dogs).WithOne();
            builder.HasOne(x => x.Club).WithMany();

        }
    }
}