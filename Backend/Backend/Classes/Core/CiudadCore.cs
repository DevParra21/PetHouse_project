using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Classes.Core
{
    public class CiudadCore
    {
        private PetHouseDBContext dbContext;
        public CiudadCore(PetHouseDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Ciudad> GetAll()
        {
            try
            {
                List<Ciudad> ciudades = dbContext.Ciudad
                    .Include(x => x.Estado)
                    .Include(x => x.Estado.Pais)
                    .ToList();

                return ciudades;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Ciudad> Get(int id)
        {
            try
            {
                IQueryable<Ciudad> ciudad = dbContext.Ciudad
                    .Include(x => x.Estado)
                    .Include(x => x.Estado.Pais)
                    .Where(x => x.Id == id);
                return ciudad;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Ciudad> GetFromEstado(int estadoId)
        {
            try
            {
                List<Ciudad> ciudadesFromEstado = dbContext.Ciudad
                    .Where(x => x.EstadoId == estadoId)
                    .ToList();

                return ciudadesFromEstado;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
