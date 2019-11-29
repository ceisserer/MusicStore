using System;
using System.Collections.Generic;
using MusicStore.Contracts;

namespace MusicStore.Logic.Entities.Persistence
{
    /// <summary>
    /// Implements the properties and methods of identifiable model.
    /// </summary>
    [Serializable]
    partial class Album : IdentityObject, IAlbum, ICopyable<IAlbum>
    {
        public int ArtistId { get; set; }
        public string Title { get; set; }

        public void CopyProperties(IAlbum other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            Id = other.Id;
            ArtistId = other.ArtistId;
            Title = other.Title;
        }
		public Artist Artist { get; set; }
		public IEnumerable<Track> Tracks { get; set; }
    }
}
