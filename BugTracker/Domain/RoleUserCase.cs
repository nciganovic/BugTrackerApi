﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RoleUserCase : BaseEntity
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int UseCaseId { get; set; }

        public virtual Role Role { get; set; }
    }
}
