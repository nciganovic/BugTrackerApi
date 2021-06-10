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
            CreateMap<AddRoleDto, Role>();
            CreateMap<ChangeRoleDto, Role>();

            CreateMap<ApplicationUser, GetApplicationUserDto>();
            CreateMap<AddApplicationUserDto, ApplicationUser>();
            CreateMap<ChangeApplicationUserDto, ApplicationUser>();

            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<AddCompanyDto, Company>();
            CreateMap<ChangeCompanyDto, Company>();

            CreateMap<Project, GetProjectDto>();
            CreateMap<AddProjectDto, Project>();
            CreateMap<ChangeProjectDto, Project>();

            CreateMap<Ticket, TicketDto>().ReverseMap();
            CreateMap<AddTicketDto, Ticket>();
            CreateMap<ChangeTicketDto, Ticket>();

            CreateMap<Comment, GetCommentDto>();
            CreateMap<AddCommentDto, Comment>();
            CreateMap<ChangeCommentDto, Comment>();
            
            CreateMap<CompanyApplicationUserRole, CompanyApplicationUserDto>().ReverseMap();
            CreateMap<AddCompanyApplicationUserRoleDto, CompanyApplicationUserRole>();
            CreateMap<ChangeCompanyApplicationUserRoleDto, CompanyApplicationUserRole>();

            CreateMap<ProjectApplicationUser, ProjectApplicationUserDto>().ReverseMap();
            CreateMap<AddProjectApplicationUserDto, ProjectApplicationUser>();

            CreateMap<AddApplicationUserCaseDto, ApplicationUserCase>();

            CreateMap<AddAttachmentDto, Attachment>();
            CreateMap<ChangeAttachmentDto, Attachment>();
            CreateMap<Attachment, GetAttachmentDto>();
        }
    }
}
