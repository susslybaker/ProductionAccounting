using ProductionAccounting.BL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionAccounting.BL.Controller
{
    internal class ProductionContext : DbContext
    {
        public ProductionContext() : base("DefaultConnection") { }

        public DbSet<Productivity> Productivities { get; set; }
        public DbSet<Production> Productions { get; set; }

        public DbSet<Work> Works { get; set; }

        public DbSet<Tare> Tares { get;set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<User> Users { get; set; }
    }

}
