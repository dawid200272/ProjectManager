using AutoMapper;
using MediatR;
using ProjectManager.Application.Interfaces;
using ProjectManager.Application.Models;

namespace ProjectManager.Application.Actions.Commands.AddProject;
public class AddProjectCommandHandler : IRequestHandler<AddProjectCommand, int>
{
	private readonly IRepository<Project> _repository;
	private readonly IMapper _mapper;

	public AddProjectCommandHandler(IRepository<Project> repository,
		IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public Task<int> Handle(AddProjectCommand request, CancellationToken cancellationToken)
	{
		var projectToAdd = _mapper.Map<Project>(request.ProjectToCreate);

		return Task.FromResult(_repository.Add(projectToAdd));
	}
}
