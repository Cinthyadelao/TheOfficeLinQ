
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TheOffice.DataSource
{
    public static class JsonConverter
    {
        public static void ConvertListToJson()
        {
            try
            {
                // Convertir la liste des départements en JSON
                var departments = ListDepartmentData.Departments;
                string departmentsJson = JsonConvert.SerializeObject(new { Departments = departments }, Formatting.Indented);
                File.WriteAllText("departments.json", departmentsJson);
                Console.WriteLine("Liste des départements convertie en JSON.");

                // Convertir la liste des employés en JSON
                var employees = ListEmployeeData.Employees;
                string employeesJson = JsonConvert.SerializeObject(new { Employees = employees }, Formatting.Indented);
                File.WriteAllText("employees.json", employeesJson);
                Console.WriteLine("Liste des employés convertie en JSON.");

                // Convertir la liste des épisodes en JSON
                var episodes = ListEpisodeData.Episodes;
                string episodesJson = JsonConvert.SerializeObject(new { Episodes = episodes }, Formatting.Indented);
                File.WriteAllText("episodes.json", episodesJson);
                Console.WriteLine("Liste des épisodes convertie en JSON.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la conversion en JSON: {ex.Message}");
            }
        }
    }
}
