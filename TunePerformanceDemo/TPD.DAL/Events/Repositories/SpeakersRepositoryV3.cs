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
    public class SpeakersRepositoryV3 : Repository<Speaker>, ISpeakersRepository
    {
        private readonly string _positionFilter = "developer";

        public SpeakersRepositoryV3(TunePerformanceDemoEntities dbContext)
            : base(dbContext)
        { }

        public IEnumerable<SpeakerPreviewDTO> GetAllSpeakers()
        {
            var speakers = _dbContext.Speakers
                .Include(x => x.SpeakerLikes)
                .Include(x => x.Programms)
                .Select(x => new SpeakerPreviewDTO
                {
                    Firstname = x.Firstname,
                    Lastname = x.Lastname,
                    Email = x.Email,
                    ImageUrl = x.ImageUrl,
                    LikesCount = x.SpeakerLikes.Count,
                    ProgrammsCount = x.Programms.Count
                })
                .ToList();
            return speakers;
        }

        public async Task<IEnumerable<SpeakerPreviewDTO>> GetAllSpeakersAsync()
        {
            var speakers = await _dbContext.Speakers
                .Include(x => x.SpeakerLikes)
                .Include(x => x.Programms)
                .Select(x => new SpeakerPreviewDTO
                {
                    Firstname = x.Firstname,
                    Lastname = x.Lastname,
                    Email = x.Email,
                    ImageUrl = x.ImageUrl,
                    LikesCount = x.SpeakerLikes.Count,
                    ProgrammsCount = x.Programms.Count
                })
                .ToListAsync();
            return speakers;
        }

        public IEnumerable<SpeakerPreviewDTO> GetTopSpeakers(int number)
        {
            List<SpeakerPreviewDTO> dtoSpeakers = GetAll()
                .Where(x => x.Position == _positionFilter)
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

        public async Task<IEnumerable<SpeakerPreviewDTO>> GetTopSpeakersAsync(int number)
        {
            List<SpeakerPreviewDTO> dtoSpeakers = await GetAll()
                .Where(x => x.Position == _positionFilter)
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
                .ToListAsync();
            return dtoSpeakers;
        }

        public void SetQrCode(byte[] qrCode)
        {
            string query = "update [Speakers] set [QrCode] = {0}";
            _dbContext.Database.ExecuteSqlCommand(query, qrCode);
        }

        public async Task SetQrCodeAsync(byte[] qrCode)
        {
            string query = "update [Speakers] set [QrCode] = {0}";
            await _dbContext.Database.ExecuteSqlCommandAsync(query, qrCode);
        }
    }
}
