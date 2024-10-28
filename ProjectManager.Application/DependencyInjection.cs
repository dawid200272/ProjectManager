using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ProjectManager.Application;
public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services.AddAutoMapper(Assembly.GetExecutingAssembly());

		services.AddMediatR(config => 
			config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

		return services;
	}
}
