using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Actions.Commands.AddProject;
using ProjectManager.Application.Actions.Commands.DeleteProject;
using ProjectManager.Application.Actions.Queries.GetAllProjects;
using ProjectManager.Application.Actions.Queries.GetProject;
using ProjectManager.Application.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManager.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProjectController : ControllerBase
{
	private readonly IMediator _mediator;

	public ProjectController(IMediator mediator)
	{
		_mediator = mediator;
	}

	// GET: api/<ProjectController>
	[HttpGet]
	public async Task<ActionResult<IEnumerable<ProjectDto>>> Get()
	{
		var request = new GetAllProjectsQuery();

		var response = await _mediator.Send(request);

		return Ok(response);
	}

	// GET api/<ProjectController>/5
	[HttpGet("{id}", Name = "GetProject")]
	public async Task<ActionResult<ProjectDto>> GetProject(int id)
	{
		var request = new GetProjectQuery()
		{
			ProjectId = id,
		};

		var response = await _mediator.Send(request);

		if (!response.IsSuccess)
		{
			return NotFound(response.Error?.Description);
		}

		return Ok(response.Value);
	}

	// POST api/<ProjectController>
	[HttpPost]
	public async Task<ActionResult<int>> Post([FromBody] ProjectCreateDto createProjectDto)
	{
		if (createProjectDto is null)
		{
			return BadRequest(new ArgumentNullException(nameof(createProjectDto)));
		}

		var request = new AddProjectCommand()
		{
			ProjectToCreate = createProjectDto,
		};

		var response = await _mediator.Send(request);

		return CreatedAtRoute("GetProject", new { id = response }, createProjectDto);
	}

	// DELETE api/<ProjectController>/5
	[HttpDelete("{id}")]
	public async Task<ActionResult<bool>> Delete(int id)
	{
		var request = new DeleteProjectCommand()
		{
			ProjectId = id,
		};

		var response = await _mediator.Send(request);

		if (!response.IsSuccess)
		{
			return NotFound(response.Error?.Description);
		}

		return Ok($"Project with id {id} was successfully deleted");
	}
}
