using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
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
            new FanOutPut("en",20,40){Id = 1},
            new FanOutPut("to",21,41){Id = 2},
            new FanOutPut("tre",22,42){Id = 3},
            new FanOutPut("fire",23,43){Id = 4},
            new FanOutPut("fem",24,44){Id = 5}
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
            value.Id = _fanOutPuts.Last().Id +1;
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
