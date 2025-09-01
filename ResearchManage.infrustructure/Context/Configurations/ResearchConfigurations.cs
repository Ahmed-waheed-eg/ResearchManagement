using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ResearchManage.Infrustructure.Data.Configurations
{
    public class ResearchConfigurations : IEntityTypeConfiguration<Domain.Entities.Research>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Research> builder)
        {
            builder.ToTable("Researches");
            builder.HasKey(r => r.ID);
            builder.Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(r => r.Abestract)
                .HasMaxLength(1000);
          
           
            builder.HasOne(r => r.scholar)
                .WithMany(re => re.Researches)
                .HasForeignKey(r => r.ScholarID).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(r => r.Supervisor).
                WithMany(s => s.Researches)
                .HasForeignKey(r => r.SupervisorID).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(r => r.department)
                .WithMany(d => d.Researches)
                .HasForeignKey(r => r.DepartmentID).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(r=>r.comments)
                .WithOne(c=>c.research).HasForeignKey(c=>c.ResearchId).OnDelete(DeleteBehavior.NoAction);
        }

    }
}
