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
            CreateMap<TicketPriority, TicketPriorityDto>().ReverseMap();
            CreateMap<TicketStatus, TicketStatusDto>().ReverseMap();
            CreateMap<TicketType, TicketTypeDto>().ReverseMap();
        }
    }
}
