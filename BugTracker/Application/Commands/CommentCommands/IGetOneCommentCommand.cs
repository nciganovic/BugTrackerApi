using Application.Dto;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.CommentCommands
{
    public interface IGetOneCommentCommand : IQuery<int, CommentDto>
    {
    }
}
