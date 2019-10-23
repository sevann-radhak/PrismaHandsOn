using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prisma.Models
{
    public class Marca
    {
        [Key]
        public int MarcaID { get; set; }

        public string Codigo { get; set; }

        public string Nombre { get; set; }

        [JsonIgnore]
        public virtual IQueryable<Competidor> Competidores { get; set; }
    }
}