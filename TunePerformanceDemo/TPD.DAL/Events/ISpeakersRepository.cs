using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPD.DAL.Events
{
    public interface ISpeakersRepository : IAsyncRepository<Speaker>
    {
        IEnumerable<TPD.DTO.Events.SpeakerPreviewDTO> GetAllSpeakers();
        Task<IEnumerable<TPD.DTO.Events.SpeakerPreviewDTO>> GetAllSpeakersAsync();

        IEnumerable<TPD.DTO.Events.SpeakerPreviewDTO> GetTopSpeakers(int number);
        Task<IEnumerable<TPD.DTO.Events.SpeakerPreviewDTO>> GetTopSpeakersAsync(int number);

        /// <summary>
        /// Set new QR code for all speakers and immediately save changes to DB
        /// </summary>
        /// <param name="qrCode"></param>
        void SetQrCode(byte[] qrCode);

        Task SetQrCodeAsync(byte[] qrCode);
    }
}
