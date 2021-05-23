using Backend.Models;
using Backend.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Classes.Core
{
    public class HogarCore
    {
        private PetHouseDBContext dbContext;

        public HogarCore(PetHouseDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //GET Obtiene todas los hogares registrados.
        public List<HogarViewModel> GetAll()
        {
            try
            {

                var query = (from hogar in dbContext.Hogar
                             join cliente in dbContext.Cliente on hogar.ClienteId equals cliente.ID
                             select new
                             {
                                 id = hogar.Id,
                                 descripcion = hogar.Descripcion,
                                 costo = hogar.CostoPorNoche,
                                 idCliente = cliente.ID,
                                 cliente = $"{cliente.Nombre} {cliente.ApellidoPaterno} {cliente.ApellidoMaterno}",
                                   avenida = cliente.Calle,
                                 capacidad = hogar.Capacidad
                             }).ToList();

                //restructura
                List<HogarViewModel> resultado = new List<HogarViewModel>();
                foreach (var hogar in query.ToList())
                {
                    HogarViewModel elemento = new HogarViewModel()
                    {
                        id = hogar.id,
                        descripcion = hogar.descripcion,
                        costoPorNoche = hogar.costo,
                        capacidad = hogar.capacidad,
                        nombreDueno = hogar.cliente,
                        idDueno = hogar.idCliente
                    };

                    resultado.Add(elemento);
                }
            
                return resultado;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //GET Obtiene Hogares disponibles y publicados en la app.
        public List<Hogar> Get()
        {
            try
            {
                List<Hogar> hogares = dbContext.Hogar
                    .Include(x => x.Cliente)
                    .Where(x => x.Publicado == true)
                    .ToList();
                return hogares;
                    
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Hogar> Get(int id)
        {
            try
            {
               IQueryable<Hogar> hogar = dbContext.Hogar
                    .Include(x => x.Cliente)
                    .Where(x => x.Id == id);
                return hogar;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Hogar> GetFromCliente(int clienteId)
        {
            try
            {
                List<Hogar> hogares = dbContext.Hogar
                    .Where(x => x.ClienteId == clienteId)
                    .ToList();

                return hogares;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Create(Hogar hogar)
        {
            try
            {
                if (Validate(hogar))
                {
                    dbContext.Hogar.Add(hogar);
                    dbContext.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Hogar hogar, int id)
        {
            try
            {
                if (Validate(hogar))
                {
                    if (dbContext.Hogar.Any(x => x.Id == id))
                    {
                        hogar.Id = id;
                        dbContext.Hogar.Update(hogar);
                        dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Show(int id)
        {
            try
            {
                Hogar hogar = dbContext.Hogar.FirstOrDefault(x => x.Id == id && !x.Publicado);
                if (hogar != null)
                {
                    hogar.Publicado = true;
                    dbContext.Hogar.Update(hogar);
                    dbContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Hide(int id)
        {
            try
            {
                Hogar hogar = dbContext.Hogar.FirstOrDefault(x => x.Id == id && x.Publicado);
                if (hogar != null)
                {
                    hogar.Publicado = false;
                    dbContext.Hogar.Update(hogar);
                    dbContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                Reservacion reservacion = dbContext.Reservacion
                    .Include(x => x.Hogar)
                    .FirstOrDefault(x => x.Hogar.Id == id);

                if(reservacion == null)
                {
                    HogarMultimedia hogarMultimedia = dbContext.HogarMultimedia
                        .FirstOrDefault(x => x.Hogar.Id == id);
                    if (hogarMultimedia != null)
                        dbContext.HogarMultimedia.Remove(hogarMultimedia);
                    
                    Hogar hogar = dbContext.Hogar
                        .FirstOrDefault(x => x.Id == id);
                    dbContext.Remove(hogar);
                    
                }
                else
                    dbContext.Remove(reservacion);
            
                dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Validate(Hogar hogar)
        {
            if(hogar.Capacidad <=0 || hogar.ClienteId <= 0 || hogar.CostoPorNoche<=0 || string.IsNullOrEmpty(hogar.Descripcion))
                    return false;
            return true;
        }
    }
}
