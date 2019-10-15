using System.Collections.Generic;
using MusicStore.Logic.Context;

namespace MusicStore.Logic.Controllers
{
    internal class GenreController : MusicStoreController<Entities.Genre, Contracts.IGenre>
    {
        protected override IEnumerable<Entities.Genre> Set => MusicStoreContext.Genres;

		public GenreController(ContextObject context)
            : base(context)
        {
        }
        public GenreController(ControllerObject controller)
            : base(controller)
        {
        }
    }
}
