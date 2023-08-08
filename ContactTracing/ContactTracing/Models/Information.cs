using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactTracing.Models
{
    public class Information
    {
        

        public string Name { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public Information(string name, string date, string location)
        {
            Name = name;
            Date = date;
            Location = location;
        }
    }
}
