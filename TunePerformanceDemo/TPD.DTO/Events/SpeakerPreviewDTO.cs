using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPD.DTO.Events
{
    public class SpeakerPreviewDTO
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }

        public int ProgrammsCount { get; set; }

        public int LikesCount { get; set; }
    }
}
