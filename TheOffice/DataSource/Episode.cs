using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOffice.DataSource
{
    public class Episode
    {
        public int EpisodeId { get; set; }
        public string Title { get; set; }
        public int Season { get; set; }
        public int EpisodeNumber { get; set; }
        public List<int> EmployeeIds { get; set; } 
        public virtual List<Employee> Employees { get; set; } 
    }

}
