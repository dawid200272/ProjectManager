using MediatR;
using ProjectManager.Application.Interfaces;
using ProjectManager.Application.Models;

namespace ProjectManager.Application.Actions.Commands.DeleteProject;
public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, ResultT<bool>>
{
	private readonly IRepository<Project> _repository;

	public DeleteProjectCommandHandler(IRepository<Project> repository)
	{
		_repository = repository;
	}

	public Task<ResultT<bool>> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
	{
		var projectToDelete = _repository.GetById(request.ProjectId);

		if (projectToDelete is null)
		{
			var notFound = ResultT<bool>.Failure(Error.NotFound(string.Empty, $"No found project with id {request.ProjectId}"));

			return Task.FromResult(notFound);
		}

		var isDeleted = _repository.Delete(projectToDelete);

		var result = ResultT<bool>.Success(isDeleted);

		return Task.FromResult(result);
	}
}
