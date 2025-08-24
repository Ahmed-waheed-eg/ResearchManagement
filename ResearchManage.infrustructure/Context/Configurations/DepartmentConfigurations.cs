using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Infrustructure.Data.Configurations
{
    public class DepartmentConfigurations : IEntityTypeConfiguration<Domain.Entities.Department>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Department> builder)
        {
            builder.ToTable("Departments");
            builder.HasKey(d => d.ID);
            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasMany(d => d.Scholars)
                .WithOne(r => r.Department)
                .HasForeignKey(r => r.DepartmentID).OnDelete(DeleteBehavior.NoAction);
        }
    }
    
    }

