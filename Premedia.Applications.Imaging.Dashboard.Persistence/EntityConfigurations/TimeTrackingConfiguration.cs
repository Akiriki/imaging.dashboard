using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Premedia.Applications.Imaging.Dashboard.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premedia.Applications.Imaging.Dashboard.Persistence.EntityConfigurations
{
    public class TimeTrackingConfiguration : IEntityTypeConfiguration<TimeTracking>
    {
        public void Configure(EntityTypeBuilder<TimeTracking> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Editor)
                .WithMany(x => x.TimeTracking)
                .HasForeignKey(x => x.EditorId);
            /*builder.HasOne(x => x.CreatedBy)
                .WithMany(x => x.TimeTracking)
                .HasForeignKey(x => x.CreatorId);*/
            builder.HasOne(x => x.Job)
                .WithMany(x => x.TimeTracking)
                .HasForeignKey(x => x.JobId);
        }
    }
}
