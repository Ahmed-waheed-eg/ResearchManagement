using Microsoft.Extensions.DependencyInjection;
using ResearchManage.Services.Abstarcts;
using ResearchManage.Services.Implementation;

namespace ResearchManage.Services
{
    public static class ModuleServicesDependencies
    {
        
            public static IServiceCollection AddServicesDependencies(this IServiceCollection services)
            {
                services.AddTransient<IScholarServices, ScholarServices>();
            services.AddTransient<IDepartmentServices, DepartmentServices>();
                return services;

            }


    }
}
