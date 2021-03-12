using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class HogarMultimedia
    {
        public int HmuHogar { get; set; }
        public int HmuId { get; set; }
        public string HmuNombre { get; set; }
        public int HmuTipo { get; set; }
        public string HmuExtension { get; set; }

        public virtual Hogar Hogar { get; set; }
    }
}
