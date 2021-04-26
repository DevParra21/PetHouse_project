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
    public class HogarMultimediaController : ControllerBase
    {
        PetHouseDBContext dbContext;

        public HogarMultimediaController(PetHouseDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<HogarMultimediaController>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                HogarMultimediaCore hMultimediaCore = new HogarMultimediaCore(dbContext);
                return Ok(hMultimediaCore.GetAll());
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET api/<HogarMultimediaController>/5
        [HttpGet("{hogarId}")]
        public IActionResult GetMediaFromHogar(int hogarId)
        {
            try
            {
                if (!Funciones.Validadores.validaId(hogarId))
                    return BadRequest(Funciones.Constantes.BAD_REQUEST);

                HogarMultimediaCore hMultimediaCore = new HogarMultimediaCore(dbContext);
                List<HogarMultimedia> hMulti = hMultimediaCore.GetMediaFromHogar(hogarId);
                if (!Funciones.Validadores.validaLista(hMulti))
                    return NotFound(Funciones.Constantes.NOT_FOUND);

                return Ok(hMulti);

                
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET api/<HogarMultimediaController>/id
        [HttpGet("{hogarId}, {id}")]
        public IActionResult GetMedia(int hogarId, int id)
        {
            try
            {
                HogarMultimediaCore mediaCore = new HogarMultimediaCore(dbContext);
                return Ok(mediaCore.GetMedia(hogarId, id));
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            
        }

        // POST api/<HogarMultimediaController>
        [HttpPost]
        public IActionResult Create([FromBody] HogarMultimedia hogarMultimedia)
        {
            try
            {
                HogarMultimediaCore hMediaCore = new HogarMultimediaCore(dbContext);
                hMediaCore.Create(hogarMultimedia);
                return Ok("Multimedia cargada correctamente");
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
