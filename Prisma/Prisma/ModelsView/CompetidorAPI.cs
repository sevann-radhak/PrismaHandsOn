using Prisma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prisma.ModelsView
{
    public class CompetidorAPI
    {
        public int CompetidorID { get; set; }

        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public string Calle { get; set; }

        public decimal Latitud { get; set; }

        public decimal Longitud { get; set; }

        public bool Marcador { get; set; }

        public bool Observar { get; set; }

        public Marca Marca { get; set; }

        public Zona Zona { get; set; }
    }
}