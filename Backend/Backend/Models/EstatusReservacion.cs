using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class EstatusReservacion
    {
        public int EreId { get; set; }
        public string EreNombre { get; set; }

        public virtual ICollection<Reservacion> Reservacion { get; set; }
    }
}
