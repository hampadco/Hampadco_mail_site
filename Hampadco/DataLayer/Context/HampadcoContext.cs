using DataLayer.Entities.Address;
using DataLayer.Entities.Agency;
using DataLayer.Entities.Baner;
using DataLayer.Entities.Blog;
using DataLayer.Entities.Category;
using DataLayer.Entities.Comment;
using DataLayer.Entities.Experts;
using DataLayer.Entities.Financial;
using DataLayer.Entities.Gallery;
using DataLayer.Entities.Logo;
using DataLayer.Entities.Message;
using DataLayer.Entities.Order;
using DataLayer.Entities.Originality;
using DataLayer.Entities.Product;
using DataLayer.Entities.Richat;
using DataLayer.Entities.Slider;
using DataLayer.Entities.SocialNetwork;
using DataLayer.Entities.Teaser;
using DataLayer.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
// using DataLayer.Entities;

namespace DataLayer.Context
{
    public class HampadcoContext : DbContext
    {
        public HampadcoContext(DbContextOptions<HampadcoContext> options) : base(options)
        {
        }
        /* -------------------------- Tbls Admin ------------------------------------------- */
        public DbSet<Tbl_Address> Tbl_Addresses { get; set; }
        public DbSet<Tbl_Agency> Tbl_Agencys { get; set; }
        public DbSet<Tbl_Blog> Tbl_Blogs { get; set; }
        public DbSet<Tbl_Comment> Tbl_Comments { get; set; }
        public DbSet<Tbl_Category> Tbl_Categorys { get; set; }
        public DbSet<Tbl_Experts> Tbl_Expertses { get; set; }
        public DbSet<Tbl_Financial> Tbl_Financials { get; set; }
        public DbSet<Tbl_Gallery> Tbl_Gallerys { get; set; }
        public DbSet<Tbl_ImageGallery> Tbl_ImageGallerys {get; set;}
        public DbSet<Tbl_Logo> Tbl_Logos { get; set; }
        public DbSet<Tbl_Message> Tbl_Messages { get; set; }
        public DbSet<Tbl_Order> Tbl_Orders { get; set; }
        public DbSet<Tbl_Factor> Tbl_Factors { get; set; }
        public DbSet<Tbl_Originality> Tbl_Originalitys { get; set; }
        public DbSet<Tbl_Product> Tbl_Products { get; set; }
        public DbSet<Tbl_Slider> Tbl_Sliders { get; set; }
        public DbSet<Tbl_Baner> Tbl_Baners { get; set; }
        public DbSet<Tbl_Richat> Tbl_Richats { get; set; }
        public DbSet<Tbl_SocialNetwork> Tbl_SocialNetworks { get; set; }
        public DbSet<Tbl_Teaser> Tbl_Teasers { get; set; }
        public DbSet<Tbl_User> Tbl_Users { get; set; }
        public DbSet<Tbl_GalleryProduct> Tbl_GalleryProducts { get; set; }
        public DbSet<Tbl_MyFavorite> Tbl_MyFavorites { get; set; }
        /* Tbls */
        // public DbSet<Tbl_User> Tbl_Users { get; set; }

    }
    public class ToDoContextFactory : IDesignTimeDbContextFactory<HampadcoContext>
    {
        public HampadcoContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<HampadcoContext>();
            builder.UseSqlServer("Data Source=.;initial Catalog=HampadcoDb;integrated Security=SSPI;MultipleActiveResultSets=true");
            //  builder.UseSqlServer("Data Source=193.141.64.76,2019;initial Catalog=hampadco;USER ID=hampadco;PASSWORD=12345@iran;MultipleActiveResultSets=true");

            return new HampadcoContext(builder.Options);
        }
    }
}