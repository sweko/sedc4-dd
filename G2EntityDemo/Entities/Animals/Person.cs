using System.Collections.Generic;

namespace Entities.Animals
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }

        public virtual ICollection<Cat> Cats { get; set; }
    }
}