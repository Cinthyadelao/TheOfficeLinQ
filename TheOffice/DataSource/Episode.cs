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
        public string Title { get; set; } = string.Empty; // Valeur par défaut
        public int Season { get; set; }
        public int EpisodeNumber { get; set; }
        public List<int> EmployeeIds { get; set; } = new List<int>(); // Valeur par défaut
        public virtual List<Employee> Employees { get; set; } = new List<Employee>(); // Valeur par défaut
    }
}
