using Backend.Classes.Core;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {
        private PetHouseDBContext dbContext;

        public CiudadController(PetHouseDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<CiudadController>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                CiudadCore ciudadCore = new CiudadCore(dbContext);
                List<Ciudad> ciudades = ciudadCore.GetAll();

                if (!Funciones.Validadores.validaLista(ciudades))
                    return NotFound(Funciones.Constantes.GENERAL_NOT_FOUND);

                return Ok(ciudades);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET api/<CiudadController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (!Funciones.Validadores.validaId(id))
                    return BadRequest(Funciones.Constantes.BAD_REQUEST);

                CiudadCore ciudadCore = new CiudadCore(dbContext);
               IQueryable<Ciudad> ciudad = ciudadCore.Get(id);
                if (ciudad.ToList().Count==0)
                    return NotFound(Funciones.Constantes.NOT_FOUND);

                return Ok(ciudad);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET api/<CiudadController>/estadoId
        [HttpGet("{estadoId}")]
        public IActionResult GetFromEstado(int estadoId)
        {
            try
            {
                if (!Funciones.Validadores.validaId(estadoId))
                    return BadRequest(Funciones.Constantes.BAD_REQUEST);

                CiudadCore ciudadCore = new CiudadCore(dbContext);

                List<Ciudad> ciudades = ciudadCore.GetFromEstado(estadoId);
                if (!Funciones.Validadores.validaLista(ciudades))
                    return NotFound(Funciones.Constantes.NOT_FOUND);

                return Ok(ciudades);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
