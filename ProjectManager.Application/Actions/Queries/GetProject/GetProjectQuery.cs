using MediatR;
using ProjectManager.Application.Dtos;

namespace ProjectManager.Application.Actions.Queries.GetProject;
public class GetProjectQuery : IRequest<ResultT<ProjectDto>>
{
	public int ProjectId { get; set; }
}
