using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectManager.Application.Interfaces;
using ProjectManager.Application.Models;
using ProjectManager.Infrastructure.Data;
using ProjectManager.Infrastructure.Repositories;

namespace ProjectManager.Infrastructure;
public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services)
	{
		services.AddDbContext<AppDbContext>(options =>
			options.UseInMemoryDatabase("ProjectManager.db"));

		services.AddScoped<IRepository<Project>, ProjectRepository>();

		return services;
	}
}
