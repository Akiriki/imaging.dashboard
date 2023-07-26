using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Premedia.Applications.Imaging.Dashboard.Core.Entities;

namespace Premedia.Applications.Imaging.Dashboard.Persistence.EntityConfigurations
{
    public class JobFileConfiguration : IEntityTypeConfiguration<JobFiles>
    {
        public void Configure(EntityTypeBuilder<JobFiles> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Job)
                .WithMany(x => x.JobFiles)
                .HasForeignKey(x => x.JobId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.FilePath)
                .WithOne(x => x.JobFiles)
                .HasForeignKey<FilePath>(x  => x.JobFileId);

            builder.HasOne(x => x.Activity)
                .WithMany(x => x.JobFiles)
                .HasForeignKey(x => x.ActivityId);

            builder.HasOne(x => x.Creator)
                .WithMany(x => x.JobFiles)
                .HasForeignKey(x => x.CreatorId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}