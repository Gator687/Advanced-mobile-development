using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLBTeamsView.Models
{
    public class BaseballTeam
    {
        public string TeamName { get; set; }
        public string City { get; set; }
        public string League { get; set; }

        public BaseballTeam(string teamName, string city, string league)
        {
            TeamName = teamName;
            City = city;
            League = league;
        }
    }
}
