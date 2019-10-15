using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Contracts;
using MusicStore.Transfer.Models;

namespace MusicStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : GenericController<IAlbum, Album>
    {
        // GET: api/Album
        [HttpGet]
        public IEnumerable<IAlbum> Get()
        {
            return GetAll();
        }

        // GET: api/Album/5
        [HttpGet("{id}")]
        public IAlbum Get(int id)
        {
            return GetById(id);
        }

        // POST: api/Album
        [HttpPost]
        public void Post([FromBody] Album model)
        {
            Insert(model);
        }

        // PUT: api/Album/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Album model)
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
