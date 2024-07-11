using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOffice.DataSource
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; } = string.Empty; // Valeur par défaut
        public virtual List<Employee> Employees { get; set; } = new List<Employee>(); // Valeur par défaut
    }
}

