using System;

namespace MusicStore.Logic.Context
{
	internal abstract class ContextObject : IDisposable
    {
        public abstract E Insert<I, E>(I entity)
            where E : Entities.EntityObject, I, Contracts.ICopyable<I>, new()
            where I : Contracts.IIdentifiable;

        public abstract E Update<I, E>(I entity)
            where E : Entities.EntityObject, I, Contracts.ICopyable<I>
            where I : Contracts.IIdentifiable;

        public abstract E Delete<I, E>(int id)
            where E : Entities.EntityObject, I
            where I : Contracts.IIdentifiable;

        public abstract void Save();

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ContextObject()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
