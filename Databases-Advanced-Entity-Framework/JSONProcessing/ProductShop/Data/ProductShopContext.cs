


namespace ProductShop.Data
{
    using ProductShop.Models;
    using System.Data.Entity;


    public class ProductShopContext : DbContext
    {

        public ProductShopContext()
            : base("name=ProductShopContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithMany()
                .Map(uf =>
                {
                    uf.MapLeftKey("UserId");
                    uf.MapRightKey("FriendId");
                    uf.ToTable("UserFriends");
                });
            

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        
    }
}