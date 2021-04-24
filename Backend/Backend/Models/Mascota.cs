using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Mascota
    {
        public int ID { get; set; }
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public int TipoMascotaId { get; set; }
        public int CategoriaMascotaId { get; set; }
        #nullable enable
        public string? Imagen { get; set; }
        public string? CartillaPdf { get; set; }
        public DateTime? FechaAlta { get; set; }
        #nullable disable
        public virtual Cliente Cliente { get; set; }
        public virtual TipoMascota TipoMascota { get; set; }
        public virtual CategoriaMascota CategoriaMascota { get; set; }
        //public virtual ICollection<Reservacion> Reservacion { get; set; }


    }
}
