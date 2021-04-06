using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Context
{
    public class RealStateDbContext : IdentityDbContext<AppUser>
    {
        public RealStateDbContext(DbContextOptions<RealStateDbContext> options) : base(options)
        {
        }

        public DbSet<House> Houses { get; set; }
        public DbSet<HouseFeature> HouseFeatures { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<HouseService> HouseServices { get; set; }
        public DbSet<Province> Provinces { get; set; }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceService> InvoiceServices { get; set; }
        public DbSet<Service> Services { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Refactor Identity Table Names
            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.ToTable(name: "User");
            });
            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
            // Many to Many Relationships


            // User

            // User to Invoice
            modelBuilder.Entity<AppUser>().
                HasMany(u => u.Invoices).
                WithOne(b => b.Customer).
                HasForeignKey(b => b.CustomerId).OnDelete(DeleteBehavior.NoAction); ;

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

            // Invoice - InvoiceService - Service
            modelBuilder.Entity<InvoiceService>()
                .HasKey(bS => new { bS.InvoiceId, bS.ServiceId });

            modelBuilder.Entity<InvoiceService>()
                .HasOne(bS => bS.Invoice)
                .WithMany(b => b.Services)
                .HasForeignKey(bS => bS.InvoiceId).OnDelete(DeleteBehavior.NoAction); ;
            ;

            modelBuilder.Entity<InvoiceService>()
                .HasOne(bS => bS.Service)
                .WithMany(s => s.Invoices)
                .HasForeignKey(bs => bs.ServiceId).OnDelete(DeleteBehavior.NoAction); ;
            ;

            // Service
            //Build - BuildService - Service
            // Invoice - InvoiceService - Service
            modelBuilder.Entity<HouseService>()
                .HasKey(bS => new { bS.HouseId, bS.ServiceId });

            modelBuilder.Entity<HouseService>()
                .HasOne(bS => bS.House)
                .WithMany(b => b.Services)
                .HasForeignKey(bS => bS.HouseId).OnDelete(DeleteBehavior.NoAction); ;
            ;
            modelBuilder.Entity<HouseService>()
                .HasOne(bS => bS.Service)
                .WithMany(s => s.Houses)
                .HasForeignKey(bs => bs.ServiceId).OnDelete(DeleteBehavior.NoAction); ;
            ;

            modelBuilder.Entity<House>().HasData(
                new House()
                {
                    HouseId = 1,
                    Name = "House #1",
                    Price = 200,
                    Description = "Sex reached suppose our whether. Oh really by an manner sister so. One sportsman tolerably him extensive put she immediate. He abroad of cannot looked in. Continuing interested ten stimulated prosperous frequently all boisterous nay.",
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
                    Price = 250,
                    Description = "Extremity direction existence as dashwoods do up. Securing marianne led welcomed offended but offering six raptures. Conveying concluded newspaper rapturous oh at. Two indeed suffer saw beyond far former mrs remain.",
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
                    Price = 300,
                    Description = "And produce say the ten moments parties. Simple innate summer fat appear basket his desire joy. Outward clothes promise at gravity do excited. Sufficient particular impossible by reasonable oh expression is. ",
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
                    Price = 500,
                    Description = "His followed carriage proposal entrance directly had elegance. Greater for cottage gay parties natural. Remaining he furniture on he discourse suspected perpetual. Power dried her taken place day ought the. Four and our ham west miss. ",
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
                    Price = 660,
                    Description = "Affronting everything discretion men now own did. Still round match we to. Frankness pronounce daughters remainder extensive has but. Happiness cordially one determine concluded fat. Plenty season beyond by hardly giving of. ",
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
                    Price = 420,
                    Description = "Four and our ham west miss. Education shameless who middleton agreement how. We in found world chief is at means weeks smile. ",
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
                    Price = 600,
                    Description = "Discovered her his pianoforte insipidity entreaties. Began he at terms meant as fancy. Breakfast arranging he if furniture we described on. Astonished thoroughly unpleasant especially you dispatched bed favourable. ",
                    Bathrooms = 2,
                    Bedrooms = 4,
                    Size = 260,
                    IsItAvailable = true,
                    ProvinceId = 7,
                    ImageName = "House7.jpeg"
                },
                new House()
                {
                    HouseId = 8,
                    Name = "House #8",
                    Price = 430,
                    Description = "Astonished thoroughly unpleasant especially you dispatched bed favourable.",
                    Bathrooms = 1,
                    Bedrooms = 2,
                    Size = 200,
                    IsItAvailable = true,
                    ProvinceId = 1,
                    ImageName = "House8.jpg"
                },
                new House()
                {
                    HouseId = 9,
                    Name = "House #9",
                    Price = 290,
                    Description = "Astonished thoroughly unpleasant especially you dispatched bed favourable.",
                    Bathrooms = 2,
                    Bedrooms = 3,
                    Size = 300,
                    IsItAvailable = true,
                    ProvinceId = 2,
                    ImageName = "House9.jpg"
                },
                new House()
                {
                    HouseId = 10,
                    Name = "House #10",
                    Price = 265,
                    Description = "Discovered her his pianoforte insipidity entreaties.",
                    Bathrooms = 2,
                    Bedrooms = 3,
                    Size = 1223,
                    IsItAvailable = true,
                    ProvinceId = 3,
                    ImageName = "House10.jpg"
                }, new House()
                {
                    HouseId = 11,
                    Name = "House #11",
                    Price = 400,
                    Description = "We in found world chief is at means weeks smile.",
                    Bathrooms = 2,
                    Bedrooms = 4,
                    Size = 1223,
                    IsItAvailable = true,
                    ProvinceId = 4,
                    ImageName = "House11.jpg"
                }, new House()
                {
                    HouseId = 12,
                    Name = "House #12",
                    Price = 400,
                    Description = "Four and our ham west miss. Education shameless who middleton agreement how.",
                    Bathrooms = 1,
                    Bedrooms = 4,
                    Size = 1111,
                    IsItAvailable = true,
                    ProvinceId = 5,
                    ImageName = "House12.jpg"
                }, new House()
                {
                    HouseId = 13,
                    Name = "House #13",
                    Price = 300,
                    Description = "Four and our ham west miss. Education shameless who middleton agreement how.",
                    Bathrooms = 1,
                    Bedrooms = 4,
                    Size = 123,
                    IsItAvailable = true,
                    ProvinceId = 5,
                    ImageName = "House13.jpg"
                }, new House()
                {
                    HouseId = 14,
                    Name = "House #14",
                    Price = 300,
                    Description = "Four and our ham west miss. Education shameless who middleton agreement how.",
                    Bathrooms = 2,
                    Bedrooms = 5,
                    Size = 325,
                    IsItAvailable = true,
                    ProvinceId = 6,
                    ImageName = "House14.jpg"
                }, new House()
                {
                    HouseId = 15,
                    Name = "House #15",
                    Price = 1200,
                    Description = "Four and our ham west miss. Education shameless who middleton agreement how.",
                    Bathrooms = 2,
                    Bedrooms = 5,
                    Size = 100,
                    IsItAvailable = true,
                    ProvinceId = 7,
                    ImageName = "House15.jpg"
                }
                );

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
                   },
                   new HouseFeature()
                   {
                       HouseId = 8,
                       FeatureId = 1,
                   },
                   new HouseFeature()
                   {
                       HouseId = 8,
                       FeatureId = 2,
                   },
                   new HouseFeature()
                   {
                       HouseId = 8,
                       FeatureId = 3,
                   },
                   new HouseFeature()
                   {
                       HouseId = 8,
                       FeatureId = 4,
                   },
                   new HouseFeature()
                   {
                       HouseId = 8,
                       FeatureId = 5,
                   },
                   new HouseFeature()
                   {
                       HouseId = 8,
                       FeatureId = 6,
                   }
                   ,
                   new HouseFeature()
                   {
                       HouseId = 9,
                       FeatureId = 1,
                   },
                   new HouseFeature()
                   {
                       HouseId = 9,
                       FeatureId = 2,
                   },
                   new HouseFeature()
                   {
                       HouseId = 9,
                       FeatureId = 5,
                   },
                   new HouseFeature()
                   {
                       HouseId = 9,
                       FeatureId = 6,
                   }
                    ,
                   new HouseFeature()
                   {
                       HouseId = 10,
                       FeatureId = 1,
                   },
                   new HouseFeature()
                   {
                       HouseId = 10,
                       FeatureId = 2,
                   },
                   new HouseFeature()
                   {
                       HouseId = 10,
                       FeatureId = 5,
                   },
                   new HouseFeature()
                   {
                       HouseId = 10,
                       FeatureId = 6,
                   }
                    ,
                   new HouseFeature()
                   {
                       HouseId = 11,
                       FeatureId = 1,
                   },
                   new HouseFeature()
                   {
                       HouseId = 11,
                       FeatureId = 2,
                   },
                   new HouseFeature()
                   {
                       HouseId = 11,
                       FeatureId = 4,
                   },
                   new HouseFeature()
                   {
                       HouseId = 11,
                       FeatureId = 6,
                   }
                    ,
                   new HouseFeature()
                   {
                       HouseId = 12,
                       FeatureId = 2,
                   },
                   new HouseFeature()
                   {
                       HouseId = 12,
                       FeatureId = 3,
                   },
                   new HouseFeature()
                   {
                       HouseId = 12,
                       FeatureId = 5,
                   },
                   new HouseFeature()
                   {
                       HouseId = 12,
                       FeatureId = 6,
                   }
                    ,
                   new HouseFeature()
                   {
                       HouseId = 13,
                       FeatureId = 1,
                   },
                   new HouseFeature()
                   {
                       HouseId = 13,
                       FeatureId = 2,
                   },
                   new HouseFeature()
                   {
                       HouseId = 13,
                       FeatureId = 3,
                   },
                   new HouseFeature()
                   {
                       HouseId = 13,
                       FeatureId = 4,
                   }
                    ,
                   new HouseFeature()
                   {
                       HouseId = 14,
                       FeatureId = 3,
                   },
                   new HouseFeature()
                   {
                       HouseId = 14,
                       FeatureId = 4,
                   },
                   new HouseFeature()
                   {
                       HouseId = 14,
                       FeatureId = 5,
                   },
                   new HouseFeature()
                   {
                       HouseId = 14,
                       FeatureId = 6,
                   },
                   new HouseFeature()
                   {
                       HouseId = 15,
                       FeatureId = 1,
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
            modelBuilder.Entity<Service>().HasData(
                new Service()
                {
                    ServiceId = 1,
                    Name = "Surveillance 24/7",
                    Price = 60,
                    Description = "lorem ipsum"
                },
                new Service()
                {
                    ServiceId = 2,
                    Name = "Swimming Pool Maintenance",
                    Price = 26,
                    Description = "lorem ipsum"
                },
                new Service()
                {
                    ServiceId = 3,
                    Name = "Garden",
                    Price = 50,
                    Description = "lorem ipsum"
                },
                new Service()
                {
                    ServiceId = 4,
                    Name = "House Insurance",
                    Price = 60,
                    Description = "lorem ipsum"
                },
                new Service()
                {
                    ServiceId = 5,
                    Name = "Solar Panels",
                    Price = 18,
                    Description = "lorem ipsum"
                }
                );
            modelBuilder.Entity<HouseService>().HasData(
               new HouseService()
               {
                   HouseId = 1,
                   ServiceId = 3,
               },
               new HouseService()
               {
                   HouseId = 2,
                   ServiceId = 4,
               },
               new HouseService()
               {
                   HouseId = 3,
                   ServiceId = 1,
               },
               new HouseService()
               {
                   HouseId = 3,
                   ServiceId = 2,
               },
               new HouseService()
               {
                   HouseId = 3,
                   ServiceId = 3
               },
               new HouseService()
               {
                   HouseId = 4,
                   ServiceId = 1,
               },
               new HouseService()
               {
                   HouseId = 4,
                   ServiceId = 2,
               },
               new HouseService()
               {
                   HouseId = 4,
                   ServiceId = 3,
               },
               new HouseService()
               {
                   HouseId = 4,
                   ServiceId = 4
               },
               new HouseService()
               {
                   HouseId = 5,
                   ServiceId = 1,
               },
               new HouseService()
               {
                   HouseId = 5,
                   ServiceId = 2,
               },
               new HouseService()
               {
                   HouseId = 5,
                   ServiceId = 3,
               },
               new HouseService()
               {
                   HouseId = 5,
                   ServiceId = 4
               },
               new HouseService()
               {
                   HouseId = 5,
                   ServiceId = 5,
               },
               new HouseService()
               {
                   HouseId = 6,
                   ServiceId = 1,
               },
               new HouseService()
               {
                   HouseId = 6,
                   ServiceId = 2,
               },
               new HouseService()
               {
                   HouseId = 6,
                   ServiceId = 3,
               },
               new HouseService()
               {
                   HouseId = 6,
                   ServiceId = 4
               },
               new HouseService()
               {
                   HouseId = 6,
                   ServiceId = 5,
               },
               new HouseService()
               {
                   HouseId = 7,
                   ServiceId = 1,
               },
               new HouseService()
               {
                   HouseId = 7,
                   ServiceId = 2,
               },
               new HouseService()
               {
                   HouseId = 7,
                   ServiceId = 3,
               },
               new HouseService()
               {
                   HouseId = 7,
                   ServiceId = 4
               },
               new HouseService()
               {
                   HouseId = 7,
                   ServiceId = 5,
               },
               new HouseService()
               {
                   HouseId = 8,
                   ServiceId = 1,
               },
               new HouseService()
               {
                   HouseId = 9,
                   ServiceId = 2,
               },
               new HouseService()
               {
                   HouseId = 10,
                   ServiceId = 3,
               },
               new HouseService()
               {
                   HouseId = 10,
                   ServiceId = 4
               },
               new HouseService()
               {
                   HouseId = 11,
                   ServiceId = 5,
               }
               ,
               new HouseService()
               {
                   HouseId = 12,
                   ServiceId = 2,
               },
               new HouseService()
               {
                   HouseId = 12,
                   ServiceId = 3,
               },
               new HouseService()
               {
                   HouseId = 12,
                   ServiceId = 4
               },
               new HouseService()
               {
                   HouseId = 12,
                   ServiceId = 5,
               }
               ,
               new HouseService()
               {
                   HouseId = 13,
                   ServiceId = 4,
               },
               new HouseService()
               {
                   HouseId = 13,
                   ServiceId = 5,
               },
               new HouseService()
               {
                   HouseId = 14,
                   ServiceId = 1
               },
               new HouseService()
               {
                   HouseId = 15,
                   ServiceId = 2,
               }
            );

        }
    }
}