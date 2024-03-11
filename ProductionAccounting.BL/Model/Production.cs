using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionAccounting.BL.Model
{
    /// <summary>
    /// Производство тары.
    /// </summary>
    [Serializable]
    public class Production
    {
        public DateTime Day { get;  }
        public Dictionary<Tare, double> Tares { get; }

        public User User { get; }

        public Production(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof(user));

            Day = DateTime.Today;
            Tares = new Dictionary<Tare, double>();
        }

        public void Add(Tare tare, double numb)
        {
            

            var product = Tares.Keys.FirstOrDefault(t => t.Name.Equals(tare.Name));

            if(product == null)
            {
                Tares.Add(tare, numb);
            }
            else
            {
                Tares[product] += numb;
            }
        }
    }
}
