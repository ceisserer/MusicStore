using MusicStore.Logic.DataContext;
using System.Collections.Generic;

namespace MusicStore.Logic.Controllers
{
	class AlbumController : MusicStoreController<Entities.Persistence.Album, Contracts.IAlbum>
	{
        protected override IEnumerable<Entities.Persistence.Album> Set => MusicStoreContext.Albums;

		public AlbumController(IContext context)
            : base(context)
        {
        }
        public AlbumController(ControllerObject controller)
			: base(controller)
		{
		}
	}
}
