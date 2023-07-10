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
    public class AdditionalFileConfiguration : IEntityTypeConfiguration<AdditionalFile>
    {
        public void Configure(EntityTypeBuilder<AdditionalFile> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Job)
                .WithMany(x => x.AdditionalFile)
                .HasForeignKey(x => x.JobId);
            builder.HasOne(x => x.FilePath)
                .WithOne(x => x.AdditionalFile);
                //.HasForeignKey(x => x.FilePathId);
            builder.HasOne(x => x.Creator)
                .WithMany(x => x.AdditionalFile)
                /*.HasForeignKey(x => x.CreatorId)*/;
        }
    }
}
