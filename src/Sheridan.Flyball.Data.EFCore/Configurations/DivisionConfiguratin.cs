using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Data.EFCore.Configurations
{
    public class DivisionConfiguration : IEntityTypeConfiguration<Division>
    {
        public void Configure(EntityTypeBuilder<Division> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(10);
        }
    }
}