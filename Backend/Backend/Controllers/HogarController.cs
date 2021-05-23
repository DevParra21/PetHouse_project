using Backend.Classes.Core;
using Backend.Models;
using Backend.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
    public class HogarController : ControllerBase
    {
        private PetHouseDBContext dbContext;

        public HogarController(PetHouseDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //GET: api/<HogarController> - consulta todos los hogares de la base de datos.
        //[Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                HogarCore hogarCore = new HogarCore(dbContext);
                List<HogarViewModel> hogares = hogarCore.GetAll();

                if(!Funciones.Validadores.validaLista(hogares))
                    return NotFound(Funciones.Constantes.NOT_FOUND);

                return Ok(hogares);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        // GET: api/<HogarController> - consulta los hogares publicados (marcados como publicado en la base de datos.
        //[Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                HogarCore hogarCore = new HogarCore(dbContext);
                List<Hogar> hogaresPublicados = hogarCore.Get();

                if (hogaresPublicados.Count == 0)
                    return NotFound(Funciones.Constantes.GENERAL_NOT_FOUND);

                return Ok(hogaresPublicados);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        // GET api/<HogarController>/5
        //[Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (!Funciones.Validadores.validaId(id))
                    return BadRequest(Funciones.Constantes.BAD_REQUEST);

                HogarCore hogarCore = new HogarCore(dbContext);
                IQueryable<Hogar> hogarFound = hogarCore.Get(id);
                if (hogarFound.ToList().Count==0)
                    return NotFound(Funciones.Constantes.NOT_FOUND);

                return Ok(hogarFound);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        //[Authorize]
        [HttpGet("{clienteId}")]
        public IActionResult GetFromCliente(int clienteId)
        {
            try
            {
                if (!Funciones.Validadores.validaId(clienteId))
                    return BadRequest(Funciones.Constantes.BAD_REQUEST);

                HogarCore hogarCore = new HogarCore(dbContext);

                List<Hogar> hogaresFromCliente = hogarCore.GetFromCliente(clienteId);
                if (!Funciones.Validadores.validaLista(hogaresFromCliente))
                    return NotFound(Funciones.Constantes.NOT_FOUND);

                return Ok(hogaresFromCliente);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        // POST api/<HogarController>
        //[Authorize]
        [HttpPost]
        public IActionResult Create([FromBody] Hogar hogar)
        {
            try
            {
                if (!Funciones.Validadores.validaObjeto(hogar))
                    return BadRequest(Funciones.Constantes.BAD_REQUEST);
                HogarCore hogarCore = new HogarCore(dbContext);

                hogarCore.Create(hogar);
                return Ok("Felicidades! Tu hogar se ha registrado como Hotel para mascotas correctamente. 🐶💗");
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        // PUT api/<ClienteController>/5
        //[Authorize]
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Hogar mascota, [FromRoute] int id)
        {
            try
            {
                if (!Funciones.Validadores.validaObjeto(mascota) || !Funciones.Validadores.validaId(id))
                    return BadRequest(Funciones.Constantes.BAD_REQUEST);

                HogarCore hogarCore = new HogarCore(dbContext);
                hogarCore.Update(mascota, id);
                return Ok("La información de tu hogar ha sido actualizada exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // PUT api/<ClienteController>/5
        //[Authorize]
        [HttpPut("{id}")]
        public IActionResult Enable(int id)
        {
            try
            {
                if (!Funciones.Validadores.validaId(id))
                    return BadRequest(Funciones.Constantes.BAD_REQUEST);

                HogarCore hogarCore = new HogarCore(dbContext);
                hogarCore.Show(id);
                return Ok("Hogar se muestra y puede recibir reservaciones.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // DELETE api/<ClienteController>/5
        //[Authorize]
        [HttpDelete("{id}")]
        public IActionResult Disable(int id)
        {
            try
            {
                if (!Funciones.Validadores.validaId(id))
                    return BadRequest(Funciones.Constantes.BAD_REQUEST);
                HogarCore hogarCore = new HogarCore(dbContext);
                hogarCore.Hide(id);
                return Ok("Hogar se ocultó exitosamente. No podrá recibir reservaciones.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // DELETE api/<ClienteController>/5
        //[Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                HogarCore hogarCore = new HogarCore(dbContext);
                hogarCore.Delete(id);
                return Ok("Hogar eliminado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }


    }
}
