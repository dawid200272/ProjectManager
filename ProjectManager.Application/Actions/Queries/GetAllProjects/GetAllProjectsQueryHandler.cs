using AutoMapper;
using MediatR;
using ProjectManager.Application.Dtos;
using ProjectManager.Application.Interfaces;
using ProjectManager.Application.Models;

namespace ProjectManager.Application.Actions.Queries.GetAllProjects;
public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, IList<ProjectDto>>
{
	private readonly IRepository<Project> _repository;
	private readonly IMapper _mapper;

	public GetAllProjectsQueryHandler(
		IRepository<Project> repository,
		IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	Task<IList<ProjectDto>> IRequestHandler<GetAllProjectsQuery, IList<ProjectDto>>.Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
	{
		var projects = _repository.GetAll();

		var projectDtos = _mapper.Map<IList<ProjectDto>>(projects);

		return Task.FromResult(projectDtos);
	}
}
