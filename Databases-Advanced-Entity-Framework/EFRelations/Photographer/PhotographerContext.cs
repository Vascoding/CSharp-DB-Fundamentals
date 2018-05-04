

namespace Photographer
{
    using Migrations;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;
    public class PhotographerContext : DbContext
    {
        // Your context has been configured to use a 'PhotographerContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Photographer.PhotographerContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'PhotographerContext' 
        // connection string in the application configuration file.
        public PhotographerContext()
            : base("name=PhotographerContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhotographerContext, Configuration>());
        }

        public virtual DbSet<Photographer> Photographers { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<PhotographerAlbum> PhotographerAlbums { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}