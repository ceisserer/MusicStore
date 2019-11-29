using System;
using System.Collections.Generic;

namespace MusicStore.Logic
{
	public interface IController<T> : IDisposable 
        where T : Contracts.IIdentifiable
    {
        int Count();
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Create();
        T Insert(T entity);
		void Update(T entity);
		void Delete(int id);
        void SaveChanges();
    }
}
