using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelLib.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IndeKlimaRestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FanOutPutsController : ControllerBase
    {
        private static List<FanOutPut> _fanOutPuts = new List<FanOutPut>()
        {
            new FanOutPut(1,"en",20,40),
            new FanOutPut(2,"to",21,41),
            new FanOutPut(3,"tre",22,42),
            new FanOutPut(4,"fire",23,43),
            new FanOutPut(5,"fem",24,44)
        };
        // GET: api/<FanOutPutsController>
        [HttpGet]
        public IEnumerable<FanOutPut> Get()
        {
            return _fanOutPuts;
        }

        // GET api/<FanOutPutsController>/5
        [HttpGet("{id}")]
        public FanOutPut Get(int id)
        {
            return _fanOutPuts.Find(i => i.Id == id);
        }

        // POST api/<FanOutPutsController>
        [HttpPost]
        public void Post([FromBody] FanOutPut value)
        {
            value.Id = _fanOutPuts.Count + 2;
            _fanOutPuts.Add(value);
        }

        // PUT api/<FanOutPutsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] FanOutPut value)
        {
            FanOutPut outPut = Get(id);
            if (outPut != null)
            {
                outPut.Temp = value.Temp;
                outPut.Fugt = value.Fugt;
                outPut.Navn = value.Navn;
            }
        }

        // DELETE api/<FanOutPutsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            FanOutPut outPut = Get(id);
            _fanOutPuts.Remove(outPut);
        }
    }
}
