using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BranchName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    ImageId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    OrderState = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Graduation = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adverts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    BranchId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adverts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adverts_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adverts_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherBranches",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    BranchId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherBranches", x => new { x.TeacherId, x.BranchId });
                    table.ForeignKey(
                        name: "FK_TeacherBranches_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherBranches_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherStudents",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherStudents", x => new { x.TeacherId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_TeacherStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherStudents_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AdvertId = table.Column<int>(type: "INTEGER", nullable: false),
                    CartId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    AdvertId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: true),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3182b0af-9c8b-4b85-9ca2-e515aa9c07cb", null, "Öğrenciler", "Ogrenci", "OGRENCI" },
                    { "5d26f66f-2b0b-4516-99b2-d41133b08d86", null, "Yöneticiler", "Admin", "ADMIN" },
                    { "eae1d03d-c1d5-4416-823d-038f86183653", null, "Öğretmenler", "Ogretmen", "OGRETMEN" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "BranchName", "CreatedDate", "Description", "IsApproved", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, "Matematik", new DateTime(2023, 5, 13, 16, 24, 47, 838, DateTimeKind.Local).AddTicks(8894), "Üniversite Düzeyinde Matematik Dersleri", true, new DateTime(2023, 5, 13, 16, 24, 47, 838, DateTimeKind.Local).AddTicks(8899), "matematik" },
                    { 2, "Analiz", new DateTime(2023, 5, 13, 16, 24, 47, 838, DateTimeKind.Local).AddTicks(8903), "Analiz 1-2-3-4 Dersleri", true, new DateTime(2023, 5, 13, 16, 24, 47, 838, DateTimeKind.Local).AddTicks(8904), "analiz" },
                    { 3, "İstatistik", new DateTime(2023, 5, 13, 16, 24, 47, 838, DateTimeKind.Local).AddTicks(8905), "Üniversite Düzeyinde İstatistik Dersleri", true, new DateTime(2023, 5, 13, 16, 24, 47, 838, DateTimeKind.Local).AddTicks(8906), "istatistik" },
                    { 4, "Analitik Geometri", new DateTime(2023, 5, 13, 16, 24, 47, 838, DateTimeKind.Local).AddTicks(8907), "Üniversite Düzeyinde Analitik Dersleri", true, new DateTime(2023, 5, 13, 16, 24, 47, 838, DateTimeKind.Local).AddTicks(8908), "analitik-geometri" },
                    { 5, "Oyun Teorisi", new DateTime(2023, 5, 13, 16, 24, 47, 838, DateTimeKind.Local).AddTicks(8909), "Oyun Teorisi 1-2-3-4 Dersleri", true, new DateTime(2023, 5, 13, 16, 24, 47, 838, DateTimeKind.Local).AddTicks(8910), "oyun-teorisi" },
                    { 6, "Bilgisayar Programcılığı", new DateTime(2023, 5, 13, 16, 24, 47, 838, DateTimeKind.Local).AddTicks(8912), "C# , Python , Java Dersleri", true, new DateTime(2023, 5, 13, 16, 24, 47, 838, DateTimeKind.Local).AddTicks(8912), "bilgisayar-programciligi" },
                    { 7, "Algoritmalar", new DateTime(2023, 5, 13, 16, 24, 47, 838, DateTimeKind.Local).AddTicks(8914), "Algoritmalar 1-2 dersleri verilir.", true, new DateTime(2023, 5, 13, 16, 24, 47, 838, DateTimeKind.Local).AddTicks(8914), "algoritmalar" },
                    { 8, "Bilgisayar Mimarisi", new DateTime(2023, 5, 13, 16, 24, 47, 838, DateTimeKind.Local).AddTicks(8916), "Bilgisayar Mimarisi 1-2 dersleri verilir.", true, new DateTime(2023, 5, 13, 16, 24, 47, 838, DateTimeKind.Local).AddTicks(8917), "bilgisayar-mimarisi" },
                    { 9, "Soyut Matematik", new DateTime(2023, 5, 13, 16, 24, 47, 838, DateTimeKind.Local).AddTicks(8918), "Soyut Matematik 1-2-3-4 dersleri verilir.", true, new DateTime(2023, 5, 13, 16, 24, 47, 838, DateTimeKind.Local).AddTicks(8919), "soyut-matematik" },
                    { 10, "Matlab", new DateTime(2023, 5, 13, 16, 24, 47, 838, DateTimeKind.Local).AddTicks(8920), "Matlab 1-2 dersleri verilir.", true, new DateTime(2023, 5, 13, 16, 24, 47, 838, DateTimeKind.Local).AddTicks(8921), "matlab" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 13, 16, 24, 47, 839, DateTimeKind.Local).AddTicks(7154), true, new DateTime(2023, 5, 13, 16, 24, 47, 839, DateTimeKind.Local).AddTicks(7159), "teacher-1.jpg" },
                    { 2, new DateTime(2023, 5, 13, 16, 24, 47, 839, DateTimeKind.Local).AddTicks(7160), true, new DateTime(2023, 5, 13, 16, 24, 47, 839, DateTimeKind.Local).AddTicks(7161), "teacher-2.jpg" },
                    { 3, new DateTime(2023, 5, 13, 16, 24, 47, 839, DateTimeKind.Local).AddTicks(7162), true, new DateTime(2023, 5, 13, 16, 24, 47, 839, DateTimeKind.Local).AddTicks(7162), "teacher-3.jpg" },
                    { 4, new DateTime(2023, 5, 13, 16, 24, 47, 839, DateTimeKind.Local).AddTicks(7163), true, new DateTime(2023, 5, 13, 16, 24, 47, 839, DateTimeKind.Local).AddTicks(7164), "teacher-4.jpg" },
                    { 5, new DateTime(2023, 5, 13, 16, 24, 47, 839, DateTimeKind.Local).AddTicks(7165), true, new DateTime(2023, 5, 13, 16, 24, 47, 839, DateTimeKind.Local).AddTicks(7165), "resimyok.jpg" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "ImageId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "007a6943-e32f-45ff-831a-8495521f0bd8", 0, "Bursa", "e8d8f0fa-c686-47a5-b142-d0d29e216fe7", new DateTime(2009, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehmetkaya@hotmail.com", true, "Mehmet", "Erkek", 5, "Kaya", false, null, "MEHMETKAYA@HOTMAIL.COM", "MEHMETKAYA", "AQAAAAIAAYagAAAAEFsxM3lzJ5S4HFQAZkgPsUEpqPaJYZa+n/j2FKBroWfBoAGVJxtYGFYmWgn0bNRO4g==", "5396542513", null, false, "c797188f-1531-4a5a-9e31-d80acce6efd4", false, "mehmetkaya" },
                    { "018770f5-96dc-4b2e-a708-cfed11f446b0", 0, "İstanbul", "a96d5efc-4a97-48a5-a071-81ff0b4713d1", new DateTime(2008, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "esraaydin@hotmail.com", true, "Esra", "Kadın", 5, "Aydın", false, null, "ESRAAYDIN@HOTMAIL.COM", "ESRAAYDIN", "AQAAAAIAAYagAAAAEFfWfrWageKQf/qHgsUhuibjmTk+3Tm6H12Guy7ukNO7OOHJ3HK2gm4mOqgUf1PCtA==", "5397891234", null, false, "574c1e4b-0620-408a-88cf-2fa4c363742c", false, "esraaydin" },
                    { "02fd7a75-988b-47aa-882f-7005f7ec1d34", 0, "Bursa", "454f2877-8f05-4fb7-8c62-be92c54025bf", new DateTime(1980, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "selinkar@hotmail.com", true, "Selin", "Kadın", 1, "Kar", false, null, "SELINKAR@HOTMAIL.COM", "SELINKAR", "AQAAAAIAAYagAAAAEKma0XzWlUIWGrjgymogXTfPcii0QIgjGdh+RGJHAebBErOpIJ6NFpOwVL/2enZD7A==", "5399782513", null, false, "91113eee-da84-4a0e-83c4-25b94b109a69", false, "selinkar" },
                    { "0e8d7b3b-9eb0-4d07-b0e9-7d86d02ee953", 0, "İstanbul", "ba7e1b22-f74b-4260-bfd0-3ac2856bd8f1", new DateTime(1992, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "esraaydin@hotmail.com", true, "Şevval", "Kadın", 3, "Demir", false, null, "sevval.demir@hotmail.com", "SEVVALDEMIR", "AQAAAAIAAYagAAAAEEW0h4O97BfpMafoelUZHVON89aS30jrQyvQ10HTtqNkKUPSumonuGhw5LTqJXD5ww==", "5387891234", null, false, "3c324cd4-a93d-4f43-bba0-93b75d4f1bb4", false, "sevvaldemir" },
                    { "1754aa6b-9727-4bdf-ade0-7b5fa99a300f", 0, "Adana", "22167b14-2cfd-4e6c-9105-9cd2de8186d3", new DateTime(1990, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "gokhan.aydin@gmail.com", true, "Gökhan", "Erkek", 5, "Aydın", false, null, "GOKHAN.AYDIN@GMAIL.COM", "GOKHANAYDIN", "AQAAAAIAAYagAAAAEOxkQtB2i8F7kedBzTQh6rB+CZGO8LVPRbj8mzkgiLjSfFKvm2yV+wsStGPDiLpHOw==", "5321234567", null, false, "68219fdd-850e-4a4c-b284-d5983412fd5f", false, "gokhanaydin" },
                    { "1a3110df-5cdf-4b46-80ff-402c0228c23c", 0, "İzmir", "b513852f-fe5d-46a2-b86c-e346edb0c967", new DateTime(2001, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "ayse.demir@yahoo.com", true, "Ayşe", "Kadın", 5, "Demir", false, null, "AYSE.DEMIR@YAHOO.COM", "AYSEDEMIR", "AQAAAAIAAYagAAAAEND3EQJM77p5qcfcHsOhudfYcyrCIPmr6QhCV1Z6aDjVuCk5Ldf7/m5AZ450ykeb9g==", "5329876543", null, false, "43d9227a-eae9-4c2e-a5d6-87f4faaed15e", false, "aysedemir" },
                    { "288292d3-c958-412e-b541-41d63c62ced1", 0, "Antalya", "54b3ef10-2f24-4755-a239-1dc78b3b453f", new DateTime(2009, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "mustafaozkan@gmail.com", true, "Mustafa", "Erkek", 5, "Özkan", false, null, "MUSTAFAOZKAN@GMAIL.COM", "MUSTAFAOZKAN", "AQAAAAIAAYagAAAAEHRBICoCEG6UqeHyrXb27lgxu7Bs7LLmRLPr4L9UXw/vpFWMrb59L/9W9TrFEyyfuA==", "5423456789", null, false, "3da79c08-59f3-4403-8d52-1f77e0cff389", false, "mustafaozkan" },
                    { "309ddd20-a098-4df6-ba4c-86a9d72f9a49", 0, "Bursa", "6614aade-a873-42d5-8465-054388de4767", new DateTime(1992, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "seyma.yilmaz@hotmail.com", true, "Şeyma", "Kadın", 5, "Yılmaz", false, null, "SEYMA.YILMAZ@HOTMAIL.COM", "SEYMAYILMAZ", "AQAAAAIAAYagAAAAEPmF6EUx2mPMMnFZC2DMAJ/2yGwz5Kx/a+LBHrG3dzR6i35rRSLq6Lja+rC8Dm8nbg==", "5399876543", null, false, "f97aa087-5200-4272-bfce-cb755c208efb", false, "seymayilmaz" },
                    { "32d5a47e-b95c-49f2-87dd-e6bc21c6da2f", 0, "İzmir", "a9311ad2-9b2d-4f6e-b001-dd815d53021a", new DateTime(1994, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehmet.yildiz@gmail.com", true, "Mehmet", "Erkek", 4, "Yıldız", false, null, "MEHMET.YILDIZ@GMAIL.COM", "MEHMETYILDIZ", "AQAAAAIAAYagAAAAEMEQVryAmYVunM+3X7NhHRtScBd9bS2jYWpejska2Ds7Q7UiW/nann68vgzdayyw9w==", "5336549876", null, false, "b8a44f6d-c8ef-4ffc-9189-aa8d2304b8f9", false, "mehmetyildiz" },
                    { "6995048a-a055-4e6e-9ad1-6826c195cbef", 0, "İzmir", "dc485f14-cca1-41f4-8f9d-fda4e9bfef7e", new DateTime(2007, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ali.yildiz@gmail.com", true, "Ali", "Erkek", 5, "Yıldız", false, null, "ALI.YILDIZ@GMAIL.COM", "ALIYILDIZ", "AQAAAAIAAYagAAAAEMQpaji7wBX6LA+shEjlh5DH1T25s3OUdoK9DjZKPA9CpWW5I/+DdR/8NdP5np6uug==", "5559876543", null, false, "d25a412e-0a2a-4e73-9361-3c62e88bc458", false, "aliyildiz" },
                    { "6f90465e-7fff-4216-8a76-34e7b278e735", 0, "Kayseri", "16e21e62-cab0-4ea2-87e2-a760e2ffe468", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "kemal.kaya@gmail.com", true, "Kemal", "Erkek", 5, "Kaya", false, null, "KEMAL.KAYA@GMAIL.COM", "KEMALKAYA", "AQAAAAIAAYagAAAAEGA+oB9NjPOBnKqboBfkQHj85jIES6JbjZ7D3W44b6NB9cq3VNL8RLOMbV1otTybiQ==", "5359876543", null, false, "f1c92567-b7c0-43d9-b727-fa363fab511a", false, "kemalkaya" },
                    { "728d8571-f0b8-4eea-adac-43f7951505c2", 0, "Ankara", "26d3409a-f6a4-4229-8add-fcb8630c16c5", new DateTime(1990, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "cem.yilmaz@gmail.com", true, "Cem", "Erkek", 2, "Yılmaz", false, null, "CEM.YILMAZ@GMAIL.COM", "CEMYILMAZ", "AQAAAAIAAYagAAAAECaQHP1Y+UEsDP0r7JO3/VGSmTIDqGuCUFvSFWqLG6MZSdwXa1zS3Azl45C91FRW1Q==", "5323456789", null, false, "1555bf08-e726-48ee-b57f-f36fb523e781", false, "cemyilmaz" },
                    { "90c70b96-a9a7-47fd-a5b9-8a1cc1bd3cbd", 0, "Adana", "ea5e1c8a-2fcd-44b9-9acd-3c8fdd3eda61", new DateTime(2003, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "fatmasahin@gmail.com", true, "Fatma", "Kadın", 5, "Şahin", false, null, "FATMASAHIN@GMAIL.COM", "FATMASAHIN", "AQAAAAIAAYagAAAAEANJ9crRD3aB8nqkMHmjFO3NQebTcXq1/rJNqY6tms6k86wOLECW9rI0MF0dyZdS/w==", "5334567890", null, false, "5409e8f6-a40c-4a39-92ce-e7b9d4cb2f0c", false, "fatmasahin" },
                    { "c31f8d49-9a12-4f19-a03d-c358594cd9b6", 0, "İstanbul", "ee5bf134-8d94-4898-b22f-bb871cfaa16b", new DateTime(2000, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "erdiutku@hotmail.com", true, "Erdi", "Erkek", 5, "Utku", false, null, "ERDIUTKU@HOTMAIL.COM", "ERDIUTKU", "AQAAAAIAAYagAAAAEPry4lZwmM306HwX/d7XoqeMDNhVQyEZJQrAn00vxD40GGl7N6ImfAx/3g4GPFP/6g==", "5555555555", null, false, "93babc73-af7f-44f1-a319-e6bb68e0982b", false, "erdiutku" },
                    { "cb76beb4-41d5-4904-9493-fd67702781b2", 0, "Ankara", "c8a61003-adf9-413d-9ab8-5da246df92b2", new DateTime(2002, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmetyilmaz@gmail.com", true, "Ahmet", "Erkek", 5, "Yılmaz", false, null, "AHMETYILMAZ@GMAİL.COM", "AHMETYILMAZ", "AQAAAAIAAYagAAAAEFh7i+l1rE4iJqND3tvCmztkdt4m7ntxVmQWqIAkiLoI9X7mzeL9EMrx/Dy3xQTzYw==", "5551234567", null, false, "e17f53fd-7b71-4cf2-9f8b-cbbf1a380895", false, "ahmetyilmaz" },
                    { "cfc42ab8-9dce-4c75-ab56-b028ce37d410", 0, "Ankara", "cac4760b-51d7-4dcc-bd96-a1401cc387b4", new DateTime(2005, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "zeynepturk@gmail.com", true, "Zeynep", "Kadın", 5, "Türk", false, null, "ZEYNEPTURK@GMAIL.COM", "ZEYNEPTURK", "AQAAAAIAAYagAAAAEMP1b/S0o/Ar2gnsx/DI9ebTyEuPHFQr9jSfOkbdrd/4ChdeHSci9/dJwOKBibmNUw==", "5336549872", null, false, "d2160f2f-c817-4b97-a5ea-c0948522f2d0", false, "zeynepturk" },
                    { "d67af878-0c23-47ed-8f47-a6df9883b511", 0, "Antalya", "a5faffe1-7ad6-42da-9d00-cefa7b2cb391", new DateTime(1980, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "gul.sahin@hotmail.com", true, "Gül", "Kadın", 5, "Şahin", false, null, "GUL.SAHIN@HOTMAIL.COM", "GULSAHIN", "AQAAAAIAAYagAAAAEEi2rnQMAObSZc+QjVTvlOsVCBYLjPfv+LbZ8DoUT5K4PTKJ6L4WrKN9PSxjj0Lz2w==", "5361234567", null, false, "71643915-e95d-440f-99fe-98a9307974cc", false, "gulsahin" },
                    { "ed580c86-2e0d-4979-b6fd-17b880d049d2", 0, "İstanbul", "3aef4bc9-877b-4381-8702-d7ca9533033d", new DateTime(2008, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "emreakin@hotmail.com", true, "Emre", "Erkek", 5, "Akın", false, null, "EMREAKIN@HOTMAIL.COM", "EMREAKIN", "AQAAAAIAAYagAAAAELTVAZQtuj8u4i0HYovoO1xyGSfQjBRBHfBl86QkAzRwCSd27v+OTqUmmuQcYOGvwQ==", "5379876543", null, false, "3a9dff45-ce62-4209-b6b2-73330636d1e3", false, "emreakin" },
                    { "f5f3d15a-b5ae-438b-a0a5-5088a553c665", 0, "İstanbul", "038d3eba-2bb9-497e-9134-91297120d872", new DateTime(2007, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "denizcakir@hotmail.com", true, "Deniz", "Kadın", 5, "Çakır", false, null, "DENIZCAKIR@HOTMAIL.COM", "DENIZCAKIR", "AQAAAAIAAYagAAAAEMhlpGLYnwaq0p6h/n3MxkX1mMRoPUSiS7dAHfaqtAwfzUDq0ZGmwB+mbHFv2qX4KA==", "5396542513", null, false, "aec141ae-3b18-4b18-9c04-c1b694fab58d", false, "denizcakir" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "3182b0af-9c8b-4b85-9ca2-e515aa9c07cb", "007a6943-e32f-45ff-831a-8495521f0bd8" },
                    { "3182b0af-9c8b-4b85-9ca2-e515aa9c07cb", "018770f5-96dc-4b2e-a708-cfed11f446b0" },
                    { "eae1d03d-c1d5-4416-823d-038f86183653", "02fd7a75-988b-47aa-882f-7005f7ec1d34" },
                    { "eae1d03d-c1d5-4416-823d-038f86183653", "0e8d7b3b-9eb0-4d07-b0e9-7d86d02ee953" },
                    { "eae1d03d-c1d5-4416-823d-038f86183653", "1754aa6b-9727-4bdf-ade0-7b5fa99a300f" },
                    { "3182b0af-9c8b-4b85-9ca2-e515aa9c07cb", "1a3110df-5cdf-4b46-80ff-402c0228c23c" },
                    { "3182b0af-9c8b-4b85-9ca2-e515aa9c07cb", "288292d3-c958-412e-b541-41d63c62ced1" },
                    { "eae1d03d-c1d5-4416-823d-038f86183653", "309ddd20-a098-4df6-ba4c-86a9d72f9a49" },
                    { "eae1d03d-c1d5-4416-823d-038f86183653", "32d5a47e-b95c-49f2-87dd-e6bc21c6da2f" },
                    { "3182b0af-9c8b-4b85-9ca2-e515aa9c07cb", "6995048a-a055-4e6e-9ad1-6826c195cbef" },
                    { "eae1d03d-c1d5-4416-823d-038f86183653", "6f90465e-7fff-4216-8a76-34e7b278e735" },
                    { "eae1d03d-c1d5-4416-823d-038f86183653", "728d8571-f0b8-4eea-adac-43f7951505c2" },
                    { "3182b0af-9c8b-4b85-9ca2-e515aa9c07cb", "90c70b96-a9a7-47fd-a5b9-8a1cc1bd3cbd" },
                    { "5d26f66f-2b0b-4516-99b2-d41133b08d86", "c31f8d49-9a12-4f19-a03d-c358594cd9b6" },
                    { "3182b0af-9c8b-4b85-9ca2-e515aa9c07cb", "cb76beb4-41d5-4904-9493-fd67702781b2" },
                    { "3182b0af-9c8b-4b85-9ca2-e515aa9c07cb", "cfc42ab8-9dce-4c75-ab56-b028ce37d410" },
                    { "eae1d03d-c1d5-4416-823d-038f86183653", "d67af878-0c23-47ed-8f47-a6df9883b511" },
                    { "3182b0af-9c8b-4b85-9ca2-e515aa9c07cb", "ed580c86-2e0d-4979-b6fd-17b880d049d2" },
                    { "3182b0af-9c8b-4b85-9ca2-e515aa9c07cb", "f5f3d15a-b5ae-438b-a0a5-5088a553c665" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 1, "c31f8d49-9a12-4f19-a03d-c358594cd9b6" },
                    { 2, "f5f3d15a-b5ae-438b-a0a5-5088a553c665" },
                    { 3, "cb76beb4-41d5-4904-9493-fd67702781b2" },
                    { 4, "1a3110df-5cdf-4b46-80ff-402c0228c23c" },
                    { 5, "007a6943-e32f-45ff-831a-8495521f0bd8" },
                    { 6, "90c70b96-a9a7-47fd-a5b9-8a1cc1bd3cbd" },
                    { 7, "ed580c86-2e0d-4979-b6fd-17b880d049d2" },
                    { 8, "cfc42ab8-9dce-4c75-ab56-b028ce37d410" },
                    { 9, "6995048a-a055-4e6e-9ad1-6826c195cbef" },
                    { 10, "288292d3-c958-412e-b541-41d63c62ced1" },
                    { 11, "018770f5-96dc-4b2e-a708-cfed11f446b0" },
                    { 12, "02fd7a75-988b-47aa-882f-7005f7ec1d34" },
                    { 13, "728d8571-f0b8-4eea-adac-43f7951505c2" },
                    { 14, "0e8d7b3b-9eb0-4d07-b0e9-7d86d02ee953" },
                    { 15, "32d5a47e-b95c-49f2-87dd-e6bc21c6da2f" },
                    { 16, "d67af878-0c23-47ed-8f47-a6df9883b511" },
                    { 17, "6f90465e-7fff-4216-8a76-34e7b278e735" },
                    { 18, "1754aa6b-9727-4bdf-ade0-7b5fa99a300f" },
                    { 19, "309ddd20-a098-4df6-ba4c-86a9d72f9a49" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "UpdatedDate", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1538), true, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1549), null, "f5f3d15a-b5ae-438b-a0a5-5088a553c665" },
                    { 2, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1555), true, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1555), null, "cb76beb4-41d5-4904-9493-fd67702781b2" },
                    { 3, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1557), true, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1557), null, "1a3110df-5cdf-4b46-80ff-402c0228c23c" },
                    { 4, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1559), true, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1559), null, "007a6943-e32f-45ff-831a-8495521f0bd8" },
                    { 5, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1561), true, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1561), null, "90c70b96-a9a7-47fd-a5b9-8a1cc1bd3cbd" },
                    { 6, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1564), true, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1564), null, "ed580c86-2e0d-4979-b6fd-17b880d049d2" },
                    { 7, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1566), true, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1566), null, "cfc42ab8-9dce-4c75-ab56-b028ce37d410" },
                    { 8, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1568), true, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1568), null, "6995048a-a055-4e6e-9ad1-6826c195cbef" },
                    { 9, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1570), true, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1570), null, "288292d3-c958-412e-b541-41d63c62ced1" },
                    { 10, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1573), true, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1573), null, "018770f5-96dc-4b2e-a708-cfed11f446b0" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "CreatedDate", "Graduation", "IsApproved", "UpdatedDate", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1607), "Çanakkale Onsekiz Mart Üniversitesi", true, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1608), null, "02fd7a75-988b-47aa-882f-7005f7ec1d34" },
                    { 2, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1612), "Orta Doğu Teknik Üniversitesi", true, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1612), null, "728d8571-f0b8-4eea-adac-43f7951505c2" },
                    { 3, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1614), "İstanbul Teknik Üniversitesi", true, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1615), null, "0e8d7b3b-9eb0-4d07-b0e9-7d86d02ee953" },
                    { 4, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1616), "Ege Üniversitesi", true, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1617), null, "32d5a47e-b95c-49f2-87dd-e6bc21c6da2f" },
                    { 5, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1618), "Akdeniz Üniversitesi", true, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1619), null, "d67af878-0c23-47ed-8f47-a6df9883b511" },
                    { 6, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1621), "Erciyes Üniversitesi", true, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1622), null, "6f90465e-7fff-4216-8a76-34e7b278e735" },
                    { 7, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1624), "Çukurova Üniversitesi", true, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1624), null, "1754aa6b-9727-4bdf-ade0-7b5fa99a300f" },
                    { 8, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1626), "Uludağ Üniversitesi", true, new DateTime(2023, 5, 13, 16, 24, 46, 493, DateTimeKind.Local).AddTicks(1626), null, "309ddd20-a098-4df6-ba4c-86a9d72f9a49" }
                });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "BranchId", "CreatedDate", "Description", "IsApproved", "Price", "TeacherId", "UpdatedDate", "Url" },
                values: new object[] { 1, 4, new DateTime(2023, 5, 13, 16, 24, 47, 836, DateTimeKind.Local).AddTicks(9484), "dsdasd", true, 45m, 4, new DateTime(2023, 5, 13, 16, 24, 47, 836, DateTimeKind.Local).AddTicks(9490), "dsdds" });

            migrationBuilder.InsertData(
                table: "TeacherBranches",
                columns: new[] { "BranchId", "TeacherId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 7 },
                    { 9, 7 },
                    { 10, 8 }
                });

            migrationBuilder.InsertData(
                table: "TeacherStudents",
                columns: new[] { "StudentId", "TeacherId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 4, 2 },
                    { 6, 3 },
                    { 5, 6 },
                    { 1, 7 },
                    { 2, 7 },
                    { 3, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_BranchId",
                table: "Adverts",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_TeacherId",
                table: "Adverts",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_AdvertId",
                table: "CartItems",
                column: "AdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_AdvertId",
                table: "OrderItems",
                column: "AdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherBranches_BranchId",
                table: "TeacherBranches",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserId",
                table: "Teachers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherStudents_StudentId",
                table: "TeacherStudents",
                column: "StudentId");
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
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "TeacherBranches");

            migrationBuilder.DropTable(
                name: "TeacherStudents");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Adverts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
