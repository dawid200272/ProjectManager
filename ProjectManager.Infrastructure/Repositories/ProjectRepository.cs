using ProjectManager.Application.Interfaces;
using ProjectManager.Application.Models;
using ProjectManager.Infrastructure.Data;

namespace ProjectManager.Infrastructure.Repositories;
public class ProjectRepository : IRepository<Project>
{
	private readonly AppDbContext _context;

	public ProjectRepository(AppDbContext context)
	{
		_context = context;
	}

	public IQueryable<Project> GetAll()
	{
		return _context.Projects.AsQueryable();
	}

	public Project GetById(int id)
	{
		var project = _context.Projects.SingleOrDefault(p => p.Id == id);

		return project;
	}

	public int Add(Project entity)
	{
		var entityEntry = _context.Projects.Add(entity);

		_context.SaveChangesAsync();

		var id = entityEntry.Entity.Id;

		return id;
	}

	public bool Delete(Project entity)
	{
		try
		{
			var entityEntry = _context.Projects.Remove(entity);

			_context.SaveChangesAsync();
		}
		catch (Exception)
		{
			return false;
		}

		return true;
	}
}
