using MediatR;
using ProjectManager.Application.Dtos;

namespace ProjectManager.Application.Actions.Queries.GetAllProjects;
public class GetAllProjectsQuery : IRequest<IList<ProjectDto>>
{
}
