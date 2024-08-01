using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace TheOffice.DataSource
{
    public static class Searcher
    {
        public static void SearchInXml(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                Console.WriteLine("Le terme de recherche ne peut pas être vide ou null.");
                return;
            }

            var xmlDoc = XDocument.Load("employees.xml");
            var employees = from emp in xmlDoc.Descendants("Employee")
                            where emp.Element("Name")?.Value.Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase) == true
                            select emp;

            Console.WriteLine("Résultats de recherche dans les employés (XML):");
            foreach (var emp in employees)
            {
                Console.WriteLine($"EmployeeId: {emp.Element("EmployeeId")?.Value}, Name: {emp.Element("Name")?.Value}, Position: {emp.Element("Position")?.Value}");
            }
        }

        public static void SearchInJson(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                Console.WriteLine("Le terme de recherche ne peut pas être vide ou null.");
                return;
            }

            var jsonText = File.ReadAllText("employees.json");
            var jsonObj = JObject.Parse(jsonText);
            var employees = jsonObj["Employees"]?.Where(emp => ((string)emp["Name"]).Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase));

            if (employees == null)
            {
                Console.WriteLine("Aucun employé trouvé.");
                return;
            }

            Console.WriteLine("Résultats de recherche dans les employés (JSON):");
            foreach (var emp in employees)
            {
                Console.WriteLine($"EmployeeId: {emp["EmployeeId"]}, Name: {emp["Name"]}, Position: {emp["Position"]}");
            }
        }

        public static void SearchInAllSources(string searchTerm)
        {
            Console.WriteLine($"Recherche globale pour le terme: {searchTerm}");

            Console.WriteLine("\n=== Recherche dans les données XML ===");
            SearchInXml(searchTerm);

            Console.WriteLine("\n=== Recherche dans les données JSON ===");
            SearchInJson(searchTerm);
        }
    }
}

