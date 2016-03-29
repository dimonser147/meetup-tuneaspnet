using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPD.DAL.Events
{
    public interface ISpeakersRepository : IRepository<Speaker>
    {
        IEnumerable<TPD.DTO.Events.SpeakerPreviewDTO> GetAllSpeakers();

        IEnumerable<TPD.DTO.Events.SpeakerPreviewDTO> GetTopSpeakers(int number);

        /// <summary>
        /// Set new QR code for all speakers and immediately save changes to DB
        /// </summary>
        /// <param name="qrCode"></param>
        void SetQrCode(byte[] qrCode);
    }
}
