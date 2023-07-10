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
    public class JobFileConfiguration : IEntityTypeConfiguration<JobFiles>
    {
        public void Configure(EntityTypeBuilder<JobFiles> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Job)
                .WithMany(x => x.JobFiles)
                .HasForeignKey(x => x.JobId);
            builder.HasOne(x => x.FilePath)
                .WithOne(x => x.JobFiles)
                .HasForeignKey<FilePath>(x  => x.JobFileId);
        }
    }
}
