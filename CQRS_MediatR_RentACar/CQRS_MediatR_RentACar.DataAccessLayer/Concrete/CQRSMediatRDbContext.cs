using CQRS_MediatR_RentACar.EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.DataAccessLayer.Concrete
{
    public class CQRSMediatRDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-33VDDOP\\SQLEXPRESS17;initial catalog=CQRSMediatRDb;integrated security=true;trust server certificate=true");
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<SendMessage> SendMessages { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<CarRecommendationAI> CarRecommendationAIs { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
