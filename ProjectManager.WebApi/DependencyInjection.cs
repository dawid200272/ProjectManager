using System.Reflection;

namespace ProjectManager.WebApi;
public static class DependencyInjection
{
	public static IServiceCollection AddWebApi(this IServiceCollection services)
	{
		services.AddMediatR(config => 
			config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

		return services;
	}
}
