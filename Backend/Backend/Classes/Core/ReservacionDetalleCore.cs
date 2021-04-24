using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Classes.Core
{
    public class ReservacionDetalleCore
    {
        private PetHouseDBContext dbContext;

        public ReservacionDetalleCore(PetHouseDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<ReservacionDetalle> GetAll()
        {
            try
            {
                List<ReservacionDetalle> rDetalle = dbContext.ReservacionDetalle
                .Include(x => x.Reservacion)
                .Include(x => x.Mascota)
                .ToList();

                return rDetalle;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public List<ReservacionDetalle> GetFromReservacion(int reservacionId)
        {
            try
            {
                List<ReservacionDetalle> rDetalle = dbContext.ReservacionDetalle
                    .Include(x => x.Reservacion)
                    .Include(x => x.Mascota)
                    .Where(x => x.ReservacionId == reservacionId)
                    .ToList();

                return rDetalle;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Create(ReservacionDetalle rDetalle)
        {
            try
            {
                dbContext.ReservacionDetalle.Add(rDetalle);
                dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
