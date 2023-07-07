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
        }
    }
}
