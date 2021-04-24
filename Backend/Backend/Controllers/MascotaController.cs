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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        private PetHouseDBContext dbContext;

        public MascotaController(PetHouseDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<MascotaController>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                MascotaCore mascotaCore = new MascotaCore(dbContext);
                List<Mascota> mascotas = mascotaCore.GetAll();
                if (!Funciones.Validadores.validaLista(mascotas))
                    return NotFound(Funciones.Constantes.GENERAL_NOT_FOUND);

                return Ok(mascotas);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            
        }

        // GET api/<MascotaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (!Funciones.Validadores.validaId(id))
                    return BadRequest(Funciones.Constantes.BAD_REQUEST);
                MascotaCore mascotaCore = new MascotaCore(dbContext);
                return Ok(mascotaCore.Get(id));
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET api/<MascotaController>/cliente
        [HttpGet("{clienteId}")]
        public IActionResult GetFromCliente(int clienteId)
        {
            try
            {
                if (!Funciones.Validadores.validaId(clienteId))
                    return BadRequest(Funciones.Constantes.BAD_REQUEST);

                MascotaCore mascotaCore = new MascotaCore(dbContext);

                List<Mascota> mascotas = mascotaCore.GetFromCliente(clienteId);

                if (!Funciones.Validadores.validaLista(mascotas))
                    return NotFound(Funciones.Constantes.NOT_FOUND);

                return Ok(mascotas);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // POST api/<MascotaController>
        [HttpPost]
        public IActionResult Create([FromBody] Mascota mascotaParam)
        {
            try
            {
                MascotaCore mascotaCore = new MascotaCore(dbContext);
                mascotaCore.Create(mascotaParam);
                return Ok("Tu mascota " + mascotaParam.Nombre + " ha sido registrada con éxito.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Mascota mascota, [FromRoute] int id)
        {
            try
            {
                MascotaCore mascotaCore = new MascotaCore(dbContext);
                mascotaCore.Update(mascota, id);
                return Ok("La información de tu mascota ha sido actualizada exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
