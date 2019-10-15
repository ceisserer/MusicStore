using MusicStore.Logic.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.Logic.Controllers
{
    abstract class MusicStoreController<E, I> : GenericController<E, I>
        where E : Entities.EntityObject, I, Contracts.ICopyable<I>, new()
        where I : Contracts.IIdentifiable
    {
        protected IMusicStoreContext MusicStoreContext => (IMusicStoreContext)Context;

        protected MusicStoreController(ContextObject context)
            : base(context)
        {
        }
        protected MusicStoreController(ControllerObject controller)
            : base(controller)
        {

        }
    }
}
