using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Data.EFCore.Configurations
{
    public class ClubConfiguration : IEntityTypeConfiguration<Club>
    {
        public void Configure(EntityTypeBuilder<Club> builder)
        {
           // builder.HasMany(x => x.Teams).WithOne();
            builder.HasMany(x => x.People).WithOne().OnDelete(DeleteBehavior.Restrict); 
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.NafaClubNumber).IsRequired();

        }
    }
}