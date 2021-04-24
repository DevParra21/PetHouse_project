using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Classes.Core
{
    public class EstadoCore
    {
        private PetHouseDBContext dbContext;
        public EstadoCore(PetHouseDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Estado> GetAll()
        {
            try
            {
                List<Estado> estados = dbContext.Estado
                    .Include(x => x.Pais)
                    .ToList();

                return estados;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Estado> Get(int id)
        {
            try
            {
                IQueryable<Estado> estado = dbContext.Estado
                    .Include(x => x.Pais)
                    .Where(x => x.ID == id);

                return estado;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
