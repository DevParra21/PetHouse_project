using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.ViewModels
{
    public class ClienteVM
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string correoElectronico { get; set; }
        public int ciudadId { get; set; }
        public string ciudadNombre { get; set; }
        public int estadoId { get; set; }
        public string estadoNombre { get; set; }
        public string calle { get; set; }
        public string noExterior { get; set; }
        public string noInterior { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public bool bloqueado { get; set; }
        public int codigoPostal { get; set; }

            //id = Cliente.ID,
            //nombre = Cliente.Nombre,
            //apellidoPaterno = Cliente.ApellidoPaterno,
            //apellidoMaterno = Cliente.ApellidoMaterno,
            //correoElectronico = Cliente.CorreoElectronico,
            //estadoId = Ciudad.EstadoId,
            //estado = Estado.Nombre,
            //ciudadId = Cliente.CiudadId,
            //ciudad = Ciudad.Nombre
    }
    public class ClienteViewModel
    {
        public string nombreCompleto { get; set; }
        public List<MascotaViewModel> mascotas { get; set; }
    }

    public class MascotaViewModel
    {
        public string nombre { get; set; }
        public string tipo { get; set; }
        public string tamano { get; set; }
    }
}
