using System;
using System.Collections.Generic;
using System.Linq;
using MusicStore.Logic.Context;

namespace MusicStore.Logic.Controllers
{
	internal abstract class GenericController<E, I> : ControllerObject, IController<I>
		where E : Entities.EntityObject, I, Contracts.ICopyable<I>, new()
		where I : Contracts.IIdentifiable
	{
		protected abstract IEnumerable<E> Set { get; }

		protected GenericController(ContextObject contextObject)
			: base(contextObject)
		{

		}
		protected GenericController(ControllerObject controllerObject)
			: base(controllerObject)
		{

		}

		public virtual I Create()
		{
			return new E();
		}

		public virtual IEnumerable<I> GetAll()
		{
			return Set.Where(i => i.State != Entities.EntityState.Deleted)
					  .Select(i =>
					  {
						  var result = new E();

						  result.CopyProperties(i);
						  return result;
					  });
		}
		public virtual I GetById(int id)
		{
			var result = default(E);
			var item = Set.SingleOrDefault(i => i.State != Entities.EntityState.Deleted && i.Id == id);

			if (item != null)
			{
				result = new E();
				result.CopyProperties(item);
			}
			return result;
		}
        protected virtual void BeforeInserting(I entity)
        {

        }
		public virtual I Insert(I entity)
		{
			if (entity == null)
				throw new ArgumentNullException(nameof(entity));

            BeforeInserting(entity);
            var result = Context.Insert<I, E>(entity);
            AfterInserted(result);
			return result;
		}
        protected virtual void AfterInserted(E entity)
        {

        }

        protected virtual void BeforeUpdating(I entity)
        {

        }
		public virtual void Update(I entity)
		{
			if (entity == null)
				throw new ArgumentNullException(nameof(entity));

            BeforeUpdating(entity);
            var updateEntity = Context.Update<I, E>(entity);

			if (updateEntity != null)
			{
                AfterUpdated(updateEntity);
			}
            else
            {
                throw new Exception("Entity can't find!");
            }
		}
        protected virtual void AfterUpdated(E entity)
        {

        }

        protected virtual void BeforeDeleting(int id)
        {

        }
		public void Delete(int id)
		{
            BeforeDeleting(id);
            var item = Context.Delete<I, E>(id);

			if (item != null)
			{
                AfterDeleted(item);
			}
		}
        protected virtual void AfterDeleted(E entity)
        {

        }

		public void Save()
		{
            Context.Save();
		}
	}
}
