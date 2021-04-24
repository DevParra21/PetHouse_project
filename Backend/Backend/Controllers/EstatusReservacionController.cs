using Backend.Classes.Core;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/estatusreservacion")]
    [ApiController]
    public class EstatusReservacionController : ControllerBase
    {
        private PetHouseDBContext dbContext;

        public EstatusReservacionController(PetHouseDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<EstatusReservacionController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                EstatusReservacionCore estatusCore = new EstatusReservacionCore(dbContext);
                List<EstatusReservacion> estatus = estatusCore.Get();
                if (!Funciones.Validadores.validaLista(estatus))
                    return NotFound(Funciones.Constantes.GENERAL_NOT_FOUND);

                return Ok(estatus);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET api/<EstatusReservacionController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (!Funciones.Validadores.validaId(id))
                    return BadRequest(Funciones.Constantes.BAD_REQUEST);

                EstatusReservacionCore estatusCore = new EstatusReservacionCore(dbContext);
                IQueryable<EstatusReservacion> estatus = estatusCore.Get(id);
                if (!Funciones.Validadores.validaObjeto(estatus))
                    return NotFound(Funciones.Constantes.NOT_FOUND);

                return Ok(estatus);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
