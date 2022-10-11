using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using FreelancerProjects.Models;
using FreelancerProjects.Models.ViewModels;

namespace FreelancerProjects.Web
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateConfigMaps();
        }
        protected virtual void CreateConfigMaps()
        {
            //CreateMap<Category, CategoryMoedl>().ReverseMap();
            CreateMap<ProjectModel, Project>().ReverseMap();
            CreateMap<Project, ProjectModel>().ReverseMap();
            CreateMap<PlatformDevelopModel, PlatformDevelop>().ReverseMap();
            CreateMap<ProjectLog, ProjectLogModel>().ReverseMap();
        }
    }
}
