using System.Collections.Generic;

namespace MusicStore.Logic.DataContext.Csv
{
    internal class CsvMusicStoreContext : MusicStoreFileContext
    {
        public CsvMusicStoreContext()
        {
        }

        public override void Save()
        {
            SaveToCsv(Genres);
            SaveToCsv(Artists);
            SaveToCsv(Albums);
            SaveToCsv(Tracks);
        }

        protected override List<T> LoadEntities<T>()
        {
            return LoadFromCsv<T>();
        }
    }
}
