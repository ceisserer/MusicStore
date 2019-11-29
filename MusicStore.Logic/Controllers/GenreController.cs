using System.Collections.Generic;
using MusicStore.Logic.DataContext;

namespace MusicStore.Logic.Controllers
{
    internal class GenreController : MusicStoreController<Entities.Persistence.Genre, Contracts.IGenre>
    {
        protected override IEnumerable<Entities.Persistence.Genre> Set => MusicStoreContext.Genres;

		public GenreController(IContext context)
            : base(context)
        {
        }
        public GenreController(ControllerObject controller)
            : base(controller)
        {
        }
    }
}
