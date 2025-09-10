using Microsoft.Extensions.DependencyInjection;
using ResearchManage.Infrustructure.Abstracts;
using ResearchManage.Infrustructure.GenericBases;
using ResearchManage.Infrustructure.Repositories;

namespace ResearchManage.Infrustructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<IReviwerRepository, ReviewerRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IResearchRepository, ResearchRepository>();
            services.AddTransient<ISupervisorRepository, SupervisorRepository>();
            services.AddTransient<IScholarRepository, ScholarRepository>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddTransient(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            return services;

        }

    }
}
