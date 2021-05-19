using Microsoft.EntityFrameworkCore;

namespace EcommercePortfolio.Models
{
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : 
            base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        //creates an entity of type Item
        public DbSet<Item> Items { get; set; }
        //Creates an entity of type Category
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 1,
                CategoryName ="Musical Instruments"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 2,
                CategoryName = "Watches"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 3,
                CategoryName = "Clothes"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 4,
                CategoryName = "Vehicles"
            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                ItemId = 1,
                Name = "Violin",
                Price = 550M,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Cursus risus at ultrices mi tempus imperdiet nulla malesuada pellentesque. Tortor posuere ac ut consequat. Sagittis nisl rhoncus mattis rhoncus urna neque viverra justo. Lacus sed turpis tincidunt id aliquet risus feugiat in. Viverra aliquet eget sit amet tellus cras adipiscing enim eu.",
                CategoryId = 1, 
                ImageUrl = "\\Img\\instrument-2505099__340.jpg",
                ImageThumbnailUrl = "\\Img\\instrument-2505099__340.jpg",
                IsInStock = true,
                IsOnSale = false
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                ItemId = 2,
                Name = "Rolex",
                Price = 5550M,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Cursus risus at ultrices mi tempus imperdiet nulla malesuada pellentesque. Tortor posuere ac ut consequat. Sagittis nisl rhoncus mattis rhoncus urna neque viverra justo. Lacus sed turpis tincidunt id aliquet risus feugiat in. Viverra aliquet eget sit amet tellus cras adipiscing enim eu.",
                CategoryId = 2,
                ImageUrl = "\\Img\\rolex-2171960__340.jpg",
                ImageThumbnailUrl = "\\Img\\rolex-2171960__340.jpg",
                IsInStock = true,
                IsOnSale = false
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                ItemId = 3,
                Name = "T Shirt",
                Price = 50M,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Cursus risus at ultrices mi tempus imperdiet nulla malesuada pellentesque. Tortor posuere ac ut consequat. Sagittis nisl rhoncus mattis rhoncus urna neque viverra justo. Lacus sed turpis tincidunt id aliquet risus feugiat in. Viverra aliquet eget sit amet tellus cras adipiscing enim eu.",
                CategoryId = 3,
                ImageUrl = "\\Img\\isolated-t-shirt-1852115_960_720.png",
                ImageThumbnailUrl = "\\Img\\isolated-t-shirt-1852115_960_720.png",
                IsInStock = true,
                IsOnSale = false
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                ItemId = 4,
                Name = "Lamborghini",
                Price = 5505050M,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Cursus risus at ultrices mi tempus imperdiet nulla malesuada pellentesque. Tortor posuere ac ut consequat. Sagittis nisl rhoncus mattis rhoncus urna neque viverra justo. Lacus sed turpis tincidunt id aliquet risus feugiat in. Viverra aliquet eget sit amet tellus cras adipiscing enim eu.",
                CategoryId = 4,
                ImageUrl = "\\Img\\lamborghini-1819244_960_720.jpg",
                ImageThumbnailUrl = "\\Img\\lamborghini-1819244_960_720.jpg",
                IsInStock = true,
                IsOnSale = false
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                ItemId = 5,
                Name = "Guitar",
                Price = 900M,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Cursus risus at ultrices mi tempus imperdiet nulla malesuada pellentesque. Tortor posuere ac ut consequat. Sagittis nisl rhoncus mattis rhoncus urna neque viverra justo. Lacus sed turpis tincidunt id aliquet risus feugiat in. Viverra aliquet eget sit amet tellus cras adipiscing enim eu.",
                CategoryId = 1,
                ImageUrl = "\\Img\\guitar-149427_960_720.png",
                ImageThumbnailUrl = "\\Img\\guitar-149427_960_720.png",
                IsInStock = true,
                IsOnSale = false
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                ItemId = 6,
                Name = "Gold Watch",
                Price = 6000M,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Cursus risus at ultrices mi tempus imperdiet nulla malesuada pellentesque. Tortor posuere ac ut consequat. Sagittis nisl rhoncus mattis rhoncus urna neque viverra justo. Lacus sed turpis tincidunt id aliquet risus feugiat in. Viverra aliquet eget sit amet tellus cras adipiscing enim eu.",
                CategoryId = 2,
                ImageUrl = "\\Img\\clock-3005574_960_720.jpg",
                ImageThumbnailUrl = "\\Img\\clock-3005574_960_720.jpg",
                IsInStock = true,
                IsOnSale = false
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                ItemId = 7,
                Name = "Top Hat",
                Price = 24M,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Cursus risus at ultrices mi tempus imperdiet nulla malesuada pellentesque. Tortor posuere ac ut consequat. Sagittis nisl rhoncus mattis rhoncus urna neque viverra justo. Lacus sed turpis tincidunt id aliquet risus feugiat in. Viverra aliquet eget sit amet tellus cras adipiscing enim eu.",
                CategoryId = 3,
                ImageUrl = "\\Img\\coachman-3694468_960_720.jpg",
                ImageThumbnailUrl = "\\Img\\coachman-3694468_960_720.jpg",
                IsInStock = true,
                IsOnSale = false
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                ItemId = 8,
                Name = "Helicopter",
                Price = 100000M,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Cursus risus at ultrices mi tempus imperdiet nulla malesuada pellentesque. Tortor posuere ac ut consequat. Sagittis nisl rhoncus mattis rhoncus urna neque viverra justo. Lacus sed turpis tincidunt id aliquet risus feugiat in. Viverra aliquet eget sit amet tellus cras adipiscing enim eu.",
                CategoryId = 4,
                ImageUrl = "\\Img\\helicopter-1003_960_720.jpg",
                ImageThumbnailUrl = "\\Img\\helicopter-1003_960_720.jpg",
                IsInStock = true,
                IsOnSale = false
            });
        }
    }
}
