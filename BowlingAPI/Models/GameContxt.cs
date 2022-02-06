using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingAPI.Models
{
    public class GameContxt : DbContext
    {
        public GameContxt(DbContextOptions<GameContxt> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Game> Games { get; set; }
    }
}
