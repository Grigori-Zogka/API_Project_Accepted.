using System;
using System.Collections.Generic;

namespace API_Project_Accepted.Models
{
    public partial class Match
    {
        public Match()
        {
            MatchOdds = new HashSet<MatchOdds>();
        }

        public int Id { get; set; }
        public string Descreption { get; set; }
        public DateTime? MatchDate { get; set; }
        public TimeSpan? MatchTime { get; set; }
        public string TeamA { get; set; }
        public string TeamB { get; set; }
        public bool Sport { get; set; }

        public virtual ICollection<MatchOdds> MatchOdds { get; set; }
    }
}
