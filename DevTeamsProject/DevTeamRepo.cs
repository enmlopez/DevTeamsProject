using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeamRepo
    {
        //private readonly DeveloperRepo _developerRepo = new DeveloperRepo(); // this gives you access to the _developerRepo so you can access existing Developers and add them to a team
        private readonly List<DevTeam> _devTeams = KomodoDataBase._teams;

        //DevTeam Create

        public void AddDevsToTeam(Developer developer, DevTeam devTeam)
        {
            //3. Check to make sure they are found (Are they null?)
            if (devTeam == null)
            {
                return;
            }
            //4. If not null, add developer to the list of developers of that desired team.
            else 
            {
                devTeam.ListOfDevelopers.Add(developer);
            }
        }
        public void RemoveDevFromTeam(Developer developer, DevTeam devTeam)
        {
            if (devTeam == null)
            {
                return;
            }
            else
            {
                devTeam.ListOfDevelopers.Remove(developer);
            }
        }
        public void AddTeamToList(DevTeam devTeam)
        {
            _devTeams.Add(devTeam);
        }

        //DevTeam Read
        public List<DevTeam> GetDevTeams()
        {
            return _devTeams;
        }

        //DevTeam Update
        public bool UpdateExistingDevTeam(int oldTeamId, DevTeam newTeam) 
        {
            DevTeam oldTeam = GetTeamById(oldTeamId);

            if (oldTeam != null)
            {
                oldTeam.DevTeamId = newTeam.DevTeamId;
                oldTeam.DevTeamName = newTeam.DevTeamName;

                return true;
            }
            else
            {
                return false;
            }
        }

        //DevTeam Delete
        public bool RemoveTeamFromList(int id)
        {
            DevTeam devTeam = GetTeamById(id);

            if (devTeam == null)
            {
                return false;
            }
            int initialTeamCount = _devTeams.Count;
            _devTeams.Remove(devTeam);

            if (initialTeamCount > _devTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        //DevTeam Helper (Get Team by ID)
        public DevTeam GetTeamById(int id)
        {
            foreach(DevTeam devTeam in _devTeams)
            {
                if(devTeam.DevTeamId == id)
                {
                    return devTeam;
                }
            }
            return null;
        }

    }
}
