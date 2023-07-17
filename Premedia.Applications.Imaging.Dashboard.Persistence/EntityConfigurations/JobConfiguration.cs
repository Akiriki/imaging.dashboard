using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Premedia.Applications.Imaging.Dashboard.Core.Entities;

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
                .HasForeignKey(x => x.ClientId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.JobsAsCustomer)
                .HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Creator)
                .WithMany(x => x.JobsAsCreator)
                .HasForeignKey(x => x.CreatorId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Editor)
                .WithMany(x => x.JobsAsEditor)
                .HasForeignKey(x =>x.EditorId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}