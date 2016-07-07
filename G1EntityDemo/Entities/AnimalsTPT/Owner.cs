using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.AnimalsTPT
{
    public class Owner
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Animal> OtherAnimals { get; set; }
        public virtual ICollection<Cat> Cats{ get; set; }
        public virtual ICollection<Crocodile> Crocodiles { get; set; }

        public IEnumerable<Animal> AllAnimals
        {
            get
            {
                return OtherAnimals.Concat(Cats).Concat(Crocodiles);
            }
        }

    }
}
