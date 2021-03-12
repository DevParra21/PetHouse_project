using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Ciudad
    {
        public int CiuPais { get; set;}
        public int CiuEstado { get; set; }
        public int CiuId { get; set; }
        public string CiuNombre { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual Pais Pais { get; set; }
    }
}
