using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPD.DTO.Events;
using System.Data.Entity;

namespace TPD.DAL.Events.Repositories
{
    public class ProgrammsRepositoryV3 : Repository<Programm>, IProgrammsRepository
    {


        public ProgrammsRepositoryV3(TunePerformanceDemoEntities dbContext)
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

        public async Task<IDictionary<ProgrammComingSoonDTO, int>> GetComingSoonAsync(int number)
        {
            var rawItems = await GetAll()
                .OrderBy(x => x.BeginAt)
                .Take(number)
                .Select(x => new
                {
                    Title = x.Title,
                    Date = x.BeginAt,
                    SpeakersNumber = x.Speakers.Count
                })
                .ToListAsync();

            IDictionary<ProgrammComingSoonDTO, int> results = rawItems
                .ToDictionary(x => new ProgrammComingSoonDTO
                {
                    Title = x.Title,
                    Date = x.Date
                }, x => x.SpeakersNumber);

            return results;
        }
    }
}
