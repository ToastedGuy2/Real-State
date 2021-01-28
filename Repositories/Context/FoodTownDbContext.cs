using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Context
{
    public class FoodTownDbContext : IdentityDbContext<AppUser>
    {
        public FoodTownDbContext(DbContextOptions<FoodTownDbContext> options) : base(options)
        {
        }

        public DbSet<AppUserRole> AppUserRoles { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Item> Items { get; set; }

        public DbSet<Bill> Bill { get; set; }
        public DbSet<BillItem> BillItems { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Many to Many Relationships


            // Author to Order
            modelBuilder.Entity<AppUser>().
                HasOne(u => u.Order).
                WithOne(o => o.Client).
                HasForeignKey<Order>(o => o.ClientId).OnDelete(DeleteBehavior.NoAction); ;
            // Order - OrderItem - Item
            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.OrderId, oi.ItemId });

            modelBuilder.Entity<OrderItem>()
                .HasOne(oI => oI.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(bc => bc.OrderId).OnDelete(DeleteBehavior.NoAction);
            ;

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Item)
                .WithMany(p => p.Orders)
                .HasForeignKey(oi => oi.ItemId).OnDelete(DeleteBehavior.NoAction); ;
            ;

            // Bill - BillITem - Item
            modelBuilder.Entity<BillItem>()
                .HasKey(oi => new { oi.BillId, oi.ItemId });

            modelBuilder.Entity<BillItem>()
                .HasOne(bI => bI.Bill)
                .WithMany(b => b.Items)
                .HasForeignKey(bI => bI.ItemId).OnDelete(DeleteBehavior.NoAction); ;
            ;

            modelBuilder.Entity<BillItem>()
                .HasOne(bI => bI.Item)
                .WithMany(i => i.Bills)
                .HasForeignKey(oi => oi.BillId).OnDelete(DeleteBehavior.NoAction); ;
            ;

            modelBuilder
                .Entity<Category>()
                .HasMany(c => c.Items)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<Category>()
                .HasMany(c => c.Brands)
                .WithOne(b => b.Category)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<Item>()
                .HasOne(i => i.Brand)
                .WithMany(b => b.Items)
                .HasForeignKey(i => i.BrandId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<Category>()
                .HasMany(c => c.Items)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<AppUser>()
                .HasMany(u => u.Bills)
                .WithOne(b => b.Customer)
                .HasForeignKey(b => b.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
            .Entity<AppUser>()
            .HasMany(u => u.Addresses)
            .WithOne(a => a.Customer)
            .HasForeignKey(a => a.CustomerId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
            .Entity<AppUser>()
            .HasMany(u => u.CreditCards)
            .WithOne(c => c.Customer)
            .HasForeignKey(c => c.CustomerId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Category>().HasData(
                    new Category()
                    {
                        CategoryId = 1,
                        Name = "Fruits & Vegetables"
                    },
                    new Category()
                    {
                        CategoryId = 2,
                        Name = "Meat"
                    },
                    new Category()
                    {
                        CategoryId = 3,
                        Name = "Sea Food"
                    },
                    new Category()
                    {
                        CategoryId = 4,
                        Name = "Dairy"
                    },
                    new Category()
                    {
                        CategoryId = 5,
                        Name = "Grains"
                    },
                    new Category()
                    {
                        CategoryId = 6,
                        Name = "Oils"
                    }
                    );
            ///
            /// TODO: Remember to Finish all the Brands
            /// *With it's correct CategoryId
            /// PD: Maybe we should add 5 extra brands
            modelBuilder.Entity<Brand>()
            .HasData(
                    // Fruits and Vegetables
                    new Brand()
                    {
                        BrandId = 1,
                        Name = "The Fruit Company",
                        CategoryId = 1
                    },
                    new Brand()
                    {
                        BrandId = 2,
                        Name = "Harry & David",
                        CategoryId = 1
                    },
                    new Brand()
                    {
                        BrandId = 3,
                        Name = "A Gift Inside",
                        CategoryId = 1
                    },
                    // Meat
                    new Brand()
                    {
                        BrandId = 4,
                        Name = "Tyson Foods",
                        CategoryId = 2
                    },
                    new Brand()
                    {
                        BrandId = 5,
                        Name = "JBS S.A",
                        CategoryId = 2
                    },
                    new Brand()
                    {
                        BrandId = 6,
                        Name = "Cargill",
                        CategoryId = 2
                    },
                    // Sea Food
                    new Brand()
                    {
                        BrandId = 7,
                        Name = "SeaPak Shrimp & Seafood",
                        CategoryId = 3
                    },
                    new Brand()
                    {
                        BrandId = 8,
                        Name = "markfoods",
                        CategoryId = 3
                    },
                    new Brand()
                    {
                        BrandId = 9,
                        Name = "Inland Seafood",
                        CategoryId = 3
                    },

                    // Dairy
                    new Brand()
                    {
                        BrandId = 10,
                        Name = "Nestle",
                        CategoryId = 4
                    },
                    new Brand()
                    {
                        BrandId = 11,
                        Name = "Danone",
                        CategoryId = 4
                    }
                    ,
                    new Brand()
                    {
                        BrandId = 12,
                        Name = "Lactalis",
                        CategoryId = 4
                    }
                    // Grains
                    ,
                    new Brand()
                    {
                        BrandId = 13,
                        Name = "Lundberg Family Farms",
                        CategoryId = 5
                    }
                    ,
                    new Brand()
                    {
                        BrandId = 14,
                        Name = "Grain Miller",
                        CategoryId = 5
                    },
                    // Oils

                    new Brand()
                    {
                        BrandId = 16,
                        Name = "Plant Therapy",
                        CategoryId = 6
                    }

                    );
            // Item: Add Extra Items
            modelBuilder.Entity<Item>().HasData(
                // Fruits
                // The Fruit Company
                new Item()
                {
                    ItemId = 1,
                    Name = "Red Apple",
                    Price = 1.00,
                    Description = "They may have derived from Japan, but our Imperial Fuji Apples are 100% direct from our Pacific Northwest orchards! Their pretty pinkish flush over a yellow-green background with a crisp, juicy and refreshingly sweet flavor make these apples one of our customer-favorites! ",
                    CategoryId = 1,
                    BrandId = 1,
                    ImageName = "Red Apple(Fruit Company)_e92a8662-259f-4244-af3f-47db7b1dc34f",
                    IsItActive = true

                },
                new Item()
                {
                    ItemId = 2,
                    Name = "Orange",
                    Price = 0.50,
                    Description = "Bring the sunshine to your front door with these supremely sweet Valencia Oranges. Known as the ",
                    CategoryId = 1,
                    BrandId = 1,
                    ImageName = "Red Apple(Fruit Company)_e92a8662-259f-4244-af3f-47db7b1dc34f.jpeg",
                    IsItActive = true

                },
                new Item()
                {
                    ItemId = 3,
                    Name = "Pear",
                    Price = 0.75,
                    Description = "Get ready - we're about to reveal one of the best-kept secrets of pear-lovers. Our Forelle Mini Pears are extremely sugary, very juicy, and available only from October through late winter. With their bell-shaped body and attractive crimson freckling, a bowl of ripening Forelles makes a stunning edible centerpiece during the holidays and a perfect hostess gift for winter parties. ",
                    CategoryId = 1,
                    BrandId = 1,
                    ImageName = "Pear(Fruit Company)_9b4ac9f9-c2ad-4455-8a53-556fbe9846ac.jpeg",
                    IsItActive = true

                },
                // Harry & David
                new Item()
                {
                    ItemId = 4,
                    Name = "Pineapple",
                    Price = 0.50,
                    Description = "Can you just hear the crash of the ocean waves and feel the golden rays on your face? Our sun-ripened pineapples bring a taste of abundant juices and sweet mouth-tingling taste. So go ahead...invite your closest friends over for a tropical-themed party, with this pineapple as your centerpiece. ",
                    CategoryId = 1,
                    BrandId = 2,
                    ImageName = "Pineapple(Harry & David)_c378bd7f-248b-4f11-8caa-064c05f7e713.jpeg",
                    IsItActive = true

                },
                // A Gift Inside
                new Item()
                {
                    ItemId = 5,
                    Name = "Blueberries",
                    Price = 1.25,
                    Description = "Send fresh blueberries grown in our own Blueberry Fields in the foothills of beautiful Mount Hood. When harvest begins our blueberries will be picked the same day we ship them to you or your recipient to ensure the freshest berries available. Our expert gift designers will make sure your blueberries arrive delicious and gift-ready!",
                    CategoryId = 1,
                    BrandId = 3,
                    ImageName = "Blueberries(A Gift Inside)_50ff5c6d-7fab-42c6-b333-318df8605b91.jpeg",
                    IsItActive = true

                },
                // Meats
                // Tyson Foods
                new Item()
                {
                    ItemId = 6,
                    Name = "Beef",
                    Price = 20.00,
                    Description = "How did ancient civilizations fuel themselves to build pyramids or win sword battles? Meat. If it worked for them, Jack Link’s beef jerky can definitely help you power through a late day at work, tackle your honey-do list or fuel a workout. ",
                    CategoryId = 2,
                    BrandId = 4,
                    ImageName = "Beef(Tyson Foods)_21c4f102-5f81-4abb-b590-37230b154460.jpeg",
                    IsItActive = true

                },
                // JBS
                new Item()
                {
                    ItemId = 7,
                    Name = "Salami Genoa Charcuterie",
                    Price = 17.53,
                    Description = "Handmade Salami - Creminelli meats are handmade under the supervision of master artisan, Cristiano Creminelli. Cristiano insists on using choice cuts of meat from select breeds, fed with organic white grains, and raised on small family farms. ",
                    CategoryId = 2,
                    BrandId = 5,
                    ImageName = "Salami(JBS)_fee93094-c322-4d77-918a-b6ebd495235d.jpeg",
                    IsItActive = true

                },
                // Cargill
                new Item()
                {
                    ItemId = 8,
                    Name = "Chicken Breast",
                    Price = 23.99,
                    Description = "Pat LaFrieda's Boneless Chicken Thighs come from chickens raised on small, free range farms in Lancaster, Pennsylvania. Raised without antibiotics, these tender dark meat thighs are great for any time of year. ",
                    CategoryId = 2,
                    BrandId = 6,
                    ImageName = "Chicken(Cargill)_49297c08-8677-4ae2-b097-48e74d59a26d.jpeg",
                    IsItActive = true

                },
                new Item()
                {
                    ItemId = 9,
                    Name = "Turkey Breast Peppered Charcuterie",
                    Price = 13.29,
                    Description = "Fresh Fields, Turkey Breast Peppered Charcuterie ",
                    CategoryId = 2,
                    BrandId = 6,
                    ImageName = "Turkey(Cargill)_ae50ca7d-2b21-45e0-8fa4-401baa612ab0.jpeg",
                    IsItActive = true

                },
                new Item()
                {
                    ItemId = 10,
                    Name = "Ham",
                    Price = 9.99,
                    Description = "You only get one shot at living a great life. Better make it a good one! The best Items are made from the best ingredients. We carefully source all of our materials from farmers who share our belief that it’s worth the time, work, and effort to make things great. ",
                    CategoryId = 2,
                    BrandId = 6,
                    ImageName = "Ham(Cargill)_1cdd109f-7902-441d-8ab2-1ca75fb5bfd4.jpeg",
                    IsItActive = true

                },
                // Sea Food

                // SeaPak Shrimp & Seafood
                new Item()
                {
                    ItemId = 11,
                    Name = "Shrimp",
                    Price = 1.99,
                    Description = "Our seafood is traceable to farm or fishery, and we work hard to source it only from responsibly managed farms and sustainable wild fisheries.  ",
                    CategoryId = 4,
                    BrandId = 7,
                    ImageName = "Shrimp(SeaPak Shrimp & Seafood)_19a33b26-730f-459f-ba54-0cb085468cc2.jpeg",
                    IsItActive = true

                },
                // markfoods
                new Item()
                {
                    ItemId = 12,
                    Name = "Salmon",
                    Price = 5.99,
                    Description = "In the Whole Foods Market Seafood department, our rigorous standards help maintain healthy fish populations, protect ecosystems and build a more sustainable seafood supply for everyone. From sustainable wild-caught salmon to Responsibly Farmed shrimp, we do seafood better — and we mean it. ",
                    CategoryId = 4,
                    BrandId = 8,
                    ImageName = "Salmon(markfoods)_bbb5af69-69e6-4c7c-b5f1-819a8b350235.jpeg",
                    IsItActive = true

                },
                // Inland Seafood
                new Item()
                {
                    ItemId = 13,
                    Name = "Tuna",
                    Price = 4.72,
                    Description = "Whether you’re squeezing in lunch between meetings during a busy workday or want a quick, protein-packed snack between soccer practice, school and other daily errands, StarKist Chunk Light Tuna in Water is the perfect choice! Each of our 5 oz. tuna cans features wild caught tuna with a naturally mild flavor people have come to expect from StarKist Plus, it’s soy and gluten free and works well with Keto, Paleo, Whole30, Mediterranean and Weight Watchers diet plans! This packaged tuna is an excellent, natural source of protein and Omega 3s , and it has 20g of protein and 90 calories per can. Plus, it’s a great, quick and easy way to add seafood to your diet! Tuna is naturally lower in fat so it’s a wholesome way to add variety to your meals. Easy to store, you can stock up with this 48-Pack of tuna cans, and keep these tuna singles in your office, pantry at home and even in your diaper bag or car! An industry innovator, StarKist was the first brand to introduce StarKist single-serve pouch Items, which include Tuna, Salmon and Chicken Creations, and StarKist Selects E.V.O.O. As America’s favorite tuna*, StarKist represents a tradition of quality, consumer trust and a commitment to sustainability. ",
                    CategoryId = 4,
                    BrandId = 9,
                    ImageName = "Tuna(Inland Seafood)_bbb5af69-69e6-4c7c-b5f1-819a8b350235.jpeg",
                    IsItActive = true

                },
                //Dairy Items
                // Nestle
                new Item()
                {
                    ItemId = 14,
                    Name = "Milk",
                    Price = 2.99,
                    Description = "Our seafood is traceable to farm or fishery, and we work hard to source it only from responsibly managed farms and sustainable wild fisheries. ",
                    CategoryId = 4,
                    BrandId = 10,
                    ImageName = "Milk(Nestle)_19a33b26-730f-459f-ba54-0cb085468cc2.jpeg",
                    IsItActive = true

                },
                // Danone
                new Item()
                {
                    ItemId = 15,
                    Name = "Cheese",
                    Price = 1.50,
                    Description = "All cheeses from the Whole Foods Market Cheese department are exclusively selected and passionately sourced from farmers and producers around the world",
                    CategoryId = 4,
                    BrandId = 11,
                    ImageName = "Cheese(Danone)_bbb5af69-69e6-4c7c-b5f1-819a8b350235.jpeg",
                    IsItActive = true

                },
                new Item()
                {
                    ItemId = 16,
                    Name = "Yogurt",
                    Price = 2.99,
                    Description = "Our yogurts are made from real yogurt and absolutely no preservatives! We collect fresh milk from an exclusive network of farms and cows. The milk is pasteurized and cultures are added, transforming the milk into yogurt. Then the yogurt is cooled and real delicious fruit is added. Finally, the pouches are filled, sealed, and heat treated, so they’re shelf-stable. ",
                    CategoryId = 4,
                    BrandId = 11,
                    ImageName = "Yogurt(Danone)_070d168a-e7c6-439a-a847-8e09ea070a0f.jpeg",
                    IsItActive = true

                },
                // Lactalis
                new Item()
                {
                    ItemId = 17,
                    Name = "Butter",
                    Price = 1.99,
                    Description = "Our Ghee is made the old fashion way with nothing added to it, using only AA unsalted butter sourced from Wisconsin. Amber & Gold Ghee is a Go Texan certified Item because it is handmade in Magnolia, TX. Authenthic Ghee is scientifically proven to be the healthiest fat for the human body. It can replace any cooking oil or fat in the kitchen. ",
                    CategoryId = 4,
                    BrandId = 12,
                    ImageName = "Butter(Lactalis)_fd713ee4-bdce-446d-87b0-6881e1b8f3e9.jpeg",
                    IsItActive = true

                },
                // Grains
                // Lundberg Family Farms
                new Item()
                {
                    ItemId = 18,
                    Name = "Rice",
                    Price = 3.99,
                    Description = "Nature's Earthly Choice Cauliflower Rice",
                    CategoryId = 5,
                    BrandId = 13,
                    ImageName = "Rice(Lundberg Family Farms)_070d168a-e7c6-439a-a847-8e09ea070a0f.jpeg",
                    IsItActive = true

                },
                // Grain Miller
                new Item()
                {
                    ItemId = 19,
                    Name = "Beans",
                    Price = 2.99,
                    Description = "A favorite among black bean connoisseurs. Faraon Black Beans are carefully selected from the best crops available, consistently offering a true black bean color and authentic taste. When cooked, Faraon is sure to please with a wonderfully thick and delicious bean broth. Faraon brand is demanded by the most knowledgeable consumers. Enjoy!",
                    CategoryId = 5,
                    BrandId = 14,
                    ImageName = "Beans(Grain Miller)_fd713ee4-bdce-446d-87b0-6881e1b8f3e9.jpeg",
                    IsItActive = true

                },
                // Oils
                // Plant Therapy
                new Item()
                {
                    ItemId = 20,
                    Name = "Canola Oil",
                    Price = 6.99,
                    Description = "Canola Oil is light flavored, and great for cooking and frying",
                    CategoryId = 5,
                    BrandId = 14,
                    ImageName = "Canola Oil(Plant Therapy)_fd713ee4-bdce-446d-87b0-6881e1b8f3e9.jpeg",
                    IsItActive = true

                }
            );

            // modelBuilder.Entity<Category>().OnD

        }
    }
}