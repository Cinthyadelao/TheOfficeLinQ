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
            Console.WriteLine("Vous voulez savoir qui est \"the start\"?? regardez les acteurs qu'ont joue a minimun ce numero d'episodes:)");
            ShowCharactersByMinimumEpisodeCount();
            Console.WriteLine("Appuyez sur une touche pour quitter...");
            Console.ReadKey();
        }

         static void showEmployeesGroupedByDepartment() {
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

                Console.WriteLine($"Personnages apparaissant dans au moins {minEpisodeCount} épisodes:" );

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
    }
    }
           


