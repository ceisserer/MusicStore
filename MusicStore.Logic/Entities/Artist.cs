using System;
using MusicStore.Contracts;

namespace MusicStore.Logic.Entities
{
    /// <summary>
    /// Implements the properties and methods of identifiable model.
    /// </summary>
    [Serializable]
    partial class Artist : EntityObject, IArtist, ICopyable<Contracts.IArtist>
    {
        public string Name { get; set; }

		public void CopyProperties(IArtist other)
		{
			if (other == null)
				throw new ArgumentNullException(nameof(other));

			Id = other.Id;
			Name = other.Name;
		}
	}
}