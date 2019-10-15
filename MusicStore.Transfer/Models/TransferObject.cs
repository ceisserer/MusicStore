using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.Transfer.Models
{
    public abstract class TransferObject : Contracts.IIdentifiable
    {
        public int Id { get; set; }
    }
}
