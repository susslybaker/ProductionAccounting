using ProductionAccounting.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductionAccounting.BL.Controller
{
    public class WorkController : ControllerBase
    {
        private readonly User user;
        
        public List<Work> Works { get; }
        public List<Productivity> Productivities { get; }
        

        public WorkController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));

            Works = GetAllWorks();
            Productivities = GetAllProductivities();
        }

        private List<Productivity> GetAllProductivities()
        {
            return Load<Productivity>() ?? new List<Productivity>();
        }

        public void Add(Productivity productivity, DateTime begin, DateTime end)
        {
            var prod = Productivities.SingleOrDefault(p => p.Name == productivity.Name);

            if(prod == null)
            {
                Productivities.Add(productivity);

                var work = new Work(begin, end, productivity, user);
                Works.Add(work);

             
            }
            else
            {
                var work = new Work(begin, end, prod, user);
                Works.Add(work);

                
            }
            Save();
        }

        private List<Work> GetAllWorks()
        {
            return Load < Work > () ?? new List<Work>(); 
        }

        private void Save()
        {
            Save(Works);
            Save(Productivities);
        }
        

            
    }
}
