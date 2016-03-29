using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPD.DTO.Events
{
    public class ProgrammComingSoonDTO : IEquatable<ProgrammComingSoonDTO>
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }

        public int Day
        {
            get
            {
                return Date.Day;
            }
        }

        public string Month
        {
            get
            {
                return Date.ToString("MMM");
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ProgrammComingSoonDTO);
        }
        public bool Equals(ProgrammComingSoonDTO other)
        {
            return other != null && other.Date == Date && string.Equals(Title, other.Title, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return Date.GetHashCode() ^ Title.GetHashCode();
        }
    }
}
