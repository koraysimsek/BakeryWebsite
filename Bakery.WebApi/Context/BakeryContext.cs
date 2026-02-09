using Bakery.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bakery.WebApi.Context
{
    public class BakeryContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=KORAY; Database = BakeryDb; Trusted_Connection = True; TrustServerCertificate = True");
        }

        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
    }
}
