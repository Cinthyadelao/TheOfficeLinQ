// See https://aka.ms/new-console-template for more information
using System;
using TheOffice.DataSource;

namespace TheOffice
{
    class Program
    {
        static List<Employee> allEmployees = ListEmployeeData.Employees;
        static List<Department> allDepartments = ListDepartmentData.Departments;
        static List<Episode> allEpisodes = ListEpisodeData.Episodes;

        static void Main(string[] args)
        {
            // Conversion en XML
            XmlConverter.ConvertListToXml();
            Console.WriteLine("La conversion en XML est terminée.");

            // Conversion en JSON
            JsonConverter.ConvertListToJson();
            Console.WriteLine("La conversion en JSON est terminée.");

            Console.WriteLine("Appuyez sur n'importe quelle touche pour quitter.");
            Console.ReadKey();
        }
    }
           
}

