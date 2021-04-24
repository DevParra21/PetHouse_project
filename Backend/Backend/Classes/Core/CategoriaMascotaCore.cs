using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Classes.Core
{
    public class CategoriaMascotaCore
    {
        PetHouseDBContext dbContext;

        public CategoriaMascotaCore(PetHouseDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<CategoriaMascota> Get()
        {
            try
            {
                List<CategoriaMascota> categorias = dbContext.CategoriaMascota
                    .ToList();

                return categorias;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
