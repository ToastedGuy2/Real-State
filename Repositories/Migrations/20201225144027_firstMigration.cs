using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUserRole",
                columns: table => new
                {
                    AppUserRoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRole", x => x.AppUserRoleId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    AppUserRoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AppUserRole_AppUserRoleId",
                        column: x => x.AppUserRoleId,
                        principalTable: "AppUserRole",
                        principalColumn: "AppUserRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    BrandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.BrandId);
                    table.ForeignKey(
                        name: "FK_Brand_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Province = table.Column<string>(nullable: false),
                    Canton = table.Column<string>(nullable: false),
                    District = table.Column<string>(nullable: false),
                    ExactAddress = table.Column<string>(nullable: false),
                    CustomerId = table.Column<string>(nullable: false),
                    IsItActive = table.Column<bool>(nullable: false),
                    Id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditCard",
                columns: table => new
                {
                    CreditCardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOnCard = table.Column<string>(nullable: false),
                    CreditCardNumber = table.Column<string>(maxLength: 16, nullable: false),
                    ExpirationDate = table.Column<string>(nullable: false),
                    CVV = table.Column<int>(maxLength: 3, nullable: false),
                    CustomerId = table.Column<string>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCard", x => x.CreditCardId);
                    table.ForeignKey(
                        name: "FK_CreditCard_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    BrandId = table.Column<int>(nullable: false),
                    ImageName = table.Column<string>(nullable: false),
                    IsItActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Item_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "BrandId");
                    table.ForeignKey(
                        name: "FK_Item_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    BillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<string>(nullable: false),
                    Date = table.Column<DateTimeOffset>(nullable: false),
                    CreditCardId = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    SubTotal = table.Column<double>(nullable: false),
                    Iva = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    Id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.BillId);
                    table.ForeignKey(
                        name: "FK_Bill_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bill_CreditCard_CreditCardId",
                        column: x => x.CreditCardId,
                        principalTable: "CreditCard",
                        principalColumn: "CreditCardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bill_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<string>(nullable: false),
                    AddressId = table.Column<int>(nullable: true),
                    CreditCardId = table.Column<int>(nullable: true),
                    Id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_CreditCard_CreditCardId",
                        column: x => x.CreditCardId,
                        principalTable: "CreditCard",
                        principalColumn: "CreditCardId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillItem",
                columns: table => new
                {
                    BillId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    SubTotal = table.Column<double>(nullable: false),
                    Iva = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillItem", x => new { x.BillId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_BillItem_Item_BillId",
                        column: x => x.BillId,
                        principalTable: "Item",
                        principalColumn: "ItemId");
                    table.ForeignKey(
                        name: "FK_BillItem_Bill_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Bill",
                        principalColumn: "BillId");
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    SubTotal = table.Column<double>(nullable: false),
                    Iva = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => new { x.OrderId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_OrderItem_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "ItemId");
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId");
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Fruits & Vegetables" },
                    { 2, "Meat" },
                    { 3, "Sea Food" },
                    { 4, "Dairy" },
                    { 5, "Grains" },
                    { 6, "Oils" }
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "BrandId", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "The Fruit Company" },
                    { 2, 1, "Harry & David" },
                    { 3, 1, "A Gift Inside" },
                    { 4, 2, "Tyson Foods" },
                    { 5, 2, "JBS S.A" },
                    { 6, 2, "Cargill" },
                    { 7, 3, "SeaPak Shrimp & Seafood" },
                    { 8, 3, "markfoods" },
                    { 9, 3, "Inland Seafood" },
                    { 10, 4, "Nestle" },
                    { 11, 4, "Danone" },
                    { 12, 4, "Lactalis" },
                    { 13, 5, "Lundberg Family Farms" },
                    { 14, 5, "Grain Miller" },
                    { 16, 6, "Plant Therapy" }
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "ItemId", "BrandId", "CategoryId", "Description", "ImageName", "IsItActive", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, 1, "They may have derived from Japan, but our Imperial Fuji Apples are 100% direct from our Pacific Northwest orchards! Their pretty pinkish flush over a yellow-green background with a crisp, juicy and refreshingly sweet flavor make these apples one of our customer-favorites! ", "Red Apple(Fruit Company)_e92a8662-259f-4244-af3f-47db7b1dc34f", true, "Red Apple", 1.0 },
                    { 18, 13, 5, "Nature's Earthly Choice Cauliflower Rice", "Rice(Lundberg Family Farms)_070d168a-e7c6-439a-a847-8e09ea070a0f.jpeg", true, "Rice", 3.9900000000000002 },
                    { 17, 12, 4, "Our Ghee is made the old fashion way with nothing added to it, using only AA unsalted butter sourced from Wisconsin. Amber & Gold Ghee is a Go Texan certified Item because it is handmade in Magnolia, TX. Authenthic Ghee is scientifically proven to be the healthiest fat for the human body. It can replace any cooking oil or fat in the kitchen. ", "Butter(Lactalis)_fd713ee4-bdce-446d-87b0-6881e1b8f3e9.jpeg", true, "Butter", 1.99 },
                    { 16, 11, 4, "Our yogurts are made from real yogurt and absolutely no preservatives! We collect fresh milk from an exclusive network of farms and cows. The milk is pasteurized and cultures are added, transforming the milk into yogurt. Then the yogurt is cooled and real delicious fruit is added. Finally, the pouches are filled, sealed, and heat treated, so they’re shelf-stable. ", "Yogurt(Danone)_070d168a-e7c6-439a-a847-8e09ea070a0f.jpeg", true, "Yogurt", 2.9900000000000002 },
                    { 15, 11, 4, "All cheeses from the Whole Foods Market Cheese department are exclusively selected and passionately sourced from farmers and producers around the world", "Cheese(Danone)_bbb5af69-69e6-4c7c-b5f1-819a8b350235.jpeg", true, "Cheese", 1.5 },
                    { 14, 10, 4, "Our seafood is traceable to farm or fishery, and we work hard to source it only from responsibly managed farms and sustainable wild fisheries. ", "Milk(Nestle)_19a33b26-730f-459f-ba54-0cb085468cc2.jpeg", true, "Milk", 2.9900000000000002 },
                    { 13, 9, 4, "Whether you’re squeezing in lunch between meetings during a busy workday or want a quick, protein-packed snack between soccer practice, school and other daily errands, StarKist Chunk Light Tuna in Water is the perfect choice! Each of our 5 oz. tuna cans features wild caught tuna with a naturally mild flavor people have come to expect from StarKist Plus, it’s soy and gluten free and works well with Keto, Paleo, Whole30, Mediterranean and Weight Watchers diet plans! This packaged tuna is an excellent, natural source of protein and Omega 3s , and it has 20g of protein and 90 calories per can. Plus, it’s a great, quick and easy way to add seafood to your diet! Tuna is naturally lower in fat so it’s a wholesome way to add variety to your meals. Easy to store, you can stock up with this 48-Pack of tuna cans, and keep these tuna singles in your office, pantry at home and even in your diaper bag or car! An industry innovator, StarKist was the first brand to introduce StarKist single-serve pouch Items, which include Tuna, Salmon and Chicken Creations, and StarKist Selects E.V.O.O. As America’s favorite tuna*, StarKist represents a tradition of quality, consumer trust and a commitment to sustainability. ", "Tuna(Inland Seafood)_bbb5af69-69e6-4c7c-b5f1-819a8b350235.jpeg", true, "Tuna", 4.7199999999999998 },
                    { 12, 8, 4, "In the Whole Foods Market Seafood department, our rigorous standards help maintain healthy fish populations, protect ecosystems and build a more sustainable seafood supply for everyone. From sustainable wild-caught salmon to Responsibly Farmed shrimp, we do seafood better — and we mean it. ", "Salmon(markfoods)_bbb5af69-69e6-4c7c-b5f1-819a8b350235.jpeg", true, "Salmon", 5.9900000000000002 },
                    { 11, 7, 4, "Our seafood is traceable to farm or fishery, and we work hard to source it only from responsibly managed farms and sustainable wild fisheries.  ", "Shrimp(SeaPak Shrimp & Seafood)_19a33b26-730f-459f-ba54-0cb085468cc2.jpeg", true, "Shrimp", 1.99 },
                    { 10, 6, 2, "You only get one shot at living a great life. Better make it a good one! The best Items are made from the best ingredients. We carefully source all of our materials from farmers who share our belief that it’s worth the time, work, and effort to make things great. ", "Ham(Cargill)_1cdd109f-7902-441d-8ab2-1ca75fb5bfd4.jpeg", true, "Ham", 9.9900000000000002 },
                    { 9, 6, 2, "Fresh Fields, Turkey Breast Peppered Charcuterie ", "Turkey(Cargill)_ae50ca7d-2b21-45e0-8fa4-401baa612ab0.jpeg", true, "Turkey Breast Peppered Charcuterie", 13.289999999999999 },
                    { 8, 6, 2, "Pat LaFrieda's Boneless Chicken Thighs come from chickens raised on small, free range farms in Lancaster, Pennsylvania. Raised without antibiotics, these tender dark meat thighs are great for any time of year. ", "Chicken(Cargill)_49297c08-8677-4ae2-b097-48e74d59a26d.jpeg", true, "Chicken Breast", 23.989999999999998 },
                    { 7, 5, 2, "Handmade Salami - Creminelli meats are handmade under the supervision of master artisan, Cristiano Creminelli. Cristiano insists on using choice cuts of meat from select breeds, fed with organic white grains, and raised on small family farms. ", "Salami(JBS)_fee93094-c322-4d77-918a-b6ebd495235d.jpeg", true, "Salami Genoa Charcuterie", 17.530000000000001 },
                    { 6, 4, 2, "How did ancient civilizations fuel themselves to build pyramids or win sword battles? Meat. If it worked for them, Jack Link’s beef jerky can definitely help you power through a late day at work, tackle your honey-do list or fuel a workout. ", "Beef(Tyson Foods)_21c4f102-5f81-4abb-b590-37230b154460.jpeg", true, "Beef", 20.0 },
                    { 5, 3, 1, "Send fresh blueberries grown in our own Blueberry Fields in the foothills of beautiful Mount Hood. When harvest begins our blueberries will be picked the same day we ship them to you or your recipient to ensure the freshest berries available. Our expert gift designers will make sure your blueberries arrive delicious and gift-ready!", "Blueberries(A Gift Inside)_50ff5c6d-7fab-42c6-b333-318df8605b91.jpeg", true, "Blueberries", 1.25 },
                    { 4, 2, 1, "Can you just hear the crash of the ocean waves and feel the golden rays on your face? Our sun-ripened pineapples bring a taste of abundant juices and sweet mouth-tingling taste. So go ahead...invite your closest friends over for a tropical-themed party, with this pineapple as your centerpiece. ", "Pineapple(Harry & David)_c378bd7f-248b-4f11-8caa-064c05f7e713.jpeg", true, "Pineapple", 0.5 },
                    { 3, 1, 1, "Get ready - we're about to reveal one of the best-kept secrets of pear-lovers. Our Forelle Mini Pears are extremely sugary, very juicy, and available only from October through late winter. With their bell-shaped body and attractive crimson freckling, a bowl of ripening Forelles makes a stunning edible centerpiece during the holidays and a perfect hostess gift for winter parties. ", "Pear(Fruit Company)_9b4ac9f9-c2ad-4455-8a53-556fbe9846ac.jpeg", true, "Pear", 0.75 },
                    { 2, 1, 1, "Bring the sunshine to your front door with these supremely sweet Valencia Oranges. Known as the ", "Red Apple(Fruit Company)_e92a8662-259f-4244-af3f-47db7b1dc34f.jpeg", true, "Orange", 0.5 },
                    { 19, 14, 5, "A favorite among black bean connoisseurs. Faraon Black Beans are carefully selected from the best crops available, consistently offering a true black bean color and authentic taste. When cooked, Faraon is sure to please with a wonderfully thick and delicious bean broth. Faraon brand is demanded by the most knowledgeable consumers. Enjoy!", "Beans(Grain Miller)_fd713ee4-bdce-446d-87b0-6881e1b8f3e9.jpeg", true, "Beans", 2.9900000000000002 },
                    { 20, 14, 5, "Canola Oil is light flavored, and great for cooking and frying", "Canola Oil(Plant Therapy)_fd713ee4-bdce-446d-87b0-6881e1b8f3e9.jpeg", true, "Canola Oil", 6.9900000000000002 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CustomerId",
                table: "Address",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AppUserRoleId",
                table: "AspNetUsers",
                column: "AppUserRoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_AddressId",
                table: "Bill",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_CreditCardId",
                table: "Bill",
                column: "CreditCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_CustomerId",
                table: "Bill",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BillItem_ItemId",
                table: "BillItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Brand_CategoryId",
                table: "Brand",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCard_CustomerId",
                table: "CreditCard",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_BrandId",
                table: "Item",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_CategoryId",
                table: "Item",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_AddressId",
                table: "Order",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ClientId",
                table: "Order",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_CreditCardId",
                table: "Order",
                column: "CreditCardId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ItemId",
                table: "OrderItem",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BillItem");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "CreditCard");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AppUserRole");
        }
    }
}
