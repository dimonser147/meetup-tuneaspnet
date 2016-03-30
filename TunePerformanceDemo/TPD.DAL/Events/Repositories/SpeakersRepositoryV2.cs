using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPD.DTO.Events;
using System.Data.Entity;
using System.Data;

namespace TPD.DAL.Events.Repositories
{
    public class SpeakersRepositoryV2 : Repository<Speaker>, ISpeakersRepository
    {
        public SpeakersRepositoryV2(TunePerformanceDemoEntities dbContext)
            : base(dbContext)
        { }

        public IEnumerable<SpeakerPreviewDTO> GetAllSpeakers()
        {
            List<SpeakerPreviewDTO> dtoSpeakers = new List<SpeakerPreviewDTO>();
            var query = _dbContext.Speakers
                .Include(x => x.SpeakerLikes)
                .Include(x => x.Programms);
            foreach (var dbSpeaker in query)
            {
                SpeakerPreviewDTO dtoSpeaker = new SpeakerPreviewDTO
                {
                    Firstname = dbSpeaker.Firstname,
                    Lastname = dbSpeaker.Lastname,
                    Email = dbSpeaker.Email,
                    ImageUrl  = dbSpeaker.ImageUrl
                };
                dtoSpeaker.ProgrammsCount = dbSpeaker.Programms.Count;
                dtoSpeaker.LikesCount = dbSpeaker.SpeakerLikes.Count;
                dtoSpeakers.Add(dtoSpeaker);
            }
            return dtoSpeakers;
        }

        public Task<IEnumerable<SpeakerPreviewDTO>> GetAllSpeakersAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SpeakerPreviewDTO> GetTopSpeakers(int number)
        {
            string positionFilter = "developer";
            List<SpeakerPreviewDTO> dtoSpeakers = GetAll()
                .Where(x => x.Position == positionFilter)
                .Include(x => x.SpeakerLikes)
                .OrderBy(x => x.SpeakerLikes.Count)
                .Take(number)
                .Select(x => new SpeakerPreviewDTO
                {
                    Firstname = x.Firstname,
                    Lastname = x.Lastname,
                    Position = x.Position,
                    ImageUrl = x.ImageUrl,
                })
                .ToList();
            return dtoSpeakers;
        }

        public Task<IEnumerable<SpeakerPreviewDTO>> GetTopSpeakersAsync(int number)
        {
            throw new NotImplementedException();
        }

        public void SetQrCode(byte[] qrCode)
        {
            string query = "update [Speakers] set [QrCode] = {0}";
            _dbContext.Database.ExecuteSqlCommand(query, qrCode);
        }

        public Task SetQrCodeAsync(byte[] qrCode)
        {
            throw new NotImplementedException();
        }
    }
}
