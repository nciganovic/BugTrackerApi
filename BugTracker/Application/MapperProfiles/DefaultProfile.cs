using Application.Dto;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MapperProfiles
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
            CreateMap<Role, RoleDto>().ReverseMap();
            
            CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
            CreateMap<AddApplicationUserDto, ApplicationUser>();
            CreateMap<ChangeApplicationUserDto, ApplicationUser>();

            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<AddCompanyDto, Company>();
            CreateMap<ChangeCompanyDto, Company>();

            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Ticket, TicketDto>().ReverseMap();

            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<AddCommentDto, Comment>();
            CreateMap<ChangeCommentDto, Comment>();
            
            CreateMap<CompanyApplicationUserRole, CompanyApplicationUserDto>().ReverseMap();
            CreateMap<AddCompanyApplicationUserRoleDto, CompanyApplicationUserRole>();
            CreateMap<ChangeCompanyApplicationUserRoleDto, CompanyApplicationUserRole>();

            CreateMap<ProjectApplicationUser, ProjectApplicationUserDto>().ReverseMap();
            CreateMap<AddProjectApplicationUserDto, ProjectApplicationUser>();
        }
    }
}
