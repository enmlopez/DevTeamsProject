using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class Developer
    {
        public string DevName { get; set; }
        public int DevId { get; set; }
        public bool HasPluralSight { get; set; }


        public Developer() { }
        public Developer(string devName, int devId, bool hasPluralSight)
        {
            DevName = devName;
            DevId = devId;
            HasPluralSight = hasPluralSight;
        }
    }
}
