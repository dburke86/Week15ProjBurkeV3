using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Week15ProjBurkeV2.Models;

namespace Week15ProjBurkeV2.Data
{
    public class VoiceOverDBContext : DbContext
    {
        public VoiceOverDBContext (DbContextOptions<VoiceOverDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Week15ProjBurkeV2.Models.VOJobs> VOJobs { get; set; }
    }
}
