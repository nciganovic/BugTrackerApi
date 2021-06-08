﻿using Application.Dto;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.AttachmentQueries
{
    public interface IGetOneAttachmentQuery : IQuery<int, GetAttachmentDto>
    {
    }
}
