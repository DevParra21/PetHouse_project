using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class HogarMultimedia
    {
        public int HogarId { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int TipoMultimediaId { get; set; }
        public string Extension { get; set; }
        public virtual Hogar Hogar { get; set; }
        public virtual TipoMultimedia TipoMultimedia { get; set; }
    }
}
