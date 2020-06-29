using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WEB_TechnoV1_PatrickRibeiro.Models;

namespace WEB_TechnoV1_PatrickRibeiro.Data
{
    public class APISKKContext : DbContext
    {
        public APISKKContext (DbContextOptions<APISKKContext> options)
            : base(options)
        {
        }

        public DbSet<WEB_TechnoV1_PatrickRibeiro.Models.Skills> Skills { get; set; }

        public DbSet<WEB_TechnoV1_PatrickRibeiro.Models.Contacts> Contacts { get; set; }
    }
}
