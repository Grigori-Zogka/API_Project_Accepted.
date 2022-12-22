using System;
using System.Collections.Generic;

namespace API_Project_Accepted.Models
{
    public partial class MatchOdds
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public string Specifier { get; set; }
        public decimal Odd { get; set; }

        public virtual Match Match { get; set; }
    }
}
