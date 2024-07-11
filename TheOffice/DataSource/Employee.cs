﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOffice.DataSource
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; } = string.Empty; // Valeur par défaut
        public int DepartmentId { get; set; }
        public string Position { get; set; } = string.Empty; // Valeur par défaut
    }
}

