using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DeveloperRepo
    {
        private readonly List<Developer> _devRepo = KomodoDataBase._developer; //United Developer classes - no stacking

        //Developer Create
        public void AddDevToList(Developer developer)
        {
            _devRepo.Add(developer);
        }

        //Developer Read
        public List<Developer> GetDevList()
        {
            return _devRepo;
        }

        //Developer Update
        public bool UpdateExistingDevList (int oldDevId, Developer newDeveloper)
        {
            Developer oldDeveloper = GetDevById(oldDevId);
            if (oldDeveloper != null)
            {
                oldDeveloper.DevName = newDeveloper.DevName;
                oldDeveloper.DevId = newDeveloper.DevId;
                oldDeveloper.HasPluralSight = newDeveloper.HasPluralSight;

                return true;
            }
            else
            {
                return false;
            }
        }

        //Developer Delete
        public bool RemoveDevFromList(int id)
        {
            Developer developer = GetDevById(id);

            if (developer == null)
            {
                return false;
            }

            int initialDevCount = _devRepo.Count;
            _devRepo.Remove(developer);

            if (initialDevCount > _devRepo.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        //Developer Helper (Get Developer by ID)
        public Developer GetDevById(int id)
        {
            foreach (Developer developer in _devRepo)
            {
                if (developer.DevId == id)
                {
                    return developer;
                } 
            }
            return null;
        }
        public List<Developer> GetDevByBool()
        {
            List<Developer> devs = new List<Developer>();
            foreach (Developer developer in _devRepo)
            {
                if (developer.HasPluralSight == false)
                {
                    devs.Add(developer);
                }
            }
            return devs;
        }
    }
}
