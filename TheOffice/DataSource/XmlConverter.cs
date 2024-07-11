using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace TheOffice.DataSource
{
    public static class XmlConverter
    {
        public static void ConvertListToXml()
        {
            // Convertir la liste des départements en XML
            var departments = ListDepartmentData.Departments;
            XElement departmentsXml = new XElement("Departments",
                from dept in departments
                select new XElement("Department",
                    new XElement("DepartmentId", dept.DepartmentId),
                    new XElement("Name", dept.Name)
                )
            );

            departmentsXml.Save("departments.xml");
            Console.WriteLine("Liste des départements convertie en XML.");

            // Convertir la liste des employés en XML
            var employees = ListEmployeeData.Employees;
            XElement employeesXml = new XElement("Employees",
                from emp in employees
                select new XElement("Employee",
                    new XElement("EmployeeId", emp.EmployeeId),
                    new XElement("Name", emp.Name),
                    new XElement("DepartmentId", emp.DepartmentId),
                    new XElement("Position", emp.Position)
                )
            );

            employeesXml.Save("employees.xml");
            Console.WriteLine("Liste des employés convertie en XML.");

            // Convertir la liste des épisodes en XML
            var episodes = ListEpisodeData.Episodes;
            XElement episodesXml = new XElement("Episodes",
                from ep in episodes
                select new XElement("Episode",
                    new XElement("EpisodeId", ep.EpisodeId),
                    new XElement("Title", ep.Title),
                    new XElement("Season", ep.Season),
                    new XElement("EpisodeNumber", ep.EpisodeNumber),
                    new XElement("EmployeeIds",
                        from id in ep.EmployeeIds
                        select new XElement("EmployeeId", id)
                    )
                )
            );

            episodesXml.Save("episodes.xml");
            Console.WriteLine("Liste des épisodes convertie en XML.");
        }
    }
}
