using System;

namespace MusicStore.Logic
{
	public class Factory
    {
        public enum PersistenceType
        {
            Db,
            Csv,
            Ser,
        }
        public static PersistenceType Persistence { get; set; } = Factory.PersistenceType.Csv;
        private static DataContext.IContext CreateContext()
        {
            DataContext.IContext result = null;

            if (Persistence == PersistenceType.Csv)
            {
                result = new DataContext.Csv.CsvMusicStoreContext();
            }
            else if (Persistence == PersistenceType.Db)
            {
                result = new DataContext.Db.DbMusicStoreContext();
            }
            else if (Persistence == PersistenceType.Ser)
            {
                result = new DataContext.Ser.SerMusicStoreContext();
            }
            return result;
        }

        public static IController<T> CreateController<T>() where T : Contracts.IIdentifiable
        {
            IController<T> result = null;

            if (typeof(T) == typeof(Contracts.IGenre))
            {
                result = (IController<T>)CreateGenreController();
            }
            else if (typeof(T) == typeof(Contracts.IArtist))
            {
                result = (IController<T>)CreateArtistController();
            }
            else if (typeof(T) == typeof(Contracts.IAlbum))
            {
                result = (IController<T>)CreateAlbumController();
            }
            else if (typeof(T) == typeof(Contracts.ITrack))
            {
                result = (IController<T>)CreateTrackController();
            }
            return result;
        }
        public static IController<T> CreateController<T>(object sharedController) where T : Contracts.IIdentifiable
        {
            IController<T> result = null;

            if (typeof(T) == typeof(Contracts.IGenre))
            {
                result = (IController<T>)CreateGenreController(sharedController);
            }
            else if (typeof(T) == typeof(Contracts.IArtist))
            {
                result = (IController<T>)CreateArtistController(sharedController);
            }
            else if (typeof(T) == typeof(Contracts.IAlbum))
            {
                result = (IController<T>)CreateAlbumController(sharedController);
            }
            else if (typeof(T) == typeof(Contracts.ITrack))
            {
                result = (IController<T>)CreateTrackController(sharedController);
            }
            return result;
        }

        public static IController<Contracts.IGenre> CreateGenreController()
        {
            return new Controllers.GenreController(CreateContext());
        }
		public static IController<Contracts.IGenre> CreateGenreController(object sharedController)
		{
			if (sharedController == null)
				throw new ArgumentNullException(nameof(sharedController));

			Controllers.ControllerObject controller = (Controllers.ControllerObject)sharedController;

			return new Controllers.GenreController(controller);
		}

		public static IController<Contracts.IArtist> CreateArtistController()
		{
			return new Controllers.ArtistController(CreateContext());
		}
		public static IController<Contracts.IArtist> CreateArtistController(object sharedController)
		{
			if (sharedController == null)
				throw new ArgumentNullException(nameof(sharedController));

			Controllers.ControllerObject controller = (Controllers.ControllerObject)sharedController;

			return new Controllers.ArtistController(controller);
		}

        public static IController<Contracts.IAlbum> CreateAlbumController()
        {
            return new Controllers.AlbumController(CreateContext());
        }
        public static IController<Contracts.IAlbum> CreateAlbumController(object sharedController)
        {
            if (sharedController == null)
                throw new ArgumentNullException(nameof(sharedController));

            Controllers.ControllerObject controller = (Controllers.ControllerObject)sharedController;

            return new Controllers.AlbumController(controller);
        }

        public static IController<Contracts.ITrack> CreateTrackController()
        {
            return new Controllers.TrackController(CreateContext());
        }
        public static IController<Contracts.ITrack> CreateTrackController(object sharedController)
        {
            if (sharedController == null)
                throw new ArgumentNullException(nameof(sharedController));

            Controllers.ControllerObject controller = (Controllers.ControllerObject)sharedController;

            return new Controllers.TrackController(controller);
        }
    }
}
