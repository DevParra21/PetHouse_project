using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class HogarTipoMascota
    {
        public int HtmHogar { get; set; }
        public int HtmTipoMascota { get; set; }

        public virtual Hogar Hogar { get; set; }
        public virtual TipoMascota TipoMascota { get; set; }
    }
}
