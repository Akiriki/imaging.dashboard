using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Premedia.Applications.Imaging.Dashboard.Core.Entities;

namespace Premedia.Applications.Imaging.Dashboard.Persistence.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.JobsAsCreator)
                .WithOne(x => x.Creator)
                .HasForeignKey(x => x.CreatorId);

            builder.HasMany(x => x.JobsAsEditor)
                .WithOne(x => x.Editor)
                .HasForeignKey(x => x.EditorId);

            builder.HasMany(x => x.JobsAsCustomer)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId);

            builder.HasMany(x => x.TimeTrackingCreator)
                .WithOne(x => x.Creator)
                .HasForeignKey(x => x.CreatorId);

            builder.HasMany(x => x.TimeTrackingEditor)
                .WithOne(x => x.Editor)
                .HasForeignKey(x => x.EditorId);

            builder.HasMany(x => x.History)
                .WithOne(x => x.Editor)
                .HasForeignKey(x => x.EditorId);
            
            builder.HasMany(x => x.AdditionalFile)
                .WithOne(x => x.Creator)
                .HasForeignKey(x => x.CreatorId);
        }
    }
}