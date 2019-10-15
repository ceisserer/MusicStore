using System.Collections.Generic;
using MusicStore.Logic.Entities;

namespace MusicStore.Logic.Context
{
    internal interface IMusicStoreContext
    {
        IEnumerable<Genre> Genres { get; }
        IEnumerable<Artist> Artists { get; }
        IEnumerable<Album> Albums { get; }
        IEnumerable<Track> Tracks { get; }
    }
}