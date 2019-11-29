using System;

namespace MusicStore.ConApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Logic.Factory.Persistence = Logic.Factory.PersistenceType.Csv;
            //using (var genreCtrl = Logic.Factory.CreateGenreController())
            //using (var artistCtrl = Logic.Factory.CreateArtistController(genreCtrl))
            //using (var albumCtrl = Logic.Factory.CreateAlbumController(genreCtrl))
            //using (var trackCtrl = Logic.Factory.CreateTrackController(genreCtrl))
            //{
            //    Logic.Factory.Persistence = Logic.Factory.PersistenceType.Db;
            //    using (var genreSerCtrl = Logic.Factory.CreateGenreController())
            //    using (var artistSerCtrl = Logic.Factory.CreateArtistController(genreSerCtrl))
            //    using (var albumSerCtrl = Logic.Factory.CreateAlbumController(genreSerCtrl))
            //    using (var trackSerCtrl = Logic.Factory.CreateTrackController(genreSerCtrl))
            //    {
            //        foreach (var item in genreCtrl.GetAll())
            //        {
            //            genreSerCtrl.Insert(item);
            //        }
            //        genreSerCtrl.SaveChanges();

            //        foreach (var item in artistCtrl.GetAll())
            //        {
            //            artistSerCtrl.Insert(item);
            //        }
            //        artistSerCtrl.SaveChanges();

            //        foreach (var item in albumCtrl.GetAll())
            //        {
            //            albumSerCtrl.Insert(item);
            //        }
            //        albumSerCtrl.SaveChanges();

            //        foreach (var item in trackCtrl.GetAll())
            //        {
            //            trackSerCtrl.Insert(item);
            //        }
            //        trackSerCtrl.SaveChanges();
            //    }
            //}

            // Output
            Logic.Factory.Persistence = Logic.Factory.PersistenceType.Db;
            using (var genreCtrl = Logic.Factory.CreateGenreController())
            using (var artistCtrl = Logic.Factory.CreateArtistController(genreCtrl))
            using (var albumCtrl = Logic.Factory.CreateAlbumController(genreCtrl))
            using (var trackCtrl = Logic.Factory.CreateTrackController(genreCtrl))
            {
                Console.WriteLine("Write all genres");
                foreach (var item in genreCtrl.GetAll())
                {
                    Console.WriteLine($"{item.Id} - {item.Name}");
                }

                Console.WriteLine("Write all artists");
                foreach (var item in artistCtrl.GetAll())
                {
                    Console.WriteLine($"{item.Id} - {item.Name}");
                }

                Console.WriteLine("Write all alben");
                foreach (var item in albumCtrl.GetAll())
                {
                    Console.WriteLine($"{item.Id} - {item.Title}");
                }

                Console.WriteLine("Write all tracks");
                foreach (var item in trackCtrl.GetAll())
                {
                    Console.WriteLine($"{item.Id} - {item.Title}");
                }
            }
        }
    }
}

