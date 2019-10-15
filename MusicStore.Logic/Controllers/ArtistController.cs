using MusicStore.Logic.Context;
using System.Collections.Generic;

namespace MusicStore.Logic.Controllers
{
	class ArtistController : MusicStoreController<Entities.Artist, Contracts.IArtist>
	{
        protected override IEnumerable<Entities.Artist> Set => MusicStoreContext.Artists;

		public ArtistController(ContextObject context)
            : base(context)
        {
        }
        public ArtistController(ControllerObject controller)
			: base(controller)
		{
		}
	}
}
