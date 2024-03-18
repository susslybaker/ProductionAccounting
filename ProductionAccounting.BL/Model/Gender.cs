using System;


namespace ProductionAccounting.BL.Model
{
    [Serializable]
    /// <summary>
    /// Пол.
    /// </summary>
    public class Gender
    {

        public int Id { get;set; }
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Создать новый пол.
        /// </summary>
        /// <param name="name">Именование пола.</param>
        /// <exception cref="ArgumentNullException"></exception>
        
        public Gender() { }
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может пыть пустым или null", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    
}
