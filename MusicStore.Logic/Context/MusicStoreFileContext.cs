using System;
using System.Collections.Generic;
using System.Linq;
using CommonBase.Extensions;

namespace MusicStore.Logic.Context
{
    abstract class MusicStoreFileContext : FileContext, IMusicStoreContext
    {
        private List<Entities.Genre> genres = null;
        public IEnumerable<Entities.Genre> Genres => genres ?? (genres = LoadEntities<Entities.Genre>());
        private List<Entities.Artist> artists = null;
        public IEnumerable<Entities.Artist> Artists => artists ?? (artists = LoadEntities<Entities.Artist>());
        private List<Entities.Album> albums = null;
        public IEnumerable<Entities.Album> Albums => albums ?? (albums = LoadEntities<Entities.Album>());
        private List<Entities.Track> tracks = null;
        public IEnumerable<Entities.Track> Tracks => tracks ?? (tracks = LoadEntities<Entities.Track>());

        protected abstract List<T> LoadEntities<T>() where T : Entities.EntityObject, new();

        protected E GetById<I, E>(int id)
            where E : Entities.EntityObject, I
            where I : Contracts.IIdentifiable
        {
            E result = default(E);

            if (typeof(I) is Contracts.IGenre)
            {
                result = genres.SingleOrDefault(i => i.Id == id) as E;
            }
            else if (typeof(I) is Contracts.IArtist)
            {
                result = artists.SingleOrDefault(i => i.Id == id) as E;
            }
            else if (typeof(I) is Contracts.IAlbum)
            {
                result = albums.SingleOrDefault(i => i.Id == id) as E;
            }
            else if (typeof(I) is Contracts.ITrack)
            {
                result = tracks.SingleOrDefault(i => i.Id == id) as E;
            }
            else
            {
                throw new ArgumentException(
                               message: "entity is not a recognized entity",
                               paramName: nameof(I));
            }
            return result;
        }
        protected void AddToList<E>(E entity)
        {
            entity.CheckArgument(nameof(entity));

            switch (entity)
            {
                case Entities.Genre add:
                    {
                        genres.Add(add);
                        break;
                    }
                case Entities.Artist add:
                    {
                        artists.Add(add);
                        break;
                    }
                case Entities.Album add:
                    {
                        albums.Add(add);
                        break;
                    }
                case Entities.Track add:
                    {
                        tracks.Add(add);
                        break;
                    }
                default:
                    throw new ArgumentException(
                                   message: "entity is not a recognized entity",
                                   paramName: nameof(entity));
            }
        }
        public override E Insert<I, E>(I entity)
        {
            entity.CheckArgument(nameof(entity));

            E result = new E();

            result.State = Entities.EntityState.Added;
            result.CopyProperties(entity);
            result.Id = 0;
            AddToList(result);
            return result;
        }
        public override E Update<I, E>(I entity)
        {
            entity.CheckArgument(nameof(entity));

            E result = default(E);
            E item = GetById<I, E>(entity.Id);

            if (item != null && item.State != Entities.EntityState.Deleted)
            {
                result = item;
                result.CopyProperties(entity);
                result.State = Entities.EntityState.Modified;
            }
            return result;
        }
        public override E Delete<I, E>(int id)
        {
            E result = GetById<I, E>(id);

            if (result != null)
            {
                result.State = Entities.EntityState.Deleted;
            }
            return result;
        }
    }
}
