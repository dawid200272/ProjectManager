using AutoMapper;
using MediatR;
using ProjectManager.Application.Dtos;
using ProjectManager.Application.Interfaces;
using ProjectManager.Application.Models;

namespace ProjectManager.Application.Actions.Queries.GetProject;
internal class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, ResultT<ProjectDto>>
{
	private readonly IRepository<Project> _repository;
	private readonly IMapper _mapper;

	public GetProjectQueryHandler(IRepository<Project> repository,
		IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public Task<ResultT<ProjectDto>> Handle(GetProjectQuery request, CancellationToken cancellationToken)
	{
		var project = _repository.GetById(request.ProjectId);

		if (project is null)
		{
			var notFound = ResultT<ProjectDto>.Failure(Error.NotFound(string.Empty, $"No found project with id {request.ProjectId}"));

			return Task.FromResult(notFound);
		}

		var projectDto = _mapper.Map<ProjectDto>(project);

		var result = ResultT<ProjectDto>.Success(projectDto);

		return Task.FromResult(result);
	}
}
