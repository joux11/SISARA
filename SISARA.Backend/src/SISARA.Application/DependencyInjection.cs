using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SISARA.Application.Common.Behaviours;
using System.Reflection;

namespace SISARA.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviours<,>));
            return services;
        }   
    }
}
