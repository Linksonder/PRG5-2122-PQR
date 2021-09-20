using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KleineDemo.Models
{
    public class Superpower
    {
        [Key]
        public string Id { get; set; }

        [ForeignKey("Hero")]
        public int HeroId { get; set; }

        public virtual  Hero Hero { get; set; }

    }
}
