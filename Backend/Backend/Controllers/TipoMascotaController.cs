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
    public class TipoMascotaController : ControllerBase
    {
        private PetHouseDBContext dbContext;

        public TipoMascotaController(PetHouseDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<TipoMascotaController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                TipoMascotaCore tipoCore = new TipoMascotaCore(dbContext);
                return Ok(tipoCore.Get());
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

    }
}
