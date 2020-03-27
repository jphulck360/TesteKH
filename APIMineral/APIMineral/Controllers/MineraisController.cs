using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIMineral.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace APIMineral.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MineraisController : ControllerBase
    {
        private IRepository repository;

        public MineraisController(IRepository rep) => repository = rep;

        [HttpGet]
        public IEnumerable<Mineral> Get() => repository.Minerais;

        [HttpGet("{id}")]
        public Mineral Get(int id) => repository[id];

        [HttpPost]
        public Mineral Post([FromBody] Mineral mine) => repository.AddMineral(new Mineral
        {
            MineralName = mine.MineralName,
            Description = mine.Description,
            Completed = mine.Completed,
            CreatedAt = mine.CreatedAt,
            UpdatedAt = mine.UpdatedAt
        });

        [HttpPut]
        public Mineral Put([FromForm] Mineral mine) => repository.UpdateMineral(mine);

        [HttpPatch("{id}")]
        public StatusCodeResult Patch(int id, [FromForm]JsonPatchDocument<Mineral> patch)
        {
            Mineral mine = Get(id);
            if (mine != null)
            {
                patch.ApplyTo(mine);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public void Delete(int id) => repository.DeleteMineral(id);
    }
}