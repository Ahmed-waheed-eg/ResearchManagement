
using Microsoft.EntityFrameworkCore;
using ResearchManage.Domain.Entities;
using ResearchManage.Infrustructure.Data.Configurations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Infrustructure.Data
{
    public class ApplicationDBContext :DbContext
    {

        #region DbSets
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
            //Database.EnsureCreated();
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
