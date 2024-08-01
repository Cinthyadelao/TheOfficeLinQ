using System;
using System.Collections.Generic;
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
            try
            {
                // Conversion en XML
                XmlConverter.ConvertListToXml();
                Console.WriteLine("La conversion en XML est terminée.");

                // Conversion en JSON
                JsonConverter.ConvertListToJson();
                Console.WriteLine("La conversion en JSON est terminée.");

                Console.WriteLine("Entrez le terme de recherche:");
                string searchTerm = Console.ReadLine();

                // Recherche globale dans les fichiers XML et JSON
                Searcher.SearchInAllSources(searchTerm);

                Console.WriteLine("Appuyez sur n'importe quelle touche pour quitter.");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur dans le programme principal: {ex.Message}");
            }
        }
    }
}
