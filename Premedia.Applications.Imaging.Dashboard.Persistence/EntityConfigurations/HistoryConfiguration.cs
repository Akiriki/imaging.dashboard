using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Premedia.Applications.Imaging.Dashboard.Core.Entities;

namespace Premedia.Applications.Imaging.Dashboard.Persistence.EntityConfigurations
{
    public class HistoryConfiguration : IEntityTypeConfiguration<History>
    {
        public void Configure(EntityTypeBuilder<History> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Editor)
                .WithMany(x => x.History)
                .HasForeignKey(x => x.EditorId);

            builder.HasOne(x => x.Job)
                .WithMany(x => x.History)
                .HasForeignKey(x => x.JobId);
        }
    }
}