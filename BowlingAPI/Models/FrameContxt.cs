using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingAPI.Models
{
    public class FrameContxt : DbContext
    {
        public FrameContxt(DbContextOptions<FrameContxt> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Frame> Frames { get; set; }
    }
}

