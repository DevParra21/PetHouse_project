using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Cliente
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contrasena { get; set; }
        public string Calle { get; set; }
        public string NumExt { get; set; }
        #nullable enable
        public string? NumInt { get; set; }
#nullable disable
        public int CiudadId { get; set; }

        public virtual Ciudad Ciudad{ get; set; }
        public int CodigoPostal { get; set; }
        #nullable enable
        public string? NumeroTelefonico { get; set; }
        #nullable disable
        public string NumeroCelular { get; set; }
        public bool Bloqueado { get; set; }
        public DateTime? FechaUltimoAcceso { get; set; }
        public DateTime  FechaAlta { get; set; }
        #nullable enable
        public DateTime? FechaUltimaActualizacion { get; set; }
        public DateTime? FechaBaja { get; set; }
        #nullable disable
        //public virtual ICollection<Mascota> Mascotas { get; set; }
        //public virtual ICollection<Reservacion> Reservaciones { get; set; }
        //public virtual ICollection<Hogar> Hogares { get; set; }
    }
}
