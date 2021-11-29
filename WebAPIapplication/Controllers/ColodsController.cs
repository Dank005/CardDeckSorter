using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIapplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColodsController : ControllerBase
    {
        Database packs;

        public ColodsController(Database colods)
        {
            this.packs = colods;
        }

        //GET api/colods (get list of pack's name)
        [HttpGet]
        public IEnumerable<string> Get()
        {                   
            return from pack in packs
                   select pack.name;
        }

        //GET api/colods/name (get pack by name)
        [HttpGet("{name}")]
        public IEnumerable<List<string>> Get(string name)
        {
            return from pack in packs
                   where pack.name == name
                   select pack.cards;
        }

        //POST api/colods (create pack)
        //in Body (example) { "name": "colodName", "countCards": 52 }
        [HttpPost]
        public void Post([FromBody] Pack value)
        {
            packs.Add(new Pack(value.name, value.countCards));
        }

        //DELETE api/colods/name (delete pack)
        [HttpDelete("{name}")]
        public void Delete(string name)
        {
            packs.RemoveAll(colod => colod.name==name);
        }

        //PUT api/colods/name/mixer (mix pack)
        //mixer - "simple"
        [HttpPut("{name}/{mixer}")] 
        public void Mix(string name, string mixer)
        {
            if (mixer.Equals("simple"))
                foreach (var col in packs)
                {
                    if (col.name == name)
                    {
                        col.cards = col.cards.OrderBy(x => Guid.NewGuid().ToString()).ToList();
                        break;
                    }
                }
        }
    }
}
