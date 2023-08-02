using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLBTeams.Models;

namespace MLBTeams.Data
{
    public class DataClass
    {
        public BaseballTeam[] TeamsArray = new BaseballTeam[4];

        public DataClass()
        {
            TeamsArray[0] = new BaseballTeam("Yankees", "New York", "American League");
            TeamsArray[1] = new BaseballTeam("Dodgers", "Los Angeles", "National League");
        }
    }
}
