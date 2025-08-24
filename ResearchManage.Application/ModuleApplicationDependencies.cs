using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ResearchManage.Application.Behavior;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Application
{
    public static class ModuleApplicationDependencies
    {
        public static  IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            //Configuration of Mediator
            services.AddMediatR(cgf => cgf.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            //Configuration of Automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
            
        }
    }
}
