using Application.Interfaces;
using DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Logging
{
    public class DatabaseUseCaseLogger : IUseCaseLogger
    {
        private readonly BugTrackerContext _context;

        public DatabaseUseCaseLogger(BugTrackerContext context)
        {
            _context = context;
        }

        public void Log(IUseCase useCase, IApplicationActor applicationActor, object useCaseData)
        {
            _context.UseCaseLogs.Add(new Domain.UseCaseLog
            {
                Actor = applicationActor.Identity,
                Data = JsonConvert.SerializeObject(useCaseData),
                Date = DateTime.Now,
                UseCaseName = useCase.Name
            });

            _context.SaveChanges();
        }
    }
}
