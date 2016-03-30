using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPD.DTO.Events;

namespace TPD.DAL.Events.Repositories
{
    public class ProgrammsRepositoryV1 : Repository<Programm>, IProgrammsRepository
    {
        public ProgrammsRepositoryV1(TunePerformanceDemoEntities dbContext)
            : base(dbContext)
        { }

        IDictionary<ProgrammComingSoonDTO, int> IProgrammsRepository.GetComingSoon(int number)
        {
            var results = this.GetAll()
                .OrderBy(x => x.BeginAt)
                .Take(number)
                .ToDictionary(x => new ProgrammComingSoonDTO
                {
                    Title = x.Title,
                    Date = x.BeginAt
                }, x => x.Speakers.Count);
            return results;

        }

        public Task<IDictionary<ProgrammComingSoonDTO, int>> GetComingSoonAsync(int number)
        {
            throw new NotImplementedException();
        }
    }
}
