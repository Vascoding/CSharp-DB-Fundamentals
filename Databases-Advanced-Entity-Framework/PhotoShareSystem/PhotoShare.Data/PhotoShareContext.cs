


namespace PhotoShare.Data
{
    using Models;
    using System.Data.Entity;
    using Migrations;



    public class PhotoShareContext : DbContext
    { 
        public PhotoShareContext() : base("name=PhotoShareContext")
        {
            this.Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhotoShareContext, Configuration>());
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Album> Albums { get; set; }

        public virtual DbSet<Picture> Pictures { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }

        public virtual DbSet<AlbumRole> AlbumRoles { get; set; }

        public virtual DbSet<Town> Towns { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FriendId");
                    m.ToTable("UsersFriends");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}