using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Classes.Core
{
    public class MascotaCore
    {
        private PetHouseDBContext dbContext;

        public MascotaCore(PetHouseDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Mascota> GetAll()
        {
            try
            {
                List<Mascota> mascotas = dbContext.Mascota
                    .Include(x => x.Cliente)
                    .Include(x => x.TipoMascota)
                    .Include(x => x.CategoriaMascota)
                    .ToList();

                return mascotas;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Mascota> Get(int id)
        {
            try
            {
                IQueryable<Mascota> mascota = dbContext.Mascota
                    .Include(x => x.Cliente)
                    .Include(x => x.TipoMascota)
                    .Include(x => x.CategoriaMascota)
                    .Where(mascota => mascota.ID == id);
                return mascota;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Mascota> GetFromCliente(int clienteId)
        {
            try
            {
                List<Mascota> mascotasFromCliente = dbContext.Mascota
                    .Include(x => x.TipoMascota)
                    .Include(x => x.CategoriaMascota)
                    .Where(x => x.ClienteId == clienteId).ToList();


                return mascotasFromCliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Validate(Mascota mascota)
        {
            try
            {
                if (string.IsNullOrEmpty(mascota.Nombre) || mascota.ClienteId <= 0 ||
                    mascota.TipoMascotaId <= 0 || mascota.CategoriaMascotaId <= 0 ||
                    mascota.Edad <= 0)
                    return false;
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Create(Mascota mascota)
        {
            try
            {
                if(Validate(mascota))
                {
                    dbContext.Mascota.Add(mascota);
                    dbContext.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Mascota mascota, int id)
        {
            try
            {
                if (Validate(mascota))
                {
                    if (dbContext.Mascota.Any(x => x.ID == id))
                    {
                        mascota.ID = id;
                        dbContext.Mascota.Update(mascota);
                        dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
