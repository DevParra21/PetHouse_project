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
    public class ClienteController : ControllerBase
    {
        private PetHouseDBContext dbContext;

        public ClienteController(PetHouseDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //GET: apí/cliente/get - obtener los clientes activos DONE
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                ClienteCore clienteCore = new ClienteCore(dbContext);
                List<Cliente> clientesActivos = clienteCore.Get();
                if (!Funciones.Validadores.validaLista(clientesActivos))
                    return NotFound(Funciones.Constantes.NOT_ACTIVE_USERS);

                return Ok(clientesActivos);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }
        // GET: api/cliente/getall - obtener todos los clientes DONE
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                ClienteCore clienteCore = new ClienteCore(dbContext);

                List<Cliente> clientes = clienteCore.GetAll();
                if (!Funciones.Validadores.validaLista(clientes))
                    return NotFound(Funciones.Constantes.NOT_FOUND);

                return Ok(clienteCore.GetAll());
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public IActionResult GetFromId(int id)
        {
            try
            {
                if (!Funciones.Validadores.validaId(id))
                    return BadRequest(Funciones.Constantes.BAD_REQUEST);

                ClienteCore clienteCore = new ClienteCore(dbContext);

                IQueryable<Cliente> clienteFound = clienteCore.GetFromId(id);
                if (clienteFound.ToList().Count == 0)
                    return NotFound(Funciones.Constantes.NOT_FOUND);

                return Ok(clienteFound);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET api/<ClienteController>/email
        [HttpGet("{email}")]
        public IActionResult GetFromEmail(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                    return NotFound(Funciones.Constantes.BAD_REQUEST);

                ClienteCore clienteCore = new ClienteCore(dbContext);
                IQueryable<Cliente> clienteFound = clienteCore.GetFromEmail(email);
                if (clienteFound.ToList().Count == 0)
                    return NotFound(Funciones.Constantes.NOT_FOUND);

                return Ok(clienteFound);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // POST api/<ClienteController>
        [HttpPost]
        public IActionResult Create([FromBody]Cliente clienteParam)
        {
            try
            {
                ClienteCore clienteCore = new ClienteCore(dbContext);
                //Cliente cliente = new Cliente
                //{
                //    Nombre = "David",
                //    ApellidoPaterno = "Perez",
                //    ApellidoMaterno = "Parra",
                //    Calle = "Nombre de Calle",
                //    CodigoPostal = 67160,
                //    CiudadId = 5,
                //    Contrasena = "contrasenaSegura",
                //    CorreoElectronico = "davidperez@hotmail.com",
                //    NumeroCelular = "811273732",
                //    NumeroTelefonico = "811283732",
                //    NumExt = "10-A",
                //    NumInt = "3B",
                //    FechaNacimiento = DateTime.Now.AddYears(-20)
                //};

                clienteCore.Create(clienteParam);
                return Ok("Cliente registrado exitosamente.");
            }catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Cliente cliente, [FromRoute] int id)
        {
            try
            {
                ClienteCore clienteCore = new ClienteCore(dbContext);
                clienteCore.Update(cliente, id);
                return Ok("Tu información ha sido actualizada exitosamente.");
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public IActionResult Disable(int id)
        {
            try
            {
                ClienteCore clienteCore = new ClienteCore(dbContext);
                clienteCore.Disable(id);
                return Ok("Usuario Bloqueado.");
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public IActionResult Enable(int id)
        {
            try
            {
                ClienteCore clienteCore = new ClienteCore(dbContext);
                clienteCore.Enable(id);
                return Ok("Usuario habilitado.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
