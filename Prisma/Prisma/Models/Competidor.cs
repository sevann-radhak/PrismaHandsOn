using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prisma.Models
{
    public class Competidor
    {
        [Key]
        public int CompetidorID { get; set; }

        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public string Calle { get; set; }

        public decimal Latitud { get; set; }

        public decimal Longitud { get; set; }

        public bool Marcador { get; set; }

        public bool Observar { get; set; }

        public int MarcaID { get; set; }

        public int ZonaID { get; set; }

        [JsonIgnore]
        public virtual Marca Marca { get; set; }

        [JsonIgnore]
        public virtual Zona Zona { get; set; }
    }
}