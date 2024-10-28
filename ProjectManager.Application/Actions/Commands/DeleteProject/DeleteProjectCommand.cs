using MediatR;

namespace ProjectManager.Application.Actions.Commands.DeleteProject;
public class DeleteProjectCommand : IRequest<ResultT<bool>>
{
	public int ProjectId { get; set; }
}
