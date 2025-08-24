using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResearchManage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Infrustructure.Data.Configurations
{
    public class ScholarConfigurations : IEntityTypeConfiguration<Scholar>
    {
        public void Configure(EntityTypeBuilder<Scholar> builder)
        {
            builder.ToTable("Scholars");
            builder.HasKey(r => r.ID);
            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(s=>s.Bio).HasMaxLength(200);
          
            builder.HasOne(r => r.Department)
                .WithMany(d => d.Scholars)
                .HasForeignKey(r => r.DepartmentID).OnDelete(DeleteBehavior.NoAction);
        }

    }
}
