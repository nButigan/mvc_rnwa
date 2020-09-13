using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RNWA_MVC.Models;

namespace RNWA_MVC.Models
{
    public class RNWA_MVC_context:DbContext
    {
        public RNWA_MVC_context(DbContextOptions<RNWA_MVC_context> options):base(options)
        {
        }

        public DbSet<Filmovi> filmovi { get; set; }

        public DbSet<Zanrovi> zanrovi { get; set; }
    }
}
