using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class HistorialReservacion
    {
        public string HreReservacion { get; set; }
        public int HreId { get; set; }
        public int HreEtapa { get; set; }
        public DateTime HreFecha { get; set; }
        public string HreComentarios { get; set; }

        public virtual Reservacion Reservacion { get; set; }
    }
}
