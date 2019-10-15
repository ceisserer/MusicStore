using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.Logic.Entities
{
	[Serializable]
	abstract partial class EntityObject : IdentityObject
	{
		internal EntityState State { get; set; } = EntityState.Unchanged;
	}
}
