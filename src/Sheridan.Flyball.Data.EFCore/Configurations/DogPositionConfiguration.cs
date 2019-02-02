using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Data.EFCore.Configurations
{
    public class DogPositionConfiguration : IEntityTypeConfiguration<DogPosition>
    {
        public void Configure(EntityTypeBuilder<DogPosition> builder)
        {
            builder.HasOne(x => x.Dog).WithMany();

        }
    }
}