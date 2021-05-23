using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Ciudad
    {
        public int Id { get; set; }
        public int EstadoId { get; set; }
        public string Nombre { get; set; }
        public virtual Estado Estado { get; set; }
        
    }
}
