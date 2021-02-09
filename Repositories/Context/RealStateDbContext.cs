﻿using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Context
{
    public class RealStateDbContext : IdentityDbContext<AppUser>
    {
        public RealStateDbContext(DbContextOptions<RealStateDbContext> options) : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }


        public DbSet<House> Houses { get; set; }
        public DbSet<HouseFeature> HouseFeatures { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<HouseService> HouseServices { get; set; }
        public DbSet<Province> Provinces { get; set; }

        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillService> BillServices { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Many to Many Relationships


            // User

            // User to Bill
            modelBuilder.Entity<AppUser>().
                HasMany(u => u.Bills).
                WithOne(b => b.Customer).
                HasForeignKey(b => b.CustomerId).OnDelete(DeleteBehavior.NoAction); ;

            // User to AppUserRole
            modelBuilder
            .Entity<AppUserRole>()
            .HasMany(uR => uR.Users)
            .WithOne(u => u.Role)
            .HasForeignKey(u => u.AppUserRoleId)
            .OnDelete(DeleteBehavior.NoAction);

            // House

            // House - HouseFeature - Feature
            modelBuilder.Entity<HouseFeature>()
                .HasKey(bF => new { bF.HouseId, bF.FeatureId });

            modelBuilder.Entity<HouseFeature>()
                .HasOne(bF => bF.House)
                .WithMany(b => b.Features)
                .HasForeignKey(bF => bF.HouseId).OnDelete(DeleteBehavior.NoAction);
            ;

            modelBuilder.Entity<HouseFeature>()
                .HasOne(bF => bF.Feature)
                .WithMany(f => f.Houses)
                .HasForeignKey(bF => bF.FeatureId).OnDelete(DeleteBehavior.NoAction); ;
            ;

            modelBuilder.Entity<House>()
                .HasOne(b => b.Province)
                .WithMany(l => l.Houses)
                .HasForeignKey(b => b.ProvinceId).OnDelete(DeleteBehavior.NoAction); ;
            ;

            // Bill - BillService - Service
            modelBuilder.Entity<BillService>()
                .HasKey(bS => new { bS.BillId, bS.ServiceId });

            modelBuilder.Entity<BillService>()
                .HasOne(bS => bS.Bill)
                .WithMany(b => b.Services)
                .HasForeignKey(bS => bS.ServiceId).OnDelete(DeleteBehavior.NoAction); ;
            ;

            modelBuilder.Entity<BillService>()
                .HasOne(bS => bS.Service)
                .WithMany(s => s.Bills)
                .HasForeignKey(bs => bs.BillId).OnDelete(DeleteBehavior.NoAction); ;
            ;

            modelBuilder.Entity<Bill>()
                .HasOne(b => b.PaymentMethod)
                .WithMany(b => b.Bills)
                .HasForeignKey(b => b.PaymentMethodId).OnDelete(DeleteBehavior.NoAction);
            ;
            // Service
            //Build - BuildService - Service
            // Bill - BillService - Service
            modelBuilder.Entity<HouseService>()
                .HasKey(bS => new { bS.HouseId, bS.ServiceId });

            modelBuilder.Entity<HouseService>()
                .HasOne(bS => bS.House)
                .WithMany(b => b.Services)
                .HasForeignKey(bS => bS.ServiceId).OnDelete(DeleteBehavior.NoAction); ;
            ;

            modelBuilder.Entity<HouseService>()
                .HasOne(bS => bS.Service)
                .WithMany(s => s.Houses)
                .HasForeignKey(bs => bs.HouseId).OnDelete(DeleteBehavior.NoAction); ;
            ;

            modelBuilder.Entity<House>().HasData(
                new House()
                {
                    HouseId = 1,
                    Name = "House #1",
                    Price = 100000,
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Bathrooms = 1,
                    Bedrooms = 1,
                    Size = 100,
                    IsItAvailable = true,
                    ProvinceId = 1,
                    ImageName = "House1.jpeg"
                },
                new House()
                {
                    HouseId = 2,
                    Name = "House #2",
                    Price = 125000,
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Bathrooms = 2,
                    Bedrooms = 2,
                    Size = 300,
                    IsItAvailable = true,
                    ProvinceId = 2,
                    ImageName = "House2.jpeg"
                },
                new House()
                {
                    HouseId = 3,
                    Name = "House #3",
                    Price = 155000,
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Bathrooms = 1,
                    Bedrooms = 2,
                    Size = 180,
                    IsItAvailable = true,
                    ProvinceId = 3,
                    ImageName = "House3.jpeg"
                },
                new House()
                {
                    HouseId = 4,
                    Name = "House #4",
                    Price = 250000,
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Bathrooms = 2,
                    Bedrooms = 4,
                    Size = 225,
                    IsItAvailable = true,
                    ProvinceId = 4,
                    ImageName = "House4.jpeg"
                },
                new House()
                {
                    HouseId = 5,
                    Name = "House #5",
                    Price = 330000,
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Bathrooms = 3,
                    Bedrooms = 3,
                    Size = 500,
                    IsItAvailable = true,
                    ProvinceId = 5,
                    ImageName = "House5.jpeg"
                },
                new House()
                {
                    HouseId = 6,
                    Name = "House #6",
                    Price = 2100000,
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Bathrooms = 3,
                    Bedrooms = 2,
                    Size = 190,
                    IsItAvailable = true,
                    ProvinceId = 6,
                    ImageName = "House6.jpeg"
                },
                new House()
                {
                    HouseId = 7,
                    Name = "House #7",
                    Price = 300000,
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Bathrooms = 2,
                    Bedrooms = 4,
                    Size = 260,
                    IsItAvailable = true,
                    ProvinceId = 7,
                    ImageName = "House7.jpeg"
                });

            modelBuilder.Entity<HouseFeature>().HasData(
                   new HouseFeature()
                   {
                       HouseId = 1,
                       FeatureId = 1,
                   },
                   new HouseFeature()
                   {
                       HouseId = 1,
                       FeatureId = 2,
                   },
                   new HouseFeature()
                   {
                       HouseId = 1,
                       FeatureId = 3,
                   },
                    new HouseFeature()
                    {
                        HouseId = 2,
                        FeatureId = 2,
                    },
                   new HouseFeature()
                   {
                       HouseId = 3,
                       FeatureId = 2,
                   },
                   new HouseFeature()
                   {
                       HouseId = 3,
                       FeatureId = 3,
                   },
                   new HouseFeature()
                   {
                       HouseId = 4,
                       FeatureId = 2,
                   },
                   new HouseFeature()
                   {
                       HouseId = 4,
                       FeatureId = 3,
                   },
                   new HouseFeature()
                   {
                       HouseId = 4,
                       FeatureId = 6,
                   },
                   new HouseFeature()
                   {
                       HouseId = 5,
                       FeatureId = 1,
                   },
                   new HouseFeature()
                   {
                       HouseId = 5,
                       FeatureId = 2,
                   },
                   new HouseFeature()
                   {
                       HouseId = 5,
                       FeatureId = 3,
                   },
                   new HouseFeature()
                   {
                       HouseId = 5,
                       FeatureId = 4,
                   },
                   new HouseFeature()
                   {
                       HouseId = 5,
                       FeatureId = 5,
                   },
                   new HouseFeature()
                   {
                       HouseId = 5,
                       FeatureId = 6,
                   },
                   new HouseFeature()
                   {
                       HouseId = 6,
                       FeatureId = 1,
                   },
                   new HouseFeature()
                   {
                       HouseId = 6,
                       FeatureId = 2,
                   },
                   new HouseFeature()
                   {
                       HouseId = 6,
                       FeatureId = 3,
                   },
                   new HouseFeature()
                   {
                       HouseId = 6,
                       FeatureId = 4,
                   },
                   new HouseFeature()
                   {
                       HouseId = 6,
                       FeatureId = 5,
                   },
                   new HouseFeature()
                   {
                       HouseId = 6,
                       FeatureId = 6,
                   },
                   new HouseFeature()
                   {
                       HouseId = 7,
                       FeatureId = 1,
                   },
                   new HouseFeature()
                   {
                       HouseId = 7,
                       FeatureId = 2,
                   },
                   new HouseFeature()
                   {
                       HouseId = 7,
                       FeatureId = 3,
                   },
                   new HouseFeature()
                   {
                       HouseId = 7,
                       FeatureId = 4,
                   },
                   new HouseFeature()
                   {
                       HouseId = 7,
                       FeatureId = 5,
                   },
                   new HouseFeature()
                   {
                       HouseId = 7,
                       FeatureId = 6,
                   }
                );
            modelBuilder.Entity<Feature>().HasData(
                new Feature()
                {
                    FeatureId = 1,
                    Name = "Garage"
                },
                new Feature()
                {
                    FeatureId = 2,
                    Name = "Yard"
                },
                new Feature()
                {
                    FeatureId = 3,
                    Name = "Garden"
                },
                new Feature()
                {
                    FeatureId = 4,
                    Name = "Swimming Pool"
                },
                new Feature()
                {
                    FeatureId = 5,
                    Name = "Terrace"
                },
                new Feature()
                {
                    FeatureId = 6,
                    Name = "Two or more floors"
                }
                );
            modelBuilder.Entity<Province>().HasData(
                new Province()
                {
                    ProvinceId = 1,
                    Name = "San Jose"
                },
                new Province()
                {
                    ProvinceId = 2,
                    Name = "Alajuela"
                },
                new Province()
                {
                    ProvinceId = 3,
                    Name = "Heredia"
                },
                new Province()
                {
                    ProvinceId = 4,
                    Name = "Cartago"
                },
                new Province()
                {
                    ProvinceId = 5,
                    Name = "Guanacaste"
                },
                new Province()
                {
                    ProvinceId = 6,
                    Name = "Limon"
                },
                new Province()
                {
                    ProvinceId = 7,
                    Name = "Puntarenas"
                }
                );

        }
    }
}