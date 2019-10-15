using System;
using MusicStore.Contracts;

namespace MusicStore.Transfer.Models
{
    /// <summary>
    /// Implements the properties and methods of identifiable model.
    /// </summary>
    public partial class Artist : TransferObject, IArtist, ICopyable<IArtist>
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