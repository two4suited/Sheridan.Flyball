using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Data.EFCore.Configurations
{
    public class RaceYearConfiguration : IEntityTypeConfiguration<RaceYear>
    {
        public void Configure(EntityTypeBuilder<RaceYear> builder)
        {
           
        }
    }
}