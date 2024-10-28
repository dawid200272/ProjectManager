using MediatR;

namespace ProjectManager.Application.Actions.Commands.AddProject;
public class AddProjectCommand : IRequest<int>
{
	public ProjectCreateDto ProjectToCreate { get; set; }
}
