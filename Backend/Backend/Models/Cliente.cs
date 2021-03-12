using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Cliente
    {
        public long CliId { get; set; }
        public string CliNombre { get; set; }
        public string CliApellidoPaterno { get; set; }
        public string CliApellidoMaterno { get; set; }
        public DateTime CliFechaNacimiento { get; set; }
        public string CliCorreoElectronico { get; set; }
        public string CliContrasena { get; set; }
        #nullable enable
        public string? CliNumeroTelefonico { get; set; }
        #nullable disable
        public string CliNumeroCelular { get; set; }

        public bool CliBloqueado { get; set; }

        public DateTime? CliFechaUltimoAcceso { get; set; }

        public DateTime  CliFechaAlta { get; set; }
        public DateTime? CliFechaUltimaActualizacion { get; set; }

        public DateTime? CliFechaBaja { get; set; }
        public virtual ICollection<Mascota> Mascota { get; set; }
        public virtual ICollection<Reservacion> Reservacion { get; set; }
        public virtual ICollection<Hogar> Hogar { get; set; }


    }
}
