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
    public class TipoMultimediaController : ControllerBase
    {
        private PetHouseDBContext dbContext;

        public TipoMultimediaController(PetHouseDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<TipoMultimediaController>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                TipoMultimediaCore tipoMultimediaCore = new TipoMultimediaCore(dbContext);
                return Ok(tipoMultimediaCore.GetAll());
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET api/<TipoMultimediaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                TipoMultimediaCore tipoMultimediaCore = new TipoMultimediaCore(dbContext);
                return Ok(tipoMultimediaCore.Get(id));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
       
    }
}
