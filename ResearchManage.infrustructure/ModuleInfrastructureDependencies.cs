using System;
using Microsoft.Extensions.DependencyInjection;
using ResearchManage.Infrustructure.Repositories;
using ResearchManage.Infrustructure.Abstracts;
using ResearchManage.Infrustructure.GenericBases;

namespace ResearchManage.Infrustructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<IReviwerRepository,ReviewerRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IResearchRepository, ResearchRepository>();
            services.AddTransient<ISupervisorRepository, SupervisorRepository>();
            services.AddTransient<IScholarRepository, ScholarRepository>();
            services.AddTransient(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            return services;

        }

    }
}
