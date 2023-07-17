using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Premedia.Applications.Imaging.Dashboard.Core.Entities;

namespace Premedia.Applications.Imaging.Dashboard.Persistence.EntityConfigurations
{
    public class TimeTrackingConfiguration : IEntityTypeConfiguration<TimeTracking>
    {
        public void Configure(EntityTypeBuilder<TimeTracking> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Editor)
                .WithMany(x => x.TimeTrackingEditor)
                .HasForeignKey(x => x.EditorId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Creator)
                .WithMany(x => x.TimeTrackingCreator)
                .HasForeignKey(x => x.CreatorId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Job)
                .WithMany(x => x.TimeTracking)
                .HasForeignKey(x => x.JobId);
        }
    }
}
