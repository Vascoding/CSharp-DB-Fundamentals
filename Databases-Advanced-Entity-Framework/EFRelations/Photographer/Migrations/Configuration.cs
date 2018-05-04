namespace Photographer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<PhotographerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PhotographerContext context)
        {
            Photographer pesho = new Photographer();
            pesho.UserName = "Pesho Peshov";
            pesho.Password = "edfj123";
            pesho.Email = "Pesho@dir.bg";
            pesho.BirthDay = new DateTime(1999, 5, 5);
            pesho.RegisteredOn = new DateTime(2013, 5, 5);
            
            context.Photographers.AddOrUpdate(p => p.UserName, pesho);
            

            Photographer stoian = new Photographer();
            stoian.UserName = "Stoian dimitrov";
            stoian.Password = "ed4f3s3";
            stoian.Email = "stoti@dir.bg";
            stoian.BirthDay = new DateTime(1998, 5, 5);
            stoian.RegisteredOn = new DateTime(2015, 5, 5);

            context.Photographers.AddOrUpdate(p => p.UserName, stoian);
           

            Photographer dimo = new Photographer();
            dimo.UserName = "Dimo Dimchou";
            dimo.Password = "edfj123df";
            dimo.Email = "dimchoo@dir.bg";
            dimo.BirthDay = new DateTime(1992, 5, 5);
            dimo.RegisteredOn = new DateTime(2010, 5, 5);
            context.Photographers.AddOrUpdate(p => p.UserName, dimo);

            Album album1 = new Album();
            album1.Name = "BirthDays";
            context.Albums.AddOrUpdate(p => p.Name, album1);

            Album album2 = new Album();
            album2.Name = "Expeditions";
            context.Albums.AddOrUpdate(p => p.Name, album2);

            Album album3 = new Album();
            album3.Name = "Halloween";
            context.Albums.AddOrUpdate(p => p.Name, album3);

            PhotographerAlbum pa1 = new PhotographerAlbum();
            pa1.Album_Id = album1.Id;
            pa1.Photographer_Id = pesho.Id;
            pa1.Role = Role.Owner;
            context.PhotographerAlbums.AddOrUpdate(pa1);

            PhotographerAlbum pa2 = new PhotographerAlbum();
            pa2.Album_Id = album2.Id;
            pa2.Photographer_Id = stoian.Id;
            pa2.Role = Role.Viewer;
            context.PhotographerAlbums.AddOrUpdate(pa2);

            PhotographerAlbum pa3 = new PhotographerAlbum();
            pa3.Album_Id = album3.Id;
            pa3.Photographer_Id = dimo.Id;
            pa3.Role = Role.Viewer;
            context.PhotographerAlbums.AddOrUpdate(pa3);

            
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
