using ProjectManager.Application.Interfaces;

namespace ProjectManager.Application.Models;
public class Project : IEntity<int>
{
	public int Id { get ; set ; }
	public string Name { get ; set ; }
	public string? Description { get ; set ; }
	public ProjectStatus Status { get ; set ; }
}

public enum ProjectStatus
{
	NotStarted,
	InProgress,
	Abandoned,
	Finished,
}