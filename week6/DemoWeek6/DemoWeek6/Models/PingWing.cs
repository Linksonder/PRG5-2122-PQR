using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWeek6.Models
{
    public class PingWing
    {
        [Key]
        public string Id { get; set; }

        [MaxLength(10)]
        public string Naam { get; set; }

        public int Hoogte { get; set; }

    }
}

