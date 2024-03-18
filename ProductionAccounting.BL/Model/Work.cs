using System;


namespace ProductionAccounting.BL.Model
{
    [Serializable]
    public class Work
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }

        public Work() { }
        public DateTime Finish { get; set; }

        public int ProductivityID { get; set; }

        public virtual Productivity Productivity { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }

        

        

        public Work(DateTime start, DateTime finish, Productivity productivity, User user)
        {
            Start = start;
            Finish = finish;
            Productivity = productivity;
            User = user;
        }
    }
}
