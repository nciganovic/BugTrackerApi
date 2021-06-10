using Application.Commands.ProjectCommands;
using Application.Dto;
using Application.Exceptions;
using Application.Queries.ProjectQueries;
using AutoMapper;
using DataAccess;
using Domain;
using Implementation.EfCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.ProjectCommandsQueries
{
    public class EfGetOneProjectQuery : BaseUseCase, IGetOneProjectQuery
    {
        private IMapper _mapper;

        public EfGetOneProjectQuery(BugTrackerContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 25;

        public string Name => "Get one project";

        public GetProjectDto Execute(int request)
        {
            var project = context.Projects.Find(request);


            return _mapper.Map<Project, GetProjectDto>(project);
        }
    }
}
