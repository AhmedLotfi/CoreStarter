using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CoreStarter.Core.Errors;
using CoreStarter.Core.Interfaces;
using CoreStarter.Infrastructure;
using CoreStarter.Infrastructure.Interfaces;
using CoreStarter.Infrastructure.Specifications;
using CoreStarter.Services._Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace CoreStarter.Core.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<,>), (typeof(GenericRepository<,>)));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITokenService, TokenService>();

            services.Configure<ApiBehaviorOptions>(options =>
                {
                    options.InvalidModelStateResponseFactory = actionContext =>
                    {
                        var errors = actionContext.ModelState
                            .Where(e => e.Value.Errors.Count > 0)
                            .SelectMany(x => x.Value.Errors)
                            .Select(x => x.ErrorMessage).ToArray();

                        var errorResponse = new ApiValidationErrorResponse
                        {
                            Errors = errors
                        };

                        return new BadRequestObjectResult(errorResponse);
                    };
                });

            services.RegisterAssemplyByNamingConvension();

            return services;
        }


        private static IServiceCollection RegisterAssemplyByNamingConvension(this IServiceCollection services)
        {

            WindsorContainer container = new WindsorContainer();

            Assembly assembly = Assembly.GetAssembly(typeof(EmployeeAppService));

            container.Register(Classes.FromAssembly(assembly)
                                      .IncludeNonPublicTypes()
                                      .BasedOn<ITransientDependency>()
                                      .If(type => !type.GetTypeInfo().IsGenericTypeDefinition)
                                      .WithService.Self()
                                      .WithService.DefaultInterfaces()
                                      .LifestyleTransient());

            return services;
        }
    }


}