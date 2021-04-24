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
    public class EstadoController : ControllerBase
    {
        private PetHouseDBContext dbContext;

        public EstadoController(PetHouseDBContext dBContext)
        {
            this.dbContext = dBContext;
        }
        // GET: api/<EstadoController>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                EstadoCore estadoCore = new EstadoCore(dbContext);
                List<Estado> estados = estadoCore.GetAll();
                if (!Funciones.Validadores.validaLista(estados))
                    return NotFound(Funciones.Constantes.NOT_FOUND);
                return Ok(estados);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            
        }

        // GET api/<EstadoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (!Funciones.Validadores.validaId(id))
                    return BadRequest(Funciones.Constantes.BAD_REQUEST);

                EstadoCore estadoCore = new EstadoCore(dbContext);
                IQueryable<Estado> estado = estadoCore.Get(id);
                if (!Funciones.Validadores.validaObjeto(estado))
                    return NotFound(Funciones.Constantes.NOT_FOUND);

                return Ok(estado);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
