using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWeek6.Models
{
    public class PingWing
    {
        [MaxLength(10)]
        public string Naam { get; set; }

        [MinLength(0)]
        [MaxLength(200)]
        public int Hoogte { get; set; }
    }
}
