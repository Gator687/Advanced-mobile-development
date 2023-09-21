using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BaseballTeamApp
{
    public class BaseballTeam
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string TeamName { get; set; }
        public string City { get; set; }
        public string League { get; set; }
    }

    public class DatabaseContext
    {
        public SQLiteConnection Connection { get; }

        public DatabaseContext()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BaseballTeams.db");
            Connection = new SQLiteConnection(dbPath);
            Connection.CreateTable<BaseballTeam>();
        }
    }
}
