using ArtisanBackEnd;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Numerics;
using Microsoft.EntityFrameworkCore;
using ArtisanBackEnd.Domain.Entities;

namespace ArtisanBackEnd.Infastructure.Persistence.Context
{
    public class ArtisanBackendContext : DbContext
    {
        
        public ArtisanBackendContext(DbContextOptions<ArtisanBackendContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Artisan> Artisans { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Dispute> Disputes { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<JobPost> JobPosts { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<InHousePayment> InHousePayments { get; set; }
        public DbSet<PayStackPayment> PayStackPayments { get; set; }


    }
}