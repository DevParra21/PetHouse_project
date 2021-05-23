using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class User : IdentityUser
    {
        //Agregar los demás campos de Cliente
        public string Name { get; set; }
        public string PLastName { get; set; }
        public string MLastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Street { get; set; }
        public string NoExt { get; set; }
        #nullable enable
        public string? NoInt { get; set; }
        #nullable disable
        public string PostalCode { get; set; }
        public int CiudadId { get; set; }
        
        public virtual Ciudad Ciudad { get; set; }
        #nullable enable
        public DateTime? DateAdded { get; set; }
        public bool? Blocked { get; set; }
        #nullable disable
         

    }
}
