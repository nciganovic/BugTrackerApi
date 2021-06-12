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
            CreateMap<Role, GetRoleDto>();
            CreateMap<AddRoleDto, Role>();
            CreateMap<ChangeRoleDto, Role>();

            CreateMap<ApplicationUser, GetApplicationUserDto>().ReverseMap();
            CreateMap<AddApplicationUserDto, ApplicationUser>();
            CreateMap<ChangeApplicationUserDto, ApplicationUser>();
            CreateMap<RegisterDto, ApplicationUser>();

            CreateMap<Project, GetProjectDto>();
            CreateMap<AddProjectDto, Project>();
            CreateMap<ChangeProjectDto, Project>();

            CreateMap<Ticket, GetTicketDto>();
            CreateMap<AddTicketDto, Ticket>();
            CreateMap<ChangeTicketDto, Ticket>();

            CreateMap<Comment, GetCommentDto>();
            CreateMap<AddCommentDto, Comment>();
            CreateMap<ChangeCommentDto, Comment>();

            CreateMap<ProjectApplicationUser, GetProjectApplicationUserDto>();
            CreateMap<AddProjectApplicationUserDto, ProjectApplicationUser>();

            CreateMap<AddRoleCaseDto, RoleUserCase>();

            CreateMap<AddAttachmentDto, Attachment>();
            CreateMap<ChangeAttachmentDto, Attachment>();
            CreateMap<Attachment, GetAttachmentDto>();
        }
    }
}
