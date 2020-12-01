using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    
    public class DevTeam
    {
        public int DevTeamId { get; set; }
        public string DevTeamName { get; set; }
        public List<Developer> ListOfDevelopers { get; set; } = new List<Developer>();
        

        public DevTeam() { }
        public DevTeam(int devTeamId, string devTeamName)
        {
            DevTeamId = devTeamId;
            DevTeamName = devTeamName;
        }
    }
}
