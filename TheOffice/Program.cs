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
            Console.WriteLine("Voici les Eployees groupées pour Departement");
            showEmployeesGroupedByDepartment();
            Console.WriteLine("Appuyez sur une touche pour quitter...");
            Console.ReadKey();

            ShowAnimation();
            Console.WriteLine("Voici tout la data :)");
            showAllData();
            Console.WriteLine("Appuyez sur une touche pour quitter...");
            Console.ReadKey();

            ShowAnimation();
            Console.WriteLine("Vous voulez savoir qui est \"the star\"?? regardez les acteurs qu'ont joue a minimun ce numero d'episodes:)");
            ShowCharactersByMinimumEpisodeCount();
            Console.WriteLine("Appuyez sur une touche pour quitter...");
            Console.ReadKey();

            ShowAnimation();
            Console.WriteLine("Votre Liste sera converti en format JSON");
            convListToJson();
            Console.WriteLine("Appuyez sur une touche pour quitter...");
            Console.ReadKey();

            ShowAnimation();
            Console.WriteLine("Votre Liste sera converti en format XML");
            convListToXml();
            Console.WriteLine("Appuyez sur une touche pour quitter...");
            Console.ReadKey();

            ShowAnimation();
            Console.WriteLine("Faire une recherche sur plusieurs sources de données");
            searche();
            Console.WriteLine("Appuyez sur une touche pour quitter...");
            Console.ReadKey();
        }

        static void showEmployeesGroupedByDepartment()
        {
            var employeesGroupedByDepartment = from employee in allEmployees
                                               group employee by employee.DepartmentId into departmentGroup
                                               select new
                                               {
                                                   DepartmentId = departmentGroup.Key,
                                                   Employees = departmentGroup
                                               };

            foreach (var group in employeesGroupedByDepartment)
            {
                var departmentName = allDepartments
                    .FirstOrDefault(dept => dept.DepartmentId == group.DepartmentId)?.Name;

                Console.WriteLine($"Department: {departmentName}");
                foreach (var employee in group.Employees)
                {
                    Console.WriteLine($" - Employee: {employee.Name}, Position: {employee.Position}");
                }
            }
        }

        static void showAllData()
        {
            var employeeDetails = from employee in allEmployees
                                  join department in allDepartments on employee.DepartmentId equals department.DepartmentId
                                  select new
                                  {
                                      employee.Name,
                                      employee.Position,
                                      DepartmentName = department.Name,
                                      Episodes = from episode in allEpisodes
                                                 where episode.EmployeeIds.Contains(employee.EmployeeId)
                                                 select episode.Title
                                  };

            foreach (var detail in employeeDetails)
            {
                string episodes = string.Join(", ", detail.Episodes);
                Console.WriteLine($"{detail.Name} travaille dans le {detail.DepartmentName} et il est présent sur l'épisode {episodes}");
                Console.WriteLine(" ");
            }
        }

        static void ShowCharactersByMinimumEpisodeCount()
        {
            Console.WriteLine("Entrez le nombre minimum d'épisodes:");
            string input = Console.ReadLine();
            int minEpisodeCount = 0;

            try
            {
                minEpisodeCount = int.Parse(input);
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrée invalide.");
                return;
            }

            var characters = allEmployees
                .Select(employee => new
                {
                    employee.Name,
                    employee.Position,
                    EpisodeCount = allEpisodes.Count(e => e.EmployeeIds.Contains(employee.EmployeeId))
                })
                .Where(employee => employee.EpisodeCount >= minEpisodeCount);

            Console.WriteLine($"Personnages apparaissant dans au moins {minEpisodeCount} épisodes:");

            foreach (var character in characters)
            {
                Console.WriteLine($"{character.Name}, Poste: {character.Position}, Nombre d'épisodes: {character.EpisodeCount}");
            }
        }
        static void ShowAnimation()
        {
            string text = "The Office ";
            int width = Console.WindowWidth;

            for (int i = 0; i < width + text.Length; i++)
            {
                Console.Clear();
                if (i < width)
                {
                    Console.SetCursorPosition(i, 0);
                }
                else
                {
                    Console.SetCursorPosition(width - 1, 0);
                }
                Console.Write(text);
                Thread.Sleep(10);
            }
            Console.Clear();
        }



        static void convListToXml()
        {
            // Conversion en XML
            XmlConverter.ConvertListToXml();
            Console.WriteLine("La conversion en XML est terminée.");
        }

        static void convListToJson()
        {

            // Conversion en JSON
            JsonConverter.ConvertListToJson();
            Console.WriteLine("La conversion en JSON est terminée.");

        }

        static void searche()
        {
            Console.WriteLine("Entrez le terme de recherche:");
            string searchTerm = Console.ReadLine();

            // Recherche globale dans les fichiers XML et JSON
            Searcher.SearchInAllSources(searchTerm);

            Console.WriteLine("Appuyez sur n'importe quelle touche pour quitter.");
            Console.ReadKey();
        }

    }
}
