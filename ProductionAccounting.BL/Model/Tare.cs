using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionAccounting.BL.Model
{
    [Serializable]
    public class Tare
    {
        public int Id { get;set; }
      
        public string Name { get; set; }
        /// <summary>
        /// Объем тары.
        /// </summary>
        public double Volume { get; set; }
        /// <summary>
        /// Средний вес тары.
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Стоимость тары
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Количество произведенной тары
        /// </summary>
        public int NumbOfProduct { get; set; }

        public Tare() { }

        public Tare(string name) : this(name, 0,0,0,0)
        {
          
        }

        public Tare(string name, double volume, double price, int numb, double weight)
        {
            Name = name;
            Volume = volume / 100.0;
            Price = price / 100.0 * NumbOfProduct;
            NumbOfProduct = numb / 12;
            Weight = weight / 100.0;
        }

        public override string ToString()
        {
            return Name;
        }


    }
}
