using MusicStore.Logic.Context;
using System.Collections.Generic;

namespace MusicStore.Logic.Controllers
{
	class AlbumController : MusicStoreController<Entities.Album, Contracts.IAlbum>
	{
        protected override IEnumerable<Entities.Album> Set => MusicStoreContext.Albums;

		public AlbumController(ContextObject context)
            : base(context)
        {
        }
        public AlbumController(ControllerObject controller)
			: base(controller)
		{
		}
	}
}
