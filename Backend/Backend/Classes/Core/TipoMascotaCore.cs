using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Classes.Core
{
    public class TipoMascotaCore
    {
        private PetHouseDBContext dbContext;

        public TipoMascotaCore(PetHouseDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<TipoMascota> Get()
        {
            try
            {
                List<TipoMascota> tipos = dbContext.TipoMascota
                    .ToList();

                return tipos;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
