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
        new Episode { EpisodeId = 5, Title = "Office Olympics", Season = 2, EpisodeNumber = 3, EmployeeIds = new List<int> { 2, 3, 4, 7, 8 } },
        new Episode { EpisodeId = 6, Title = "Booze Cruise", Season = 2, EpisodeNumber = 11, EmployeeIds = new List<int> { 1, 2, 5, 6, 9 } },
        new Episode { EpisodeId = 7, Title = "The Injury", Season = 2, EpisodeNumber = 12, EmployeeIds = new List<int> { 1, 4, 5, 6, 10 } },
        new Episode { EpisodeId = 8, Title = "Michael's Birthday", Season = 2, EpisodeNumber = 19, EmployeeIds = new List<int> { 1, 2, 3, 4, 9 } },
        new Episode { EpisodeId = 9, Title = "Safety Training", Season = 3, EpisodeNumber = 20, EmployeeIds = new List<int> { 1, 2, 3, 7, 8 } },
        new Episode { EpisodeId = 10, Title = "Beach Games", Season = 3, EpisodeNumber = 23, EmployeeIds = new List<int> { 1, 2, 4, 5, 6 } }
    };
    }
}
