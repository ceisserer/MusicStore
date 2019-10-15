using System.Linq;
using System.Collections.Generic;

namespace MusicStore.Logic.Context
{
    internal class SerMusicStoreContext : MusicStoreFileContext
    {
        public SerMusicStoreContext()
        {
        }

        public override void Save()
        {
            SaveToSer(Genres);
            SaveToSer(Artists);
            SaveToSer(Albums);
            SaveToSer(Tracks);
        }

        protected override List<T> LoadEntities<T>()
        {
            return LoadFromSer<T>();
        }
    }
}
