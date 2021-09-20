using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KleineDemo.Models;

namespace KleineDemo.Models
{
    public class MijnContext : DbContext
    {
        public MijnContext(DbContextOptions<MijnContext> options) : base(options)
        {
        }

        public DbSet<Hero> Heroes { get; set; }

        public DbSet<KleineDemo.Models.Superpower> Superpower { get; set; }
    }
}
