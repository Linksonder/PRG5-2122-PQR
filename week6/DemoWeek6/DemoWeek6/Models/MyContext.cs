using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWeek6.Models
{
    public class MyContext : DbContext
    {
        public DbSet<PingWing> PingWings { get; set; }

        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {

        }
    }
}
