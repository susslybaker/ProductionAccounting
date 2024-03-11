using System;


namespace ProductionAccounting.BL.Model
{
    [Serializable]
    public class Work
    {
        public DateTime Start { get; }

        public DateTime Finish { get;  }

        public Productivity Productivity { get;  }

        public User User { get; }

        public Work(DateTime start, DateTime finish, Productivity productivity, User user)
        {
            Start = start;
            Finish = finish;
            Productivity = productivity;
            User = user;
        }
    }
}
