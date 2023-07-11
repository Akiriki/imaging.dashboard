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
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.JobFiles)
                .WithOne(x => x.Job)
                .HasForeignKey(x => x.JobId);
            builder.HasMany(x => x.AdditionalFile)
                .WithOne(x => x.Job)
                .HasForeignKey(x => x.JobId);
            builder.HasMany(x => x.TimeTracking)
                .WithOne(x => x.Job)
                .HasForeignKey(x => x.JobId);
            builder.HasMany(x => x.History)
                .WithOne(x => x.Job)
                .HasForeignKey(x => x.JobId);
            builder.HasOne(x => x.Client)
                .WithMany(x => x.Job)
                .HasForeignKey(x => x.ClientId);
            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Job)
                .HasForeignKey(x => x.CustomerId);
            /*builder.HasOne(x => x.CreatedBy)
                .WithMany(x => x.Job)
                .HasForeignKey(x => x.CreatorId);
            builder.HasOne(x => x.Editor)
                .WithMany(x => x.Job)
                .HasForeignKey(x =>x.EditorId);*/
        }
    }
}
