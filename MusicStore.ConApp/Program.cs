using System;
using System.Threading.Tasks;

namespace MusicStore.ConApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
 //           await CopyDataFromToAsync(Logic.Factory.PersistenceType.Csv, Logic.Factory.PersistenceType.Db);

            // Output
            await PrintDataAsync(Logic.Factory.PersistenceType.Db);
        }

        static void CopyDataFromTo(Logic.Factory.PersistenceType source, Logic.Factory.PersistenceType target)
        {
            Logic.Factory.Persistence = source;
            using (var genreCtrl = Logic.Factory.CreateGenreController())
            using (var artistCtrl = Logic.Factory.CreateArtistController(genreCtrl))
            using (var albumCtrl = Logic.Factory.CreateAlbumController(genreCtrl))
            using (var trackCtrl = Logic.Factory.CreateTrackController(genreCtrl))
            {
                Logic.Factory.Persistence = target;
                using (var genreSerCtrl = Logic.Factory.CreateGenreController())
                using (var artistSerCtrl = Logic.Factory.CreateArtistController(genreSerCtrl))
                using (var albumSerCtrl = Logic.Factory.CreateAlbumController(genreSerCtrl))
                using (var trackSerCtrl = Logic.Factory.CreateTrackController(genreSerCtrl))
                {
                    foreach (var item in genreCtrl.GetAll())
                    {
                        genreSerCtrl.Insert(item);
                    }
                    genreSerCtrl.SaveChanges();

                    foreach (var item in artistCtrl.GetAll())
                    {
                        artistSerCtrl.Insert(item);
                    }
                    artistSerCtrl.SaveChanges();

                    foreach (var item in albumCtrl.GetAll())
                    {
                        albumSerCtrl.Insert(item);
                    }
                    albumSerCtrl.SaveChanges();

                    foreach (var item in trackCtrl.GetAll())
                    {
                        trackSerCtrl.Insert(item);
                    }
                    trackSerCtrl.SaveChanges();
                }
            }
        }
        static async Task CopyDataFromToAsync(Logic.Factory.PersistenceType source, Logic.Factory.PersistenceType target)
        {
            Logic.Factory.Persistence = source;
            using (var genreCtrl = Logic.Factory.CreateGenreController())
            using (var artistCtrl = Logic.Factory.CreateArtistController(genreCtrl))
            using (var albumCtrl = Logic.Factory.CreateAlbumController(genreCtrl))
            using (var trackCtrl = Logic.Factory.CreateTrackController(genreCtrl))
            {
                Logic.Factory.Persistence = target;
                using (var genreSerCtrl = Logic.Factory.CreateGenreController())
                using (var artistSerCtrl = Logic.Factory.CreateArtistController(genreSerCtrl))
                using (var albumSerCtrl = Logic.Factory.CreateAlbumController(genreSerCtrl))
                using (var trackSerCtrl = Logic.Factory.CreateTrackController(genreSerCtrl))
                {
                    foreach (var item in await genreCtrl.GetAllAsync())
                    {
                        await genreSerCtrl.InsertAsync(item);
                    }
                    await genreSerCtrl.SaveChangesAsync();

                    foreach (var item in await artistCtrl.GetAllAsync())
                    {
                        await artistSerCtrl.InsertAsync(item);
                    }
                    await artistSerCtrl.SaveChangesAsync();

                    foreach (var item in await albumCtrl.GetAllAsync())
                    {
                        await albumSerCtrl.InsertAsync(item);
                    }
                    await albumSerCtrl.SaveChangesAsync();

                    foreach (var item in await trackCtrl.GetAllAsync())
                    {
                        await trackSerCtrl.InsertAsync(item);
                    }
                    await trackSerCtrl.SaveChangesAsync();
                }
            }
        }
        static void PrintData(Logic.Factory.PersistenceType source)
        {
            Logic.Factory.Persistence = source;
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
        static async Task PrintDataAsync(Logic.Factory.PersistenceType source)
        {
            Logic.Factory.Persistence = source;
            using (var genreCtrl = Logic.Factory.CreateGenreController())
            using (var artistCtrl = Logic.Factory.CreateArtistController(genreCtrl))
            using (var albumCtrl = Logic.Factory.CreateAlbumController(genreCtrl))
            using (var trackCtrl = Logic.Factory.CreateTrackController(genreCtrl))
            {
                Console.WriteLine("Write all genres");
                foreach (var item in await genreCtrl.GetAllAsync())
                {
                    Console.WriteLine($"{item.Id} - {item.Name}");
                }

                Console.WriteLine("Write all artists");
                foreach (var item in await artistCtrl.GetAllAsync())
                {
                    Console.WriteLine($"{item.Id} - {item.Name}");
                }

                Console.WriteLine("Write all alben");
                foreach (var item in await albumCtrl.GetAllAsync())
                {
                    Console.WriteLine($"{item.Id} - {item.Title}");
                }

                Console.WriteLine("Write all tracks");
                foreach (var item in await trackCtrl.GetAllAsync())
                {
                    Console.WriteLine($"{item.Id} - {item.Title}");
                }
            }
        }
    }
}

