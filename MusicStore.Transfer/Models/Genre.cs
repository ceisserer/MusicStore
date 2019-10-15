using System;
using MusicStore.Contracts;

namespace MusicStore.Transfer.Models
{
    /// <summary>
    /// Implements the properties and methods of identifiable model.
    /// </summary>
    public class Genre : TransferObject, IGenre, ICopyable<IGenre>
    {
		public Genre()
		{

		}
        public string Name { get; set; }

		public void CopyProperties(IGenre other)
		{
			if (other == null)
				throw new ArgumentNullException(nameof(other));

			Id = other.Id;
			Name = other.Name;
		}
	}
}
