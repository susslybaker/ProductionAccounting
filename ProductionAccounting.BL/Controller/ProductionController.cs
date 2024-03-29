﻿using ProductionAccounting.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductionAccounting.BL.Controller
{
    [Serializable]
    public class ProductionController : ControllerBase
    {
   
        private readonly User user;
        public List<Tare> Tares { get;  }
        public Production Production { get;  }

        public ProductionController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof(user));

            Tares = GetAllTares();
            Production = GetProduction();
        }

       
         
       

        public void Add(Tare tare, double numb)
        {
            var product = Tares.SingleOrDefault(t => t.Name == tare.Name);
            if(product == null)
            {
                Tares.Add(tare);
                Production.Add(tare, numb);
                Save();
            }
            else
            {
                Production.Add(product, numb);
                Save();
            }
        }

        private Production GetProduction()
        {
            return Load<Production>().FirstOrDefault() ?? new Production(user);
        }

        private List<Tare> GetAllTares()
        {
            return Load<Tare>() ?? new List<Tare>(); 
            
        }

        private void Save()
        {
            Save(Tares);
          
        }
    }
}
