using System;
using MusicStore.Contracts;

namespace MusicStore.Logic.Entities
{
    /// <summary>
    /// Implements the properties and methods of identifiable model.
    /// </summary>
    [Serializable]
    partial class Album : EntityObject, IAlbum, ICopyable<Contracts.IAlbum>
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
    }
}
