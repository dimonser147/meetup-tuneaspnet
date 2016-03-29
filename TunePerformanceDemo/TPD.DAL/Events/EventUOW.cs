using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPD.DAL.Events
{
    public class EventUOW : UnitOfWork, IEventUOW
    {
        public EventUOW(TunePerformanceDemoEntities dbContext)
            : base(dbContext)
        { }


        [Dependency]
        public IProgrammsRepository ProgrammsRepository { get; set; }

        [Dependency]
        public ISpeakersRepository SpeakersRepository { get; set; }
    }
}
