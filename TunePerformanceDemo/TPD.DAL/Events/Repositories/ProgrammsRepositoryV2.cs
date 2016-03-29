using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPD.DTO.Events;

namespace TPD.DAL.Events.Repositories
{
    public class ProgrammsRepositoryV2 : Repository<Programm>, IProgrammsRepository
    {
        public ProgrammsRepositoryV2(TunePerformanceDemoEntities dbContext)
            : base(dbContext)
        { }

        IDictionary<ProgrammComingSoonDTO, int> IProgrammsRepository.GetComingSoon(int number)
        {
            var results = this.GetAll()
                .OrderBy(x => x.BeginAt)
                .Take(number)
                .Select(x => new
                {
                    Title = x.Title,
                    Date = x.BeginAt,
                    SpeakersNumber = x.Speakers.Count
                })
                .ToList()
                .ToDictionary(x => new ProgrammComingSoonDTO
                {
                    Title = x.Title,
                    Date = x.Date
                }, x => x.SpeakersNumber);
            return results;

        }
    }
}
