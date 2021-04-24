using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Classes.Core
{
    public class ReservacionCore
    {
        private PetHouseDBContext dbContext;

        public ReservacionCore(PetHouseDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Reservacion> GetAll()
        {
            try
            {
                List<Reservacion> reservaciones = dbContext.Reservacion
                    .Include(x => x.Cliente)
                    .Include(x => x.Hogar)
                    .Include(x => x.EstatusReservacion)
                    .ToList();
                return reservaciones;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Reservacion> Get(int id)
        {
            try
            {
                IQueryable<Reservacion> reservacion = dbContext.Reservacion
                    .Include(x => x.EstatusReservacion)
                    .Include(x => x.Cliente)
                    .Include(x => x.Hogar)
                    .Include(x => x.Hogar.Cliente)
                    .Where(x => x.Id == id);
                return reservacion;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Reservacion> GetFromCliente(int clienteId)
        {
            try
            {
                List<Reservacion> reservacionesFromCliente = dbContext.Reservacion
                    .Include(x => x.EstatusReservacion)
                    .Include(x => x.Cliente)
                    .Include(x => x.Hogar)
                    .Include(x => x.Hogar.Cliente)
                    .Where(x => x.ClienteId == clienteId)
                    .ToList();
                return reservacionesFromCliente;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Reservacion> GetFromHogar(int hogarId)
        {
            try
            {
                List<Reservacion> reservacionesFromHogar = dbContext.Reservacion
                    .Include(x => x.EstatusReservacion)
                    .Include(x => x.Cliente)
                    .Include(x => x.Hogar)
                    .Include(x => x.Hogar.Cliente)
                    .Where(x => x.HogarId == hogarId)
                    .ToList();
                return reservacionesFromHogar;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Reservacion> GetFromHogarCliente(int clienteId)
        {
            try
            {
                List<Reservacion> reservacionesFromHogarCliente = dbContext.Reservacion
                    .Include(x => x.EstatusReservacion)
                    .Include(x => x.Cliente)
                    .Include(x => x.Hogar)
                    .Include(x => x.Hogar.Cliente)
                    .Where(x => x.Hogar.ClienteId == clienteId)
                    .ToList();
                return reservacionesFromHogarCliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Create(Reservacion reservacion)
        {
            try
            {
                if(Validate(reservacion))
                {
                    dbContext.Reservacion.Add(reservacion);
                    dbContext.SaveChanges();

                    
                    //foreach(Mascota mascota in reservacion.ReservacionDetalles)
                    //{
                    //    ReservacionDetalle reservacionDetalle = new ReservacionDetalle();
                    //    reservacionDetalle.ReservacionId = reservacion.Id;
                    //    reservacionDetalle.MascotaId = mascota.ID;
                    //    ReservacionDetalleCore rCore = new ReservacionDetalleCore(dbContext);
                    //    rCore.Create(reservacionDetalle);
                    //}
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private bool Validate(Reservacion reservacion)
        {
            if (reservacion.ClienteId <= 0 || reservacion.ClienteId.Equals(null) || string.IsNullOrEmpty(reservacion.FechaEntrada.ToString()) ||
                string.IsNullOrEmpty(reservacion.FechaSalida.ToString()) || reservacion.HogarId.Equals(null) || reservacion.HogarId <= 0)
                return false;
            return true;
        }



    }
}
