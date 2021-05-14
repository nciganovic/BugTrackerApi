﻿using Application.Dto;
using Application.Interfaces;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.ProjectCommands
{
    public interface IGetProjectsCommand : ICommand<ProjectSearch, IEnumerable<ProjectDto>>
    {
    }
}
