using Backend.Models;
using Backend.Models.ViewModels;
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

        public List<EstadoVM> GetAll()
        {
            try
            {
                //consulta
                var estados = (from Estado in dbContext.Estado
                                          select new
                                          {
                                              id = Estado.ID,
                                              nombre = Estado.Nombre
                                          }).ToList();
                
                //Restructura
                List<EstadoVM> resultado = new List<EstadoVM>();
                foreach(var estado in estados.ToList())
                {
                    EstadoVM result = new EstadoVM()
                    {
                        id = estado.id,
                        nombre = estado.nombre
                    };

                    resultado.Add(result);
                }

                return resultado;
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

        public EstadoViewModel GetCiudades(int idEstado)
        {
            try
            {
                //Consultar
                var query = (from Estado in dbContext.Estado
                             join Ciudad in dbContext.Ciudad on Estado.ID equals Ciudad.EstadoId
                             where Estado.ID == idEstado
                             select new
                             {
                                 estadoId = Estado.ID,
                                 estadoNombre = Estado.Nombre,
                                 ciudadId = Ciudad.Id,
                                 ciudadNombre = Ciudad.Nombre
                             }).ToList();

                //Restructurar
                EstadoViewModel restructure = query.GroupBy(x => (x.estadoId, x.estadoNombre)).Select(y => new EstadoViewModel
                {
                    //nombre = y.Key.estadoNombre,
                    ciudades = y.Select(z => new CiudadViewModel
                    {
                        id = z.ciudadId,
                        nombre = z.ciudadNombre
                    }).ToList()
                }).First();

                return restructure;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
