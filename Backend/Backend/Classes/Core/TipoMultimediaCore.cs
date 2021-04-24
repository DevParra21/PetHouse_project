using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Classes.Core
{
    public class TipoMultimediaCore
    {
        private PetHouseDBContext dbContext;

        public TipoMultimediaCore(PetHouseDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<TipoMultimedia> GetAll()
        {
            try
            {
                List<TipoMultimedia> tipos = dbContext.TipoMultimedia
                    .ToList();
                return tipos;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<TipoMultimedia> Get(int id)
        {
            try
            {
                IQueryable<TipoMultimedia> tipo = dbContext.TipoMultimedia
                    .Where(x => x.ID == id);
                return tipo;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
