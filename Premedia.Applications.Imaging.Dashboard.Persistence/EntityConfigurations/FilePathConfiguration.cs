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
    public class FilePathConfiguration : IEntityTypeConfiguration<FilePath>
    {
        public void Configure(EntityTypeBuilder<FilePath> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.JobFiles)
                .WithOne(x => x.FilePath)
                .HasForeignKey<FilePath>(x => x.JobFileId);

            builder.HasOne(x => x.AdditionalFile)
                .WithOne(x => x.FilePath)
                .HasForeignKey<FilePath>(x => x.AdditionalFileId);
        }
    }
}
