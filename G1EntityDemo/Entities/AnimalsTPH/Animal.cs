using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.AnimalsTPH
{
    public class Animal
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }

        public int OwnerID { get; set; }

        public virtual Owner Owner { get; set; }
    }
}
