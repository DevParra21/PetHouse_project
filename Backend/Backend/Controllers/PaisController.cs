using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private PetHouseDBContext dbContext; 

        public PaisController(PetHouseDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<PaisController>
        [HttpGet]
        public IEnumerable<Pais> GetAll()
        {
            List<Pais> paises = dbContext.Pais.ToList();

            return paises;
        }

        //// GET api/<PaisController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<PaisController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<PaisController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PaisController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
