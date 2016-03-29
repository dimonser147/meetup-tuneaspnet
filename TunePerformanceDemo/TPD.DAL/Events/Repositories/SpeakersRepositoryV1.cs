using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPD.DTO.Events;

namespace TPD.DAL.Events.Repositories
{
    public class SpeakersRepositoryV1 : Repository<Speaker>, ISpeakersRepository
    {
        public SpeakersRepositoryV1(TunePerformanceDemoEntities dbContext)
            : base(dbContext)
        { }

        public IEnumerable<SpeakerPreviewDTO> GetAllSpeakers()
        {
            List<Speaker> dbSpeakers = GetAll().ToList();
            List<SpeakerPreviewDTO> dtoSpeakers = dbSpeakers
                .Select(x => new SpeakerPreviewDTO
                {
                    Firstname = x.Firstname,
                    Lastname = x.Lastname,
                    Email = x.Email,
                    Position = x.Position,
                    ImageUrl = x.ImageUrl,
                    ProgrammsCount = x.Programms.Count,
                    LikesCount = x.SpeakerLikes.Count
                })
                .ToList();
            return dtoSpeakers;
        }

        public IEnumerable<SpeakerPreviewDTO> GetTopSpeakers(int number)
        {
            string positionFilter = "developer";
            List<Speaker> dbSpeakers = GetAll().ToList();
            List<SpeakerPreviewDTO> dtoSpeakers = dbSpeakers
                .Where(x => x.Position == positionFilter)
                .OrderBy(x => x.SpeakerLikes.Count)
                .Take(number)
                .Select(x => new SpeakerPreviewDTO
                {
                    Firstname = x.Firstname,
                    Lastname = x.Lastname,
                    Email = x.Email,
                    Position = x.Position,
                    ImageUrl = x.ImageUrl,
                })
                .ToList();
            return dtoSpeakers;
        }

        public void SetQrCode(byte[] qrCode)
        {
            foreach (var speaker in GetAll())
            {
                speaker.QrCode = qrCode;
            }
            _dbContext.SaveChanges();
        }
    }
}
