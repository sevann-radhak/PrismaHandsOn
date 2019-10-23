using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Prisma.Context
{
    public class PrismaContext : DbContext
    {
        public System.Data.Entity.DbSet<Prisma.Models.Marca> Marcas { get; set; }

        public System.Data.Entity.DbSet<Prisma.Models.Zona> Zonas { get; set; }

        public System.Data.Entity.DbSet<Prisma.Models.Competidor> Competidors { get; set; }
    }
}