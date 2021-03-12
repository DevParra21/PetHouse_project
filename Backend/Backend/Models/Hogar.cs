using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Hogar
    {
        public int HogId { get; set; }
        public int HogCliente { get; set; }
        public string HogDescripcion { get; set; }
        public double HogCostoPorNoche { get; set; }
        public int HogCapacidad { get; set; }
        public bool HogCuentaConMascotas { get; set; }
        public bool HogPublicado { get; set; }
        public bool HogDisponible { get; set; }
        public bool HogPausado { get; set; }
        public DateTime HogFechaAlta { get; set; }
        public DateTime HogFechaUltimaActualizacion { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<Reservacion> Reservacion { get; set; }
        public virtual ICollection<HogarMultimedia> HogarMultimedia { get; set; }
        public virtual ICollection<HogarTipoMascota> HogarTipoMascota { get; set; }

    }
}
