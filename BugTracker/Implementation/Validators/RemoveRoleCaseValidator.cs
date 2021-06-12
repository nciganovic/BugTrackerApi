using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using Application.Dto;
using Application.Queries.RoleCaseQueries;
using DataAccess;
using FluentValidation;

namespace Implementation.Validators
{
    public class RemoveRoleCaseValidator : AbstractValidator<RemoveRoleCaseDto>
    {
        private readonly BugTrackerContext _context;
        private readonly UseCaseExecutor _useCaseExector;
        private readonly IGetOneRoleCaseQuery _query;

        public RemoveRoleCaseValidator(BugTrackerContext context
            , UseCaseExecutor useCaseExector
            , IGetOneRoleCaseQuery query)
        {
            _context = context;
            _useCaseExector = useCaseExector;
            _query = query;

            RuleFor(x => x.RoleId)
                .Must((dto, userId) => ApplicationUserCaseExists(dto))
                .WithMessage("Entity with given ApplicationUserId and CaseId doesn't exist");
          
        }

        private bool ApplicationUserCaseExists(RemoveRoleCaseDto dto) 
        {
            if (_useCaseExector.ExecuteQuery(_query, dto) != null) 
            {
                return true;    
            }

            return false;
        }
    }
}
