using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Mascota
    {
        public long MasCliente { get; set; }
        public int MasId { get; set; }
        public string MasNombre { get; set; }
        public int MasEdad { get; set; }
        public int MasTipoMascota { get; set; }
        public string MasTipoMascotaOtro { get; set; }
        public int MasCategoriaMascota { get; set; }
        public string MasImagen { get; set; }
        public string MasCartillaPdf { get; set; }
        public DateTime MasFechaAlta { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual TipoMascota TipoMascota { get; set; }
        public virtual CategoriaMascota CategoriaMascota { get; set; }
        public virtual ICollection<Reservacion> Reservacion { get; set; }

    }
}
