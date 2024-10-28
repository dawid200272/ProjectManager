using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Models;

namespace ProjectManager.Infrastructure.Data;
public class AppDbContext : DbContext
{
	public DbSet<Project> Projects { get; set; }

	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
