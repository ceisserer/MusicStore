﻿using MusicStore.Logic.DataContext;
using System.Collections.Generic;

namespace MusicStore.Logic.Controllers.Persistence
{
    class ArtistController : MusicStoreController<Entities.Persistence.Artist, Contracts.IArtist>
	{
        protected override IEnumerable<Entities.Persistence.Artist> Set => MusicStoreContext.Artists;

		public ArtistController(IContext context)
            : base(context)
        {
        }
        public ArtistController(ControllerObject controller)
			: base(controller)
		{
		}
	}
}