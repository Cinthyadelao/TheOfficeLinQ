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
        /*Tri dans SearchInXml: ajout� orderby emp.Element("Name")?.Value 
        dans la requ�te LINQ pour trier les r�sultats par le nom des employ�s.*/
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                Console.WriteLine("Le terme de recherche ne peut pas �tre vide ou null.");
                return;
            }

            var xmlDoc = XDocument.Load("employees.xml");
            var employees = from emp in xmlDoc.Descendants("Employee")
                            where emp.Element("Name")?.Value.Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase) == true
                            orderby emp.Element("Name")?.Value // Tri par nom
                            select emp;

            Console.WriteLine("R�sultats de recherche dans les employ�s (XML):");
            foreach (var emp in employees)
            {
                Console.WriteLine($"EmployeeId: {emp.Element("EmployeeId")?.Value}, Name: {emp.Element("Name")?.Value}, Position: {emp.Element("Position")?.Value}");
            }
        }


        public static void SearchInJson(string searchTerm)
            /* Tri dans SearchInJson: ajout� .OrderBy(emp => (string)emp["Name"]) apr�s la m�thode Where 
             * pour trier les r�sultats par le nom des employ�s.*/
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                Console.WriteLine("Le terme de recherche ne peut pas �tre vide ou null.");
                return;
            }

            var jsonText = File.ReadAllText("employees.json");
            var jsonObj = JObject.Parse(jsonText);
            var employees = jsonObj["Employees"]
                             ?.Where(emp => ((string)emp["Name"]).Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase))
                             .OrderBy(emp => (string)emp["Name"]); // Tri par nom

            if (employees == null)
            {
                Console.WriteLine("Aucun employ� trouv�.");
                return;
            }

            Console.WriteLine("R�sultats de recherche dans les employ�s (JSON):");
            foreach (var emp in employees)
            {
                Console.WriteLine($"EmployeeId: {emp["EmployeeId"]}, Name: {emp["Name"]}, Position: {emp["Position"]}");
            }
        }

        public static void SearchInAllSources(string searchTerm)
        {
            Console.WriteLine($"Recherche globale pour le terme: {searchTerm}");

            Console.WriteLine("\n=== Recherche dans les donn�es XML ===");
            SearchInXml(searchTerm);

            Console.WriteLine("\n=== Recherche dans les donn�es JSON ===");
            SearchInJson(searchTerm);
        }
    }
}

