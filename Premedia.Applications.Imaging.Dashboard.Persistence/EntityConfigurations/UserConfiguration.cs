﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Premedia.Applications.Imaging.Dashboard.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premedia.Applications.Imaging.Dashboard.Persistence.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Job)
                .WithOne(x => x.CreatedBy)
                .HasForeignKey(x => x.CreatorId);
            builder.HasMany(x => x.Job)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId);
            builder.HasMany(x => x.TimeTracking)
                .WithOne(x => x.CreatedBy)
                .HasForeignKey(x => x.CreatorId);
            builder.HasMany(x => x.TimeTracking)
                .WithOne(x => x.Editor)
                .HasForeignKey(x => x.EditorId);
            builder.HasMany(x => x.History)
                .WithOne(x => x.Editor)
                .HasForeignKey(x => x.EditorId);
        }
    }
}
