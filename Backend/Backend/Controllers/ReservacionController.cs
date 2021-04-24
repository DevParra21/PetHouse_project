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
    public class ReservacionController : ControllerBase
    {
        private PetHouseDBContext dbContext;

        public ReservacionController(PetHouseDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<ReservacionController>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                ReservacionCore reservacionCore = new ReservacionCore(dbContext);
                return Ok(reservacionCore.GetAll());
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET api/<ReservacionController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                ReservacionCore reservacionCore = new ReservacionCore(dbContext);
                return Ok(reservacionCore.Get(id));
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET api/<ReservacionController>/5
        [HttpGet("{clienteId}")]
        public IActionResult GetFromCliente(int clienteId)
        {
            try
            {
                ReservacionCore reservacionCore = new ReservacionCore(dbContext);
                return Ok(reservacionCore.GetFromCliente(clienteId));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET api/<ReservacionController>/5
        [HttpGet("{hogarId}")]
        public IActionResult GetFromHogar(int hogarId)
        {
            try
            {
                ReservacionCore reservacionCore = new ReservacionCore(dbContext);
                return Ok(reservacionCore.GetFromHogar(hogarId));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET api/<ReservacionController>/5
        [HttpGet("{hogarClienteId}")]
        public IActionResult GetFromHogarCliente(int hogarClienteId)
        {
            try
            {
                ReservacionCore reservacionCore = new ReservacionCore(dbContext);
                return Ok(reservacionCore.GetFromHogarCliente(hogarClienteId));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // POST api/<ReservacionController>
        [HttpPost]
        public IActionResult Create([FromBody] Reservacion reservacion)
        {
            try
            {
                ReservacionCore reservacionCore = new ReservacionCore(dbContext);
                reservacionCore.Create(reservacion);
                return Ok("Reservación creada exitosamente.");
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
