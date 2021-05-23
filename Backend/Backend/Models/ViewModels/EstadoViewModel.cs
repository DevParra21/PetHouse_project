using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.ViewModels
{
    public class EstadoVM
    {
        public int id { get; set; }
        public string nombre { get; set; }
    }
    public class EstadoViewModel
    {
    //    public int id { get; set; }
    //    public string nombre { get; set; }
        public List<CiudadViewModel> ciudades { get; set; }
    }

    public class CiudadViewModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
    }
}
