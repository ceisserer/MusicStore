using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Contracts;
using MusicStore.Transfer.Models;

namespace MusicStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : GenericController<ITrack, Track>
    {
        // GET: api/Track
        [HttpGet]
        public IEnumerable<ITrack> Get()
        {
            return GetAll();
        }

        // GET: api/Track/5
        [HttpGet("{id}")]
        public ITrack Get(int id)
        {
            return GetById(id);
        }

        // POST: api/Track
        [HttpPost]
        public void Post([FromBody] Track model)
        {
            Insert(model);
        }

        // PUT: api/Track/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Track model)
        {
            Update(id, model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DeleteById(id);
        }
    }
}
