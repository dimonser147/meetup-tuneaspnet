using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPD.DAL.Events
{
    public interface IProgrammsRepository : IRepository<Programm>
    {
        IDictionary<TPD.DTO.Events.ProgrammComingSoonDTO, int> GetComingSoon(int number);

        Task<IDictionary<TPD.DTO.Events.ProgrammComingSoonDTO, int>> GetComingSoonAsync(int number);
    }
}
