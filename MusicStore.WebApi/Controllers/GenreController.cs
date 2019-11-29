using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Entity = MusicStore.Contracts.IGenre;
using Model = MusicStore.Transfer.Models.Genre;
using Factory = MusicStore.Logic.Factory;

namespace MusicStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        // GET: api/Genre
        [HttpGet]
        public IEnumerable<Entity> Get()
        {
            using (var ctrl = Factory.CreateController<Entity>())
            {
                return ctrl.GetAll();
            }
        }

        // GET: api/Genre/5
        [HttpGet("{id}")]
        public Entity Get(int id)
        {
            using (var ctrl = Factory.CreateController<Entity>())
            {
                return ctrl.GetById(id);
            }
        }

        // POST: api/Genre
        [HttpPost]
        public void Post([FromBody] Model model)
        {
            using (var ctrl = Factory.CreateController<Entity>())
            {
                ctrl.Insert(model);
                ctrl.SaveChanges();
            }
        }

        // PUT: api/Genre/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Model model)
        {
            using (var ctrl = Factory.CreateController<Entity>())
            {
                ctrl.Update(model);
                ctrl.SaveChanges();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var ctrl = Factory.CreateController<Entity>())
            {
                ctrl.Delete(id);
                ctrl.SaveChanges();
            }
        }
    }
}
