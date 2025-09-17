using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EjemploBlazorConEntityFramework.Model;

namespace EjemploBlazorConEntityFramework.Data
{
    public class EjemploBlazorConEntityFrameworkContext : DbContext
    {
        public EjemploBlazorConEntityFrameworkContext (DbContextOptions<EjemploBlazorConEntityFrameworkContext> options)
            : base(options)
        {
        }

        public DbSet<EjemploBlazorConEntityFramework.Model.Sensor> Sensor { get; set; } = default!;
    }
}
