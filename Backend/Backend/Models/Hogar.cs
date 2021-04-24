using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Hogar
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Descripcion { get; set; }
        public double CostoPorNoche { get; set; }
        public int Capacidad { get; set; }
        public bool CuentaConMascotas { get; set; }
        public bool Publicado { get; set; }
        public bool Disponible { get; set; }
        public bool Pausado { get; set; }
        #nullable enable
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaUltimaActualizacion { get; set; }
        #nullable disable
        public virtual Cliente Cliente { get; set; }
        //public virtual ICollection<Reservacion> Reservacion { get; set; }
        //public virtual ICollection<HogarMultimedia> HogarMultimedia { get; set; }
        //public virtual ICollection<HogarTipoMascota> HogarTipoMascota { get; set; }

    }
}
