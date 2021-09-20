using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KleineDemo.Models
{
    public class Hero
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PowerLevel { get; set; }
        //hierna mag je - 'add-migration superpowers' en dan update-database
        public virtual ICollection<Superpower> Superpowers { get; set; }
    }
}
