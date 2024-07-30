using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baskets_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StockCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BasketItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BasketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketItems_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductImageFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImageFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImageFiles_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenEndDate", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "813d7aae-92b6-42e4-8bfe-9f1bc37d8f93", "enes@seeddata.com", true, "Enes", "Ozmus", false, null, " ENES@SEEDDATA.COM", "ENESOZMUS", "AQAAAAIAAYagAAAAEMcxpC3nZXkr99wA7n/O0C2YB7b1FiPiha1xSV3tF4s2g+9fsRROiYbbe7nbxSiEOQ==", "0541 555 ####", false, null, null, "b71bf7d4-6ef1-40f6-91b7-6d88a55ff866", false, "enesozmus" },
                    { 2, 0, "2459ad57-558d-41b5-bcbe-8dc79381a8c3", "umay@seeddata.com", true, "Umay", "Zengin", false, null, "UMAY@SEEDDATA.COM", "UMAYZENGIN", "AQAAAAIAAYagAAAAEP2i+aX8EWSGePVKUD+IUIfiUH23Gk7i2Wdla1ZiuhdI+eyim4N2eNVt3hqQn89txA==", "0542 555 ####", false, null, null, "da6a6f5e-7af5-49c4-b998-bb8bfd1d29d7", false, "umayzengin" },
                    { 3, 0, "c4b959cc-7513-4a7e-9e88-ae7177471086", "selim@seeddata.com", true, "Selim", "Karaca", false, null, "SELIM@SEEDDATA.COM", "SELIMKARACA", "AQAAAAIAAYagAAAAEPpHJewAk//yghmvrWIMtMNVkdafoh0+KXk5v5GSOARV1ma7yNuBuPW8bynAGdb5nw==", "0543 555 ####", false, null, null, "60418131-57eb-48a0-8a6b-93fc833ec74a", false, "selimkaraca" },
                    { 4, 0, "6ee52f1e-cca5-4bbc-8b43-0732e5061140", "emine@seeddata.com", true, "Emine", "Yıldırım", false, null, "EMINE@SEEDDATA.COM", "EMINEYILDIRIM", "AQAAAAIAAYagAAAAEIjh/XoxoAvF94Fk+iFXTC6FV1zKyHpHTAeRFnXQpgO6F8kiBoxeBwMwTcIcXsOtYw==", "0544 555 ####", false, null, null, "01d28b3c-54ce-4483-9eb1-c7315527d89c", false, "emineyıldırım" },
                    { 5, 0, "80b1bf6e-e8c6-4170-bece-068dab0848d4", "ihsan@seeddata.com", true, "İhsan", "Yenilmez", false, null, "IHSAN@SEEDDATA.COM", "IHSANYENILMEZ", "AQAAAAIAAYagAAAAEEoTFNQSZ5+YwoFNuq0I+WARwpTewPMupu7mgmSEo5usPdQnc7+oGWWTfDH8yPa/hQ==", "0545 555 ####", false, null, null, "0e4ef23f-23a8-428e-b4aa-7e05df65d57c", false, "ihsanyenilmez" },
                    { 6, 0, "ec85de8b-69fd-4af2-a091-57cbd64daa19", "berrin@seeddata.com", true, "Berrin", "Miral", false, null, "BERRIN@SEEDDATA.COM", "BERRINMIRAL", "AQAAAAIAAYagAAAAEIJiLBACshtDlC/9+cdToKMHDWET90G/WhYN/HwXU/QCRvHJI4Xp5SfJLDGT7ZQ5/Q==", "0546 555 ####", false, null, null, "88220847-7fd0-410c-919a-9559181cd9b6", false, "berrinmiral" },
                    { 7, 0, "140d8cb8-5bf1-497a-8643-7609778b4f69", "salih@seeddata.com", true, "Salih", "Yurdakul", false, null, "SALIH@SEEDDATA.COM", "SALIHYURDAKUL", "AQAAAAIAAYagAAAAEFbr+A7PWdmTVooV83CDXeUd1z7REA45Bv7Slo53oIJdJdsrThYgxiHXYp4gFSK0Hw==", "0547 555 ####", false, null, null, "50730456-538c-4ae5-aeed-fbb84870a518", false, "salihyurdakul" },
                    { 8, 0, "2835250c-d783-4990-ace1-2c21aa841516", "zafer@seeddata.com", true, "Zafer", "Kırat", false, null, "ZAFER@SEEDDATA.COM", "ZAFERKIRAT", "AQAAAAIAAYagAAAAEJPeO3cpdGFeS7nBz13XxwS1PQyMUzSZttS+gWYZlHtwpA7Q5OgnWOEYuiYGQ8jUGg==", "0548 555 ####", false, null, null, "d1e4fecd-feed-4018-b0c5-13e2830370cd", false, "zaferkırat" },
                    { 9, 0, "4de011ad-1cc0-450a-8449-8a8aa7053eaa", "emre@seeddata.com", true, "Emre", "Demir", false, null, "EMRE@SEEDDATA.COM", "EMREDEMIR", "AQAAAAIAAYagAAAAEN8aIHbOhnVEBPhUgUiLjXWKwcCv3qUPQGQWOWBa42JASsZbn7x0jzSnr5RwZsbbIg==", "0549 555 ####", false, null, null, "52826d8e-dbce-417d-9d9a-500144da4478", false, "emredemir" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("097826be-7df8-4f27-bbec-a8dde4a62cad"), new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "DEFACTO" },
                    { new Guid("61b048b6-748c-43c8-babb-f046e55a7ebc"), new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "MANGO" },
                    { new Guid("741f3733-21a8-4341-83f7-c0a5037e600d"), new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "TRENDYOL" },
                    { new Guid("756d0d1b-abb1-4c9d-b152-95dcdebe470d"), new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "MAVİ" },
                    { new Guid("a7b58482-c640-4f47-b9b4-c50bfa8991c1"), new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "LCWAIKIKI" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("1f7e1c20-5eaf-4b96-810b-f343eb4a0f10"), new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hırka ve Süveter" },
                    { new Guid("5fdf9767-b009-46cb-ae71-c82b5640fa0e"), new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bluz" },
                    { new Guid("7545617e-40b9-49ad-b9a8-662957e54b41"), new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mont" },
                    { new Guid("812cb59b-7ef0-4e40-b3d9-ce4a977bd1aa"), new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sweatshirt" },
                    { new Guid("aa24bfeb-caf6-4ea5-ae4f-5fd1e3f56b9d"), new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kazak" },
                    { new Guid("ba3c4d6b-6968-4b7b-9b69-ad1502fe9eb4"), new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jean" },
                    { new Guid("cd1323b6-d564-44c1-a499-ea4dd4e6f577"), new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gömlek" },
                    { new Guid("e945ba38-842c-4d15-b9d6-77c6733a8028"), new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tişört" }
                });

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
                name: "IX_BasketItems_BasketId",
                table: "BasketItems",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ProductId",
                table: "BasketItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_AppUserId",
                table: "Baskets",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImageFiles_ProductId",
                table: "ProductImageFiles",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
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
                name: "BasketItems");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ProductImageFiles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
