using System;
using System.Collections.Generic;

namespace ProductionAccounting.BL.Model
{
    [Serializable]
    public class Productivity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Work> Works { get; set; }

        public double CountPerHour { get; set; }

        public Productivity() { }

        public Productivity(string name, double countPerHour)
        {
            Name = name;
            CountPerHour = countPerHour;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
