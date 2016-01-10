using System.Collections.Generic;
using System.Linq;

namespace BowlingGameV2.Models
{
    public class RollCollection : List<int>
    {
        private readonly int nrOfRolls;

        public RollCollection(int nrOfRolles)
        {
            this.nrOfRolls = nrOfRolles;
        }

        public new void Add(int val)
        {
            if (nrOfRolls == 2)
            {
                if (PinsDown < 10 && Count < nrOfRolls)
                {
                    base.Add(val);
                }
            }
            else
            {
                if (Count < nrOfRolls)
                {
                    base.Add(val);
                }
            }
        }

        public int PinsDown //how much pins are down for a frame
        {
            get { return this.Sum(t => t); }
        }
    }
}