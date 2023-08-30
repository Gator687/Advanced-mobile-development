using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncounterTracker.Models
{
    public class Encounter
    {
        

        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }

        public Encounter(string name, DateTime date, string location)
        {
            Name = name;
            Date = date;
            Location = location;
        }

        public Encounter()
        {
            Name = "";
            Date = new System.DateTime();
            Location = "";
        }

        public override string ToString()
        {
            return $"{Name} - {Date:d} - {Location}";
        }
    }
}
