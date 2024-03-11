using ProductionAccounting.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductionAccounting.BL.Controller
{
    public class WorkController : ControllerBase
    {
        private readonly User user;
        private const string WORKS_FILE_NAME = "works.dat";
        private const string PRODUCTIVITIES_FILE_NAME = "productivities.dat";
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
            return Load<List<Productivity>>(PRODUCTIVITIES_FILE_NAME) ?? new List<Productivity>();
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
            return Load < List < Work >> (WORKS_FILE_NAME) ?? new List<Work>(); 
        }

        private void Save()
        {
            Save(WORKS_FILE_NAME, Works);
            Save(PRODUCTIVITIES_FILE_NAME, Productivities);
        }
        

            
    }
}
