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
    public class CategoriaMascotaController : ControllerBase
    {
        private PetHouseDBContext dbContext;

        public CategoriaMascotaController(PetHouseDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<CategoriaMascotaController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                CategoriaMascotaCore categoriaCore = new CategoriaMascotaCore(dbContext);

                List<CategoriaMascota> categorias = categoriaCore.Get();
                if (!Funciones.Validadores.validaLista(categorias))
                    return NotFound(Funciones.Constantes.GENERAL_NOT_FOUND);

                return Ok(categorias);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
