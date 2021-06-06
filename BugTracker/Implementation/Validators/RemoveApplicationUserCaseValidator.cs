using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using Application.Dto;
using Application.Queries.ApplicationUserCaseQueries;
using DataAccess;
using FluentValidation;

namespace Implementation.Validators
{
    public class RemoveApplicationUserCaseValidator : AbstractValidator<RemoveApplicationUserCaseDto>
    {
        private readonly BugTrackerContext _context;
        private readonly UseCaseExecutor _useCaseExector;
        private readonly IGetOneApplicationUserCaseQuery _query;

        public RemoveApplicationUserCaseValidator(BugTrackerContext context
            , UseCaseExecutor useCaseExector
            , IGetOneApplicationUserCaseQuery query)
        {
            _context = context;
            _useCaseExector = useCaseExector;
            _query = query;

            RuleFor(x => x.ApplicationUserId)
                .Must((dto, userId) => ApplicationUserCaseExists(dto))
                .WithMessage("Entity with given ApplicationUserId and CaseId doesn't exist");
          
        }

        private bool ApplicationUserCaseExists(RemoveApplicationUserCaseDto dto) 
        {
            if (_useCaseExector.ExecuteQuery(_query, dto) != null) 
            {
                return true;    
            }

            return false;
        }
    }
}
