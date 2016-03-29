using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPD.DAL.Events
{
    public interface IEventUOW : IUnitOfWork
    {
        ISpeakersRepository SpeakersRepository { get; set; }

        IProgrammsRepository ProgrammsRepository { get; set; }
    }
}
