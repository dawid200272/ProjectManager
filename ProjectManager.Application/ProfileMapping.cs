using AutoMapper;
using ProjectManager.Application.Actions.Commands.AddProject;
using ProjectManager.Application.Dtos;
using ProjectManager.Application.Models;

namespace ProjectManager.Application;
public class ProfileMapping : Profile
{
	public ProfileMapping()
	{
		CreateMap<Project, ProjectDto>().ReverseMap();
		CreateMap<ProjectCreateDto, Project>();
	}
}
