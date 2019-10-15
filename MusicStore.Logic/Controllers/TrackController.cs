using MusicStore.Logic.Context;
using System.Collections.Generic;

namespace MusicStore.Logic.Controllers
{
	class TrackController : MusicStoreController<Entities.Track, Contracts.ITrack>
	{
        protected override IEnumerable<Entities.Track> Set => MusicStoreContext.Tracks;

		public TrackController(ContextObject context)
            : base(context)
        {
        }
        public TrackController(ControllerObject controller)
			: base(controller)
		{
		}
	}
}
