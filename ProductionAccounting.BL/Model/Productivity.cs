using System;


namespace ProductionAccounting.BL.Model
{
    [Serializable]
    public class Productivity
    {
        public string Name { get; set; }

        public double CountPerHour { get; set; }

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
