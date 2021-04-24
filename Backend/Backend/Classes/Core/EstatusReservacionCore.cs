using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Classes.Core
{
    public class EstatusReservacionCore
    {
        private PetHouseDBContext dbContext;

        public EstatusReservacionCore(PetHouseDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<EstatusReservacion> Get()
        {
            try
            {
                List<EstatusReservacion> estatus = dbContext.EstatusReservacion
                    .ToList();
                return estatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<EstatusReservacion> Get(int id)
        {
            try
            {
                IQueryable<EstatusReservacion> estatus = dbContext.EstatusReservacion
                    .Where(x => x.Id == id);
                return estatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
