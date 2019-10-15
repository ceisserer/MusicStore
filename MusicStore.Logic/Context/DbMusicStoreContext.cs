using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MusicStore.Contracts;
using MusicStore.Logic.Entities;

namespace MusicStore.Logic.Context
{
    class DbMusicStoreContext : DbContext, IMusicStoreContext
    {
        public IEnumerable<Genre> Genres => throw new NotImplementedException();
        public IEnumerable<Artist> Artists => throw new NotImplementedException();
        public IEnumerable<Album> Albums => throw new NotImplementedException();
        public IEnumerable<Track> Tracks => throw new NotImplementedException();


        public DbSet<Genre> GenreSet { get; set; }
        public DbSet<Artist> ArtistSet { get; set; }

        public void Delete<T>(T entity) where T : IIdentifiable
        {
            throw new NotImplementedException();
        }

        public void Insert<T>(T entity) where T : IIdentifiable
        {
            throw new NotImplementedException();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
            //optionsBuilder.UseSqlCe(@"Data Source=C:\Temp\MusicStore.sdf");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
