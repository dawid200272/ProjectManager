using ProjectManager.Application.Models;

namespace ProjectManager.Application.Actions.Commands.AddProject;
public class ProjectCreateDto
{
	public string Name { get; set; }
	public string? Description { get; set; }
	public ProjectStatus Status { get; set; }
}
