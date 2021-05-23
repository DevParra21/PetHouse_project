using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.ViewModels
{
    public class HogarViewModel
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public double costoPorNoche { get; set; }
        public int capacidad { get; set; }

        public string nombreDueno { get; set; }
        public int idDueno { get; set; }

    }
}
