﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Data.EFCore.Configurations
{
    public class DogRunConfiguration : IEntityTypeConfiguration<DogRun>
    {
        public void Configure(EntityTypeBuilder<DogRun> builder)
        {
            builder.HasOne(x => x.Dog).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);            
            builder.HasOne(x => x.Position).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict); ;
            builder.HasOne(x => x.Fault).WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }
}