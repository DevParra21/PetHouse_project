using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.ViewModels
{
    public class CreateUserModel
    {
        public string Name { get; set; }
        public string PLastName { get; set; }
        public string MLastName { get; set; }

        public DateTime BirthDate { get; set; }
        public string  Street{ get; set; }
        public string NoExt { get; set; }
        public string NoInt { get; set; }
        public string PostalCode { get; set; }
        public int CiudadId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
