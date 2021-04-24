using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Reservacion
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int HogarId { get; set; }
        public int EstatusReservacionId { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public double MontoTotal { get; set; }
        public bool RecibeAlimento { get; set; }
        #nullable enable
        public string? DescripcionAlimento { get; set; }
        public  string? ComentariosCliente { get; set; }
        public DateTime? FechaAlta { get; set; }
        #nullable disable
        public virtual Cliente Cliente { get; set; }
        public virtual Hogar Hogar { get; set; }
        public virtual EstatusReservacion EstatusReservacion { get; set; }

        //public virtual ICollection<ReservacionDetalle> ReservacionDetalles { get; set; }
        //public virtual ICollection<HistorialReservacion> HistorialReservacion  { get; set; }
    }
}
