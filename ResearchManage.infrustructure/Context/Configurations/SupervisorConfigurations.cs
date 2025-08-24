using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Infrustructure.Data.Configurations
{
    public class SupervisorConfigurations : IEntityTypeConfiguration<Domain.Entities.Supervisor>
    {

        public void Configure(EntityTypeBuilder<Domain.Entities.Supervisor> builder)
        {
            builder.ToTable("Supervisors");
            builder.HasKey(s => s.ID);
            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasMany(s => s.Researches)
                .WithOne(r => r.Supervisor)
                .HasForeignKey(r => r.SupervisorID).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(s => s.Department)
                .WithMany(d => d.Supervisors)
                .HasForeignKey(s => s.DepartmentID).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
