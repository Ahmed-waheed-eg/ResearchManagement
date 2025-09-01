
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ResearchManage.Domain.Entities;
using ResearchManage.Domain.Entities.Identity;

namespace ResearchManage.Infrustructure.Data
{
    public class ApplicationDBContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDBContext()
        {

        }
        #region DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Admin> admins { get; set; }
        public DbSet<Research> researches { get; set; }
        public DbSet<Scholar> Scholars { get; set; }
        public DbSet<Supervisor> supervisors { get; set; }
        public DbSet<Department> departments { get; set; }

        #endregion



        #region Constructors

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        #endregion



        #region Overrides
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);

        }
        #endregion

    }
}
