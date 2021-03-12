using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Reservacion
    {
        public string ResId { get; set; }
        public int ResCliente { get; set; }
        public int ResHogar { get; set; }
        public int ResMascota { get; set; }
        public int ResEstatus { get; set; }
        public DateTime ResFechaEntrada { get; set; }
        public DateTime ResFechaSalida { get; set; }
        public double ResMontoTotal { get; set; }
        public bool ResRecibeAlimento { get; set; }
        public string ResDescripcionAlimento { get; set; }
        public  string ResComentariosCliente { get; set; }
        public DateTime ResFechaAlta { get; set; }



        public virtual Cliente Cliente { get; set; }
        public virtual Hogar Hogar { get; set; }
        public virtual Mascota Mascota { get; set; }
        public virtual EstatusReservacion EstatusReservacion { get; set; }

        public virtual ICollection<HistorialReservacion> HistorialReservacion  { get; set; }
    }
}
