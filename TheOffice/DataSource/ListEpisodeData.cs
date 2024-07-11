using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOffice.DataSource
{
    internal class ListEpisodeData
    {
        public static List<Episode> Episodes = new List<Episode>
    {
        new Episode { EpisodeId = 1, Title = "Pilot", Season = 1, EpisodeNumber = 1, EmployeeIds = new List<int> { 1, 2, 3, 4 } },
        new Episode { EpisodeId = 2, Title = "Diversity Day", Season = 1, EpisodeNumber = 2, EmployeeIds = new List<int> { 1, 2, 3 } },
        new Episode { EpisodeId = 3, Title = "Health Care", Season = 1, EpisodeNumber = 3, EmployeeIds = new List<int> { 1, 4 } },
        new Episode { EpisodeId = 4, Title = "The Dundies", Season = 2, EpisodeNumber = 1, EmployeeIds = new List<int> { 1, 2, 3, 4 } },
        // Añade más episodios según sea necesario
    };
    }
}
