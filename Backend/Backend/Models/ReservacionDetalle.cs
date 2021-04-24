using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class ReservacionDetalle
    {
        public int ReservacionId { get; set; }
        public int MascotaId { get; set; }
        public virtual Reservacion Reservacion { get; set; }
        public virtual Mascota Mascota { get; set; }
    }
}
