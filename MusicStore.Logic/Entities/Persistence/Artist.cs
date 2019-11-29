using System;
using System.Collections.Generic;
using MusicStore.Contracts;

namespace MusicStore.Logic.Entities.Persistence
{
    /// <summary>
    /// Implements the properties and methods of identifiable model.
    /// </summary>
    [Serializable]
    partial class Artist : IdentityObject, IArtist, ICopyable<IArtist>
    {
        public string Name { get; set; }

		public void CopyProperties(IArtist other)
		{
			if (other == null)
				throw new ArgumentNullException(nameof(other));

			Id = other.Id;
			Name = other.Name;
		}

		public IEnumerable<Album> Albums { get; set; }
	}
}