using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Classes.Core
{
    
    
    public class HogarMultimediaCore
    {
        private PetHouseDBContext dbContext;

        public HogarMultimediaCore(PetHouseDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<HogarMultimedia> GetAll()
        {
            try
            {
                List<HogarMultimedia> multimedia = dbContext.HogarMultimedia
                .Include(x => x.Hogar)
                .Include(x => x.TipoMultimedia)
                .ToList();

                return multimedia;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public List<HogarMultimedia> GetMediaFromHogar(int hogarId)
        {
            try
            {
                List<HogarMultimedia> multimedia = dbContext.HogarMultimedia
                    .Where(x => x.HogarId == hogarId)
                    .ToList();

                return multimedia;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<HogarMultimedia> GetMedia(int hogarId, int id)
        {
            try
            {
                IQueryable<HogarMultimedia> multimedia = dbContext.HogarMultimedia
                    .Include(x => x.Hogar)
                    .Include(x => x.Hogar.Cliente)
                    .Where(x => x.HogarId == hogarId && x.Id == id);
                return multimedia;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Validate(HogarMultimedia multimedia)
        {
            if (multimedia.HogarId <= 0 || string.IsNullOrEmpty(multimedia.Nombre) || multimedia.TipoMultimediaId <= 0 ||
                string.IsNullOrEmpty(multimedia.Extension))
                return false;
            return true;
        }

        public void Create(HogarMultimedia multimedia)
        {
            try
            {
                if(Validate(multimedia))
                {
                    dbContext.HogarMultimedia.Add(multimedia);
                    dbContext.SaveChanges();
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
