using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Estado
    {
        public int EstPais { get; set; }
        public int EstId { get; set; }
        public string EstNombre { get; set; }

        public virtual Pais Pais { get; set; }
    }
}
